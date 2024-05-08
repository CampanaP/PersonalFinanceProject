using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Business.Transaction.Services;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Library.EntityFramework.Repositories;

namespace PersonalFinanceProject.Test.UnitTest.Transactions
{
    [TestClass]
    internal class TransactionServiceUnitTest
    {
        private SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");
        private TransactionDbContext? _dbContext;
        private IGenericRepository<Transaction, TransactionDbContext>? _genericRepository;
        private ServiceProvider? _serviceProvider;
        private TransactionService? _transactionService;

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

            _genericRepository = new GenericRepository<Transaction, TransactionDbContext>(_dbContext);
            _transactionService = new TransactionService(_genericRepository);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            TransactionDbContext dbContext = _serviceProvider!.GetRequiredService<TransactionDbContext>();

            await dbContext.Database.EnsureDeletedAsync();

            await _connection.CloseAsync();
        }

        [TestMethod]
        [DataRow("Transaction1", 1, 1, 1)]
        public async Task ShouldAddTransactionType(string name, double amount, int categoryId, int typeId)
        {
            // Arrange:
            Guid id = Guid.Empty;
            Guid sourceId = Guid.NewGuid();
            DateTime dateTimeNow = DateTime.Now;

            Transaction transaction = new Transaction(id, name, amount, categoryId, typeId, sourceId, dateTimeNow, dateTimeNow);

            // Act:
            transaction.Id = await _transactionService!.Add(transaction);

            // Assert:
            Transaction? addTransaction = await _dbContext!.Transactions.FirstOrDefaultAsync(t => t.Id == transaction.Id);
            Assert.IsNotNull(addTransaction);
            Assert.AreEqual(name, addTransaction.Name);
            Assert.AreEqual(amount, addTransaction.Amount);
            Assert.AreEqual(categoryId, addTransaction.CategoryId);
            Assert.AreEqual(typeId, addTransaction.TypeId);
            Assert.AreEqual(sourceId, addTransaction.SourceId);
            Assert.AreEqual(dateTimeNow, addTransaction.CreateDate);
            Assert.AreEqual(dateTimeNow, addTransaction.UpdateDate);
        }

        [TestMethod]
        [DataRow("Transaction1", 1, 1, 1)]
        public async Task ShouldDeleteByIdTransaction(string name, double amount, int categoryId, int typeId)
        {
            // Arrange:
            Guid id = Guid.Empty;
            Guid sourceId = Guid.NewGuid();
            DateTime dateTimeNow = DateTime.Now;

            Transaction transaction = new Transaction(id, name, amount, categoryId, typeId, sourceId, dateTimeNow, dateTimeNow);
            id = await _transactionService!.Add(transaction);

            // Act:
            await _transactionService!.DeleteById(id);

            // Assert:
            Transaction? deletedTransaction = await _dbContext!.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            Assert.IsNull(deletedTransaction);
        }

        [TestMethod]
        [DataRow("Transaction1", 1, 1, 1)]
        public async Task ShouldGetByIdTransactionType(string name, double amount, int categoryId, int typeId)
        {
            // Arrange:
            Guid id = Guid.Empty;
            Guid sourceId = Guid.NewGuid();
            DateTime dateTimeNow = DateTime.Now;

            Transaction transaction = new Transaction(id, name, amount, categoryId, typeId, sourceId, dateTimeNow, dateTimeNow);
            id = await _transactionService!.Add(transaction);

            // Act:
            Transaction? getByIdTransaction = await _transactionService.GetById(id);

            // Assert:
            Assert.IsNotNull(getByIdTransaction);
            Assert.AreEqual(transaction.Id, getByIdTransaction.Id);
            Assert.AreEqual(transaction.Name, getByIdTransaction.Name);
        }

        [TestMethod]
        public async Task ShouldGetListTransactionType()
        {
            // Arrange:
            List<Transaction> transactions = new List<Transaction>()
            {
                new Transaction(Guid.NewGuid(), "Transaction1", 1, 1, 1, Guid.NewGuid(), DateTime.Now, DateTime.Now),
                new Transaction(Guid.NewGuid(), "Transaction2", 2, 1, 1, Guid.NewGuid(), DateTime.Now, DateTime.Now)
            };

            foreach (Transaction transaction in transactions)
            {
                await _transactionService!.Add(transaction);
            }

            // Act:
            IEnumerable<Transaction> getListTransactions = await _transactionService!.GetList();

            // Assert:
            Assert.IsNotNull(getListTransactions);
            Assert.AreNotEqual(Enumerable.Empty<Transaction>(), getListTransactions);
            Assert.AreEqual(transactions.Count, getListTransactions.Count());
        }

        [TestMethod]
        [DataRow("Transaction1", 1, 1, 1, "Transaction2", 2, 2, 2)]
        public async Task ShouldUpdateTransactionType(string name, double amount, int categoryId, int typeId, string newName, double newAmount, int newCategoryId, int newTypeId)
        {
            // Arrange:
            Guid id = Guid.Empty;
            Guid sourceId = Guid.NewGuid();
            Guid newSourceId = Guid.NewGuid();
            DateTime dateTimeNow = DateTime.Now;


            Transaction transaction = new Transaction(id, name, amount, categoryId, typeId, sourceId, dateTimeNow, dateTimeNow);
            id = await _transactionService!.Add(transaction);

            // Act:
            transaction.Name = newName;
            transaction.Amount = newAmount;
            transaction.CategoryId = newCategoryId;
            transaction.TypeId = newTypeId;
            transaction.SourceId = newSourceId;
            transaction.UpdateDate = DateTime.Now;

            await _transactionService!.Update(transaction);

            // Assert:
            Transaction? updatedTransaction = await _dbContext!.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            Assert.IsNotNull(updatedTransaction);
            Assert.AreEqual(id, updatedTransaction.Id);
            Assert.AreEqual(newName, updatedTransaction.Name);
            Assert.AreEqual(newAmount, updatedTransaction.Amount);
            Assert.AreEqual(newCategoryId, updatedTransaction.CategoryId);
            Assert.AreEqual(newTypeId, updatedTransaction.TypeId);
            Assert.AreEqual(newSourceId, updatedTransaction.SourceId);
            Assert.AreEqual(dateTimeNow, updatedTransaction.CreateDate);
            Assert.AreNotEqual(dateTimeNow, updatedTransaction.UpdateDate);
        }
    }
}