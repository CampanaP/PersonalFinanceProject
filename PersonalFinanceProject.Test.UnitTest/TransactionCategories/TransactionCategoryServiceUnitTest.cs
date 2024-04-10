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

        [TestInitialize]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<TransactionDbContext>(options => options.UseInMemoryDatabase("UnitTestDb"));
            _serviceProvider = services.BuildServiceProvider();

            using (IServiceScope scope = _serviceProvider!.CreateScope())
            {
                _dbContext = _serviceProvider.GetRequiredService<TransactionDbContext>();
            }

            _transactionCategoryRepository = new TransactionCategoryRepository(_dbContext);
            _transactionCategoryService = new TransactionCategoryService(_transactionCategoryRepository);
        }

        [TestCleanup]
        public void Cleanup()
        {
            TransactionDbContext dbContext = _serviceProvider!.GetRequiredService<TransactionDbContext>();

            dbContext.Database.EnsureDeleted();
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

        public async Task ShouldDeleteByIdTransactionCategory()
        {
            // Arrange:

            // Act:

            // Assert:
        }

        public async Task ShouldGetByIdTransactionCategory()
        {
            // Arrange:

            // Act:

            // Assert:
        }

        public async Task ShouldGetListTransactionCategory()
        {
            // Arrange:

            // Act:

            // Assert:
        }

        public async Task ShouldUpdateTransactionCategory()
        {
            // Arrange:

            // Act:

            // Assert:
        }
    }
}