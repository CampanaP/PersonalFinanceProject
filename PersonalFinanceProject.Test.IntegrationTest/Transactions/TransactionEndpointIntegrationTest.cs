using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;
using PersonalFinanceProject.Communication.Message.Transaction.Responses;
using PersonalFinanceProject.Test.IntegrationTest.Factories;
using PersonalFinanceProject.Web.Api;
using System.Net.Http.Json;
using System.Resources;
using System.Text;
using System.Text.Json;

namespace PersonalFinanceProject.Test.IntegrationTest.Transactions
{
    [TestClass]
    internal class TransactionEndpointIntegrationTest
    {
        private CustomWebApplicationFactory<Program>? _applicationFactory;
        private TransactionDbContext? _dbContext;
        private HttpClient? _httpClient;

        [TestInitialize]
        public async Task Setup()
        {
            _applicationFactory = new CustomWebApplicationFactory<Program>();

            _dbContext = _applicationFactory.Services.GetRequiredService<TransactionDbContext>();
            await _dbContext.Database.EnsureCreatedAsync();

            _httpClient = _applicationFactory.CreateClient();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _dbContext!.Database.EnsureDeletedAsync();

            _httpClient!.Dispose();
        }

        [TestMethod]
        [DataRow("Transaction1", 1, 1, 1)]
        public async Task ShouldAdd(string name, double amount, int categoryId, int typeId)
        {
            // Arrange
            Guid sourceId = Guid.NewGuid();
            DateTime dateTimeNow = DateTime.Now;
            TransactionAddRequest request = new TransactionAddRequest(name, amount, categoryId, typeId, sourceId, dateTimeNow, dateTimeNow);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage? response = await _httpClient!.PostAsync(TransactionIntegrationTestConstant.AddEndpointUrl, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task ShouldDeleteById()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            string url = $"{TransactionIntegrationTestConstant.DeleteEndpointUrl}/{id}";
            TransactionDeleteByIdRequest request = new TransactionDeleteByIdRequest(id);

            StringContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            HttpRequestMessage httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url, UriKind.Relative),
                Content = content
            };

            // Act
            HttpResponseMessage? response = await _httpClient!.SendAsync(httpRequest);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        [DataRow("Transaction1", 1, 1, 1)]
        public async Task ShouldGetById(string name, double amount, int categoryId, int typeId)
        {
            // Arrange
            Guid sourceId = Guid.NewGuid();
            DateTime dateTimeNow = DateTime.Now;

            TransactionAddRequest request = new TransactionAddRequest(name, amount, categoryId, typeId, sourceId, dateTimeNow, dateTimeNow);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            HttpResponseMessage? addResponseMessage = await _httpClient!.PostAsync(TransactionIntegrationTestConstant.AddEndpointUrl, content);
            TransactionAddResponse? addResponse = await addResponseMessage.Content.ReadFromJsonAsync<TransactionAddResponse>();

            Guid id = addResponse?.Id ?? Guid.NewGuid();
            string url = $"{TransactionIntegrationTestConstant.GetEndpointUrl}/{id}";

            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(url);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);

            TransactionGetByIdResponse? transaction = await response.Content.ReadFromJsonAsync<TransactionGetByIdResponse>();
            Assert.IsNotNull(transaction);
            Assert.IsNotNull(transaction.Transaction);
            Assert.AreEqual(id, transaction.Transaction.Id);
            Assert.AreEqual(name, transaction.Transaction.Name);
            Assert.AreEqual(amount, transaction.Transaction.Amount);
            Assert.AreEqual(categoryId, transaction.Transaction.CategoryId);
            Assert.AreEqual(typeId, transaction.Transaction.TypeId);
            Assert.AreEqual(sourceId, transaction.Transaction.SourceId);
            Assert.AreEqual(dateTimeNow, transaction.Transaction.CreateDate);
            Assert.AreEqual(dateTimeNow, transaction.Transaction.UpdateDate);
        }

        [TestMethod]
        public async Task ShouldGetList()
        {
            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(TransactionIntegrationTestConstant.GetListEndpointUrl);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        [DataRow("Transaction1", 1, 1, 1, "Transaction2", 2, 2, 2)]
        public async Task ShouldUpdateById(string name, double amount, int categoryId, int typeId, string newName, double newAmount, int newCategoryId, int newTypeId)
        {
            // Arrange
            Guid sourceId = Guid.NewGuid();
            Guid newSourceId = Guid.NewGuid();
            DateTime dateTimeNow = DateTime.Now;

            TransactionAddRequest addRequest = new TransactionAddRequest(name, amount, categoryId, typeId, sourceId, dateTimeNow, dateTimeNow);
            HttpContent addContent = new StringContent(JsonSerializer.Serialize(addRequest), Encoding.UTF8, "application/json");

            HttpResponseMessage? addResponseMessage = await _httpClient!.PostAsync(TransactionIntegrationTestConstant.AddEndpointUrl, addContent);
            TransactionAddResponse? addResponse = await addResponseMessage.Content.ReadFromJsonAsync<TransactionAddResponse>();

            Guid id = addResponse?.Id ?? Guid.NewGuid();

            TransactionUpdateByIdRequest request = new TransactionUpdateByIdRequest(id, newName, newAmount, newCategoryId, newTypeId, newSourceId, dateTimeNow, DateTime.Now);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            string url = $"{TransactionIntegrationTestConstant.UpdateEndpointUrl}/{id}";

            // Act
            HttpResponseMessage? response = await _httpClient!.PutAsync(url, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}