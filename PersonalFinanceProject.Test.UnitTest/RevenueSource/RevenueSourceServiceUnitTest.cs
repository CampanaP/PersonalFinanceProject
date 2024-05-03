using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Wallet.DbContexts;
using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Business.Wallet.Interfaces.Services;
using PersonalFinanceProject.Business.Wallet.Services;
using PersonalFinanceProject.Library.EntityFramework.Interfaces.Repositories;
using PersonalFinanceProject.Library.EntityFramework.Repositories;

namespace PersonalFinanceProject.Test.UnitTest.RevenueSources
{
    [TestClass]
    internal class RevenueSourceServiceUnitTest
    {
        private SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");
        private WalletDbContext? _dbContext;
        private IGenericRepository<RevenueSource, WalletDbContext>? _genericRepository;
        private ServiceProvider? _serviceProvider;
        private IRevenueSourceService? _revenueSourceService;

        [TestInitialize]
        public async Task Setup()
        {
            await _connection.OpenAsync();

            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<WalletDbContext>(options =>
                options
                    .UseSqlite(_connection)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            _serviceProvider = services.BuildServiceProvider();

            _dbContext = _serviceProvider.GetRequiredService<WalletDbContext>();
            await _dbContext.Database.EnsureCreatedAsync();

            _genericRepository = new GenericRepository<RevenueSource, WalletDbContext>(_dbContext);

            _revenueSourceService = new RevenueSourceService(_genericRepository);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            WalletDbContext dbContext = _serviceProvider!.GetRequiredService<WalletDbContext>();

            await dbContext.Database.EnsureDeletedAsync();

            await _connection.CloseAsync();
        }

        [TestMethod]
        [DataRow("RevenueSource1")]
        public async Task ShouldAdd(string name)
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

        [TestMethod]
        [DataRow("RevenueSource1")]
        public async Task ShouldDeleteById(string name)
        {
            // Arrange:
            DateTime dateTimeNow = DateTime.Now;
            Guid userId = Guid.NewGuid();
            RevenueSource revenueSource = new RevenueSource(Guid.Empty, name, userId, dateTimeNow, dateTimeNow);
            Guid id = await _revenueSourceService!.Add(revenueSource);
            _dbContext!.Entry(revenueSource).State = EntityState.Detached;


            // Act:
            await _revenueSourceService.DeleteById(id);

            // Assert:
            RevenueSource? deletedRevenueSource = await _revenueSourceService.GetById(id);
            Assert.IsNull(deletedRevenueSource);
        }

        [TestMethod]
        [DataRow("RevenueSource1")]
        public async Task ShouldGetById(string name)
        {
            // Arrange:
            DateTime dateTimeNow = DateTime.Now;
            Guid userId = Guid.NewGuid();
            RevenueSource revenueSource = new RevenueSource(Guid.Empty, name, userId, dateTimeNow, dateTimeNow);
            Guid id = await _revenueSourceService!.Add(revenueSource);
            _dbContext!.Entry(revenueSource).State = EntityState.Detached;

            // Act:
            RevenueSource? getByIdRevenueSource = await _revenueSourceService.GetById(id);

            // Assert:
            Assert.IsNotNull(getByIdRevenueSource);
            Assert.AreEqual(id, getByIdRevenueSource.Id);
            Assert.AreEqual(name, getByIdRevenueSource.Name);
            Assert.AreEqual(userId, getByIdRevenueSource.UserId);
            Assert.AreEqual(dateTimeNow, getByIdRevenueSource.CreateDate);
            Assert.AreEqual(dateTimeNow, getByIdRevenueSource.UpdateDate);
        }

        [TestMethod]
        [DataRow("RevenueSource1", "RevenueSource2")]
        public async Task ShouldGetList(string firstName, string secondName)
        {
            // Arrange:
            DateTime dateTimeNow = DateTime.Now;
            Guid firstUserId = Guid.NewGuid();
            Guid secondUserId = Guid.NewGuid();

            List<RevenueSource> revenueSources = new List<RevenueSource>()
            {
                new RevenueSource(Guid.Empty, firstName, firstUserId, dateTimeNow, dateTimeNow),
                new RevenueSource(Guid.Empty, secondName, secondUserId, dateTimeNow, dateTimeNow)
            };

            foreach (RevenueSource revenueSource in revenueSources)
            {
                await _revenueSourceService!.Add(revenueSource);
                _dbContext!.Entry(revenueSource).State = EntityState.Detached;
            }

            // Act:
            IEnumerable<RevenueSource> getListRevenueSources = await _revenueSourceService!.GetList();

            // Assert:
            Assert.IsNotNull(getListRevenueSources);
            Assert.AreNotEqual(Enumerable.Empty<RevenueSource>(), getListRevenueSources);
            Assert.AreEqual(revenueSources.Count, getListRevenueSources.Count());
        }

        [TestMethod]
        [DataRow("RevenueSource1", "RevenueSource2")]
        public async Task ShouldUpdate(string name, string newName)
        {
            // Arrange:
            DateTime dateTimeNow = DateTime.Now;
            Guid userId = Guid.NewGuid();
            RevenueSource revenueSource = new RevenueSource(Guid.Empty, name, userId, dateTimeNow, dateTimeNow);
            Guid id = await _revenueSourceService!.Add(revenueSource);
            _dbContext!.Entry(revenueSource).State = EntityState.Detached;

            // Act:
            revenueSource.Name = newName;
            await _revenueSourceService!.Update(revenueSource);

            // Assert:
            RevenueSource? updatedRevenueSource = await _revenueSourceService.GetById(id);
            Assert.IsNotNull(updatedRevenueSource);
            Assert.AreEqual(revenueSource.Id, updatedRevenueSource.Id);
            Assert.AreNotEqual(name, updatedRevenueSource.Name);
            Assert.AreEqual(newName, updatedRevenueSource.Name);
            Assert.AreEqual(revenueSource.UserId, updatedRevenueSource.UserId);
            Assert.AreEqual(revenueSource.CreateDate, updatedRevenueSource.CreateDate);
            Assert.AreEqual(revenueSource.UpdateDate, updatedRevenueSource.UpdateDate);
        }
    }
}