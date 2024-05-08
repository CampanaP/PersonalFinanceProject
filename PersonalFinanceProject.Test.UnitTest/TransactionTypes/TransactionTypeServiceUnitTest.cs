using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Services;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Library.EntityFramework.Repositories;

namespace PersonalFinanceProject.Test.UnitTest.TransactionTypes
{
    [TestClass]
    internal class TransactionTypeServiceUnitTest
    {
        private SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");
        private TransactionDbContext? _dbContext;
        private IGenericRepository<TransactionType, TransactionDbContext>? _genericRepository;
        private ServiceProvider? _serviceProvider;
        private TransactionTypeService? _transactionTypeService;

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

            _genericRepository = new GenericRepository<TransactionType, TransactionDbContext>(_dbContext);
            _transactionTypeService = new TransactionTypeService(_genericRepository);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            TransactionDbContext dbContext = _serviceProvider!.GetRequiredService<TransactionDbContext>();

            await dbContext.Database.EnsureDeletedAsync();

            await _connection.CloseAsync();
        }

        [TestMethod]
        [DataRow(1, "TransactionType1")]
        public async Task ShouldAddTransactionType(int id, string name)
        {
            // Arrange:
            TransactionType transactionType = new TransactionType(id, name);

            // Act:
            await _transactionTypeService!.Add(transactionType);

            // Assert:
            TransactionType? addTransactionType = await _dbContext!.TransactionTypes.FirstOrDefaultAsync(tt => tt.Id == id);
            Assert.IsNotNull(addTransactionType);
            Assert.AreEqual(name, addTransactionType.Name);
        }

        [TestMethod]
        [DataRow(1, "TransactionType1")]
        public async Task ShouldDeleteByIdTransactionType(int id, string name)
        {
            //Arrange:
            TransactionType transactionType = new TransactionType(id, name);
            await _transactionTypeService!.Add(transactionType);

            // Act:
            await _transactionTypeService!.DeleteById(id);

            // Assert:
            TransactionType? deletedTransactionType = await _dbContext!.TransactionTypes.FirstOrDefaultAsync(tt => tt.Id == id);
            Assert.IsNull(deletedTransactionType);
        }

        [TestMethod]
        [DataRow(1, "TransactionType1")]
        public async Task ShouldGetByIdTransactionType(int id, string name)
        {
            // Arrange:
            TransactionType transactionType = new TransactionType(id, name);
            await _transactionTypeService!.Add(transactionType);

            // Act:
            TransactionType? getByIdTransactionType = await _transactionTypeService.GetById(id);

            // Assert:
            Assert.IsNotNull(getByIdTransactionType);
            Assert.AreEqual(transactionType.Id, getByIdTransactionType.Id);
            Assert.AreEqual(transactionType.Name, getByIdTransactionType.Name);
        }

        [TestMethod]
        public async Task ShouldGetListTransactionType()
        {
            // Arrange:
            List<TransactionType> transactionTypes = new List<TransactionType>()
            {
                new TransactionType(1, "TransactionType1"),
                new TransactionType(2, "TransactionType2")
            };

            foreach (TransactionType transactionType in transactionTypes)
            {
                await _transactionTypeService!.Add(transactionType);
            }

            // Act:
            IEnumerable<TransactionType> getListTransactionTypes = await _transactionTypeService!.GetList();

            // Assert:
            Assert.IsNotNull(getListTransactionTypes);
            Assert.AreNotEqual(Enumerable.Empty<TransactionType>(), getListTransactionTypes);
            Assert.AreEqual(transactionTypes.Count, getListTransactionTypes.Count());
        }

        [TestMethod]
        [DataRow(1, "TransactionType1", "TransactionType2")]
        public async Task ShouldUpdateTransactionType(int id, string name, string newName)
        {
            // Arrange:
            TransactionType transactionType = new TransactionType(id, name);
            await _transactionTypeService!.Add(transactionType);

            // Act:
            transactionType.Name = newName;
            await _transactionTypeService!.Update(transactionType);

            // Assert:
            TransactionType? updatedTransactionType = await _dbContext!.TransactionTypes.FirstOrDefaultAsync(tc => tc.Id == id);
            Assert.IsNotNull(updatedTransactionType);
            Assert.AreEqual(id, updatedTransactionType.Id);
            Assert.AreEqual(newName, updatedTransactionType.Name);
        }
    }
}