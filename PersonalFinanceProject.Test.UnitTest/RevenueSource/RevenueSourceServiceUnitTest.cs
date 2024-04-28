using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Business.Wallet.Services;
using PersonalFinanceProject.Library.EntityFramework.DbContexts;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Library.EntityFramework.Repositories;

namespace PersonalFinanceProject.Test.UnitTest.RevenueSources
{
    [TestClass]
    internal class RevenueSourceServiceUnitTest
    {
        private SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");
        private GenericDbContext? _dbContext;
        private IGenericRepository<RevenueSource>? _genericRepository;
        private ServiceProvider? _serviceProvider;
        private IRevenueSourceService? _revenueSourceService;

        [TestInitialize]
        public async Task Setup()
        {
            await _connection.OpenAsync();

            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<GenericDbContext>(options =>
                options.UseSqlite(_connection)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution));

            _serviceProvider = services.BuildServiceProvider();

            _dbContext = _serviceProvider.GetRequiredService<GenericDbContext>();
            await _dbContext.Database.EnsureCreatedAsync();

            _genericRepository = new GenericRepository<RevenueSource>(_dbContext);

            _revenueSourceService = new RevenueSourceService(_genericRepository);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            TransactionDbContext dbContext = _serviceProvider!.GetRequiredService<TransactionDbContext>();

            await dbContext.Database.EnsureDeletedAsync();

            await _connection.CloseAsync();
        }

        [TestMethod]
        [DataRow("RevenueSource1")]
        public async Task ShouldAddRevenueSource(string name)
        {
            // Arrange:
            DateTime dateTimeNow = DateTime.Now;
            Guid userId = Guid.NewGuid();
            RevenueSource revenueSource = new RevenueSource(Guid.Empty, name, userId, dateTimeNow, dateTimeNow);

            // Act:
            Guid id = await _revenueSourceService!.Add(revenueSource);

            // Assert:
            RevenueSource? addedRevenueSource = await _dbContext!.Set<RevenueSource>().FirstOrDefaultAsync(rs => rs.Id == id);
            Assert.IsNotNull(addedRevenueSource);
            Assert.AreEqual(name, addedRevenueSource.Name);
            Assert.AreEqual(userId, addedRevenueSource.UserId);
            Assert.AreEqual(dateTimeNow, addedRevenueSource.CreateDate);
            Assert.AreEqual(dateTimeNow, addedRevenueSource.UpdateDate);
        }

        //[TestMethod]
        [DataRow(1, "TransactionCategory1")]
        public async Task ShouldDeleteByIdTransactionCategory(int id, string name)
        {
            //Arrange:
            //TransactionCategory transactionCategory = new TransactionCategory(id, name);
            //await _transactionCategoryService!.Add(transactionCategory);

            // Act:
            //await _transactionCategoryService!.DeleteById(id);

            // Assert:
            //TransactionCategory? deletedTransactionCategory = await _dbContext!.TransactionCategories.FirstOrDefaultAsync(tc => tc.Id == id);
            //Assert.IsNull(deletedTransactionCategory);
        }

        //[TestMethod]
        [DataRow(1, "TransactionCategory1")]
        public async Task ShouldGetByIdTransactionCategory(int id, string name)
        {
            // Arrange:
            //TransactionCategory transactionCategory = new TransactionCategory(id, name);
            //await _transactionCategoryService!.Add(transactionCategory);

            // Act:
            //TransactionCategory? getByIdTransactionCategory = await _transactionCategoryService.GetById(id);

            // Assert:
            //Assert.IsNotNull(getByIdTransactionCategory);
            //Assert.AreEqual(transactionCategory.Id, getByIdTransactionCategory.Id);
            //Assert.AreEqual(transactionCategory.Name, getByIdTransactionCategory.Name);
        }

        //[TestMethod]
        public async Task ShouldGetListTransactionCategory()
        {
            // Arrange:
            //List<TransactionCategory> transactionCategories = new List<TransactionCategory>()
            //{
            //    new TransactionCategory(1, "TransactionCategory1"),
            //    new TransactionCategory(2, "TransactionCategory2")
            //};

            //foreach (TransactionCategory transactionCategory in transactionCategories)
            //{
            //    await _transactionCategoryService!.Add(transactionCategory);
            //}

            // Act:
            //IEnumerable<TransactionCategory> getListTransactionCategories = await _transactionCategoryService!.GetList();

            // Assert:
            //Assert.IsNotNull(getListTransactionCategories);
            //Assert.AreNotEqual(Enumerable.Empty<TransactionCategory>(), getListTransactionCategories);
            //Assert.AreEqual(transactionCategories.Count, getListTransactionCategories.Count());
        }

        //[TestMethod]
        [DataRow(1, "TransactionCategory1", "TransactionCategory2")]
        public async Task ShouldUpdateTransactionCategory(int id, string name, string newName)
        {
            // Arrange:
            //TransactionCategory transactionCategory = new TransactionCategory(id, name);
            //await _transactionCategoryService!.Add(transactionCategory);

            // Act:
            //transactionCategory.Name = newName;
            //await _transactionCategoryService!.Update(transactionCategory);

            // Assert:
            //TransactionCategory? updatedTransactionCategory = await _dbContext!.TransactionCategories.FirstOrDefaultAsync(tc => tc.Id == id);
            //Assert.IsNotNull(updatedTransactionCategory);
            //Assert.AreEqual(id, updatedTransactionCategory.Id);
            //Assert.AreEqual(newName, updatedTransactionCategory.Name);
        }
    }
}