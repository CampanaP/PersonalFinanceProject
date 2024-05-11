using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;
using PersonalFinanceProject.Communication.Message.TransactionType.Responses;
using PersonalFinanceProject.Test.IntegrationTest.Factories;
using PersonalFinanceProject.Test.IntegrationTest.TransactionCategories;
using PersonalFinanceProject.Web.Api;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PersonalFinanceProject.Test.IntegrationTest.TransactionTypes
{
    [TestClass]
    internal class TransactionTypeEndpointIntegrationTest
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
        [DataRow("TransactionType1")]
        public async Task ShouldAdd(string name)
        {
            // Arrange
            TransactionTypeAddRequest request = new TransactionTypeAddRequest(name);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage? response = await _httpClient!.PostAsync(TransactionTypeIntegrationTestConstant.AddEndpointUrl, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public async Task ShouldDeleteById(int id)
        {
            // Arrange
            string url = $"{TransactionTypeIntegrationTestConstant.DeleteEndpointUrl}/{id}";
            TransactionTypeDeleteByIdRequest request = new TransactionTypeDeleteByIdRequest(id);

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
        [DataRow(1, "TransactionType1")]
        public async Task ShouldGetById(int id, string name)
        {
            // Arrange
            string url = $"{TransactionTypeIntegrationTestConstant.GetEndpointUrl}/{id}";

            TransactionTypeAddRequest request = new TransactionTypeAddRequest(name);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            await _httpClient!.PostAsync(TransactionTypeIntegrationTestConstant.AddEndpointUrl, content);

            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(url);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);

            TransactionTypeGetByIdResponse? transactionCategory = await response.Content.ReadFromJsonAsync<TransactionTypeGetByIdResponse>();
            Assert.IsNotNull(transactionCategory);
            Assert.IsNotNull(transactionCategory.TransactionType);
            Assert.AreEqual(id, transactionCategory.TransactionType.Id);
            Assert.IsNotNull(transactionCategory.TransactionType.Name);
        }

        [TestMethod]
        public async Task ShouldGetList()
        {
            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(TransactionTypeIntegrationTestConstant.GetListEndpointUrl);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        [DataRow(1, "TransactionType2")]
        public async Task ShouldUpdateById(int id, string name)
        {
            // Arrange
            TransactionTypeUpdateByIdRequest request = new TransactionTypeUpdateByIdRequest(id, name);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            string url = $"{TransactionTypeIntegrationTestConstant.UpdateEndpointUrl}/{id}";

            // Act
            HttpResponseMessage? response = await _httpClient!.PutAsync(url, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}