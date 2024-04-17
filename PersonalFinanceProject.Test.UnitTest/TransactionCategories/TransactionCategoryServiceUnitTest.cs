using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Repositories;
using PersonalFinanceProject.Business.Transaction.Services;

namespace PersonalFinanceProject.Test.UnitTest.TransactionCategories
{
    [TestClass]
    internal class TransactionCategoryServiceUnitTest
    {
        private ServiceProvider? _serviceProvider;
        private TransactionCategoryRepository? _transactionCategoryRepository;
        private TransactionCategoryService? _transactionCategoryService;
        private TransactionDbContext? _dbContext;
        private SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");

        [TestInitialize]
        public async Task Setup()
        {
            await _connection.OpenAsync();

            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<TransactionDbContext>(options => 
                options.UseSqlite(_connection)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution));
            
            _serviceProvider = services.BuildServiceProvider();
            _dbContext = _serviceProvider.GetRequiredService<TransactionDbContext>();

            await _dbContext.Database.EnsureCreatedAsync();

            _transactionCategoryRepository = new TransactionCategoryRepository(_dbContext);
            _transactionCategoryService = new TransactionCategoryService(_transactionCategoryRepository);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            TransactionDbContext dbContext = _serviceProvider!.GetRequiredService<TransactionDbContext>();

            await dbContext.Database.EnsureDeletedAsync();

            await _connection.CloseAsync();
        }

        [TestMethod]
        [DataRow(1, "TransactionCategory1")]
        public async Task ShouldAddTransactionCategory(int id, string name)
        {
            // Arrange:
            TransactionCategory transactionCategory = new TransactionCategory(id, name);

            // Act:
            await _transactionCategoryService!.Add(transactionCategory);

            // Assert:
            TransactionCategory? addTransactionCategory = await _dbContext!.TransactionCategories.FirstOrDefaultAsync(tc => tc.Id == id);
            Assert.IsNotNull(addTransactionCategory);
            Assert.AreEqual(name, addTransactionCategory.Name);
        }

        [TestMethod]
        [DataRow(1, "TransactionCategory1")]
        public async Task ShouldDeleteByIdTransactionCategory(int id, string name)
        {
            //Arrange:
            TransactionCategory transactionCategory = new TransactionCategory(id, name);
            await _transactionCategoryService!.Add(transactionCategory);

            // Act:
            await _transactionCategoryService!.DeleteById(id);

            // Assert:
            TransactionCategory? deletedTransactionCategory = await _dbContext!.TransactionCategories.FirstOrDefaultAsync(tc => tc.Id == id);
            Assert.IsNull(deletedTransactionCategory);
        }

        [TestMethod]
        [DataRow(1, "TransactionCategory1")]
        public async Task ShouldGetByIdTransactionCategory(int id, string name)
        {
            // Arrange:
            TransactionCategory transactionCategory = new TransactionCategory(id, name);
            await _transactionCategoryService!.Add(transactionCategory);

            // Act:
            TransactionCategory? getByIdTransactionCategory = await _transactionCategoryService.GetById(id);

            // Assert:
            Assert.IsNotNull(getByIdTransactionCategory);
            Assert.AreEqual(getByIdTransactionCategory.Id, transactionCategory.Id);
            Assert.AreEqual(getByIdTransactionCategory.Name, transactionCategory.Name);
        }

        [TestMethod]
        public async Task ShouldGetListTransactionCategory()
        {
            // Arrange:
            List<TransactionCategory> transactionCategories = new List<TransactionCategory>()
            {
                new TransactionCategory(1, "TransactionCategory1"),
                new TransactionCategory(2, "TransactionCategory2")
            };

            foreach (TransactionCategory transactionCategory in transactionCategories)
            {
                await _transactionCategoryService!.Add(transactionCategory);
            }

            // Act:
            IEnumerable<TransactionCategory> getListTransactionCategories = await _transactionCategoryService!.GetList();

            // Assert:
            Assert.IsNotNull(getListTransactionCategories);
            Assert.AreNotEqual(getListTransactionCategories, Enumerable.Empty<TransactionCategory>());
            Assert.AreEqual(getListTransactionCategories.Count(), 2);
        }

        [TestMethod]
        [DataRow(1, "TransactionCategory1", "TransactionCategory2")]
        public async Task ShouldUpdateTransactionCategory(int id, string name, string newName)
        {
            // Arrange:
            TransactionCategory transactionCategory = new TransactionCategory(id, name);
            await _transactionCategoryService!.Add(transactionCategory);

            // Act:
            transactionCategory.Name = newName;
            await _transactionCategoryService!.Update(transactionCategory);

            // Assert:
            TransactionCategory? updatedTransactionCategory = await _dbContext!.TransactionCategories.FirstOrDefaultAsync(tc => tc.Id == id);
            Assert.IsNotNull(updatedTransactionCategory);
            Assert.AreEqual(updatedTransactionCategory.Id, id);
            Assert.AreEqual(updatedTransactionCategory.Name, newName);
        }
    }
}