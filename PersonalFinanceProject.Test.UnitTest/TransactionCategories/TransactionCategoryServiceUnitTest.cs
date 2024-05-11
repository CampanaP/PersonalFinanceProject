using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Services;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Library.EntityFramework.Repositories;

namespace PersonalFinanceProject.Test.UnitTest.TransactionCategories
{
    [TestClass]
    internal class TransactionCategoryServiceUnitTest
    {
        private SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");
        private TransactionDbContext? _dbContext;
        private IGenericRepository<TransactionCategory, TransactionDbContext>? _genericRepository;
        private ServiceProvider? _serviceProvider;
        private TransactionCategoryService? _transactionCategoryService;

        [TestInitialize]
        public async Task Setup()
        {
            await _connection.OpenAsync();

            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<TransactionDbContext>(options =>
                options
                    .UseSqlite(_connection)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            _serviceProvider = services.BuildServiceProvider();

            _dbContext = _serviceProvider.GetRequiredService<TransactionDbContext>();
            await _dbContext.Database.EnsureCreatedAsync();

            _genericRepository = new GenericRepository<TransactionCategory, TransactionDbContext>(_dbContext);
            _transactionCategoryService = new TransactionCategoryService(_genericRepository);
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
            Assert.AreEqual(transactionCategory.Id, getByIdTransactionCategory.Id);
            Assert.AreEqual(transactionCategory.Name, getByIdTransactionCategory.Name);
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
            Assert.AreNotEqual(Enumerable.Empty<TransactionCategory>(), getListTransactionCategories);
            Assert.AreEqual(transactionCategories.Count, getListTransactionCategories.Count());
        }

        [TestMethod]
        [DataRow(1, "TransactionCategory1", "TransactionCategory2")]
        public async Task ShouldUpdateByIdTransactionCategory(int id, string name, string newName)
        {
            // Arrange:
            TransactionCategory transactionCategory = new TransactionCategory(id, name);
            await _transactionCategoryService!.Add(transactionCategory);

            // Act:
            transactionCategory.Name = newName;
            await _transactionCategoryService!.UpdateById(transactionCategory);

            // Assert:
            TransactionCategory? updatedTransactionCategory = await _dbContext!.TransactionCategories.FirstOrDefaultAsync(tc => tc.Id == id);
            Assert.IsNotNull(updatedTransactionCategory);
            Assert.AreEqual(id, updatedTransactionCategory.Id);
            Assert.AreEqual(newName, updatedTransactionCategory.Name);
        }
    }
}