using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Responses;
using PersonalFinanceProject.Test.IntegrationTest.Factories;
using PersonalFinanceProject.Web.Api;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PersonalFinanceProject.Test.IntegrationTest.TransactionCategories
{
    [TestClass]
    internal class TransactionCategoryEndpointIntegrationTest
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
        [DataRow("TestCategory1")]
        public async Task ShouldAdd(string name)
        {
            // Arrange
            TransactionCategoryAddRequest request = new TransactionCategoryAddRequest(name);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage? response = await _httpClient!.PostAsync(TransactionCategoryIntegrationTestConstant.AddEndpointUrl, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public async Task ShouldDeleteById(int id)
        {
            // Arrange
            string url = $"{TransactionCategoryIntegrationTestConstant.DeleteEndpointUrl}/{id}";
            TransactionCategoryDeleteByIdRequest request = new TransactionCategoryDeleteByIdRequest(id);

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
        [DataRow(1, "TestCategory1")]
        public async Task ShouldGetById(int id, string name)
        {
            // Arrange
            string url = $"{TransactionCategoryIntegrationTestConstant.GetEndpointUrl}/{id}";

            TransactionCategoryAddRequest request = new TransactionCategoryAddRequest(name);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            await _httpClient!.PostAsync(TransactionCategoryIntegrationTestConstant.AddEndpointUrl, content);

            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(url);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);

            TransactionCategoryGetByIdResponse? transactionCategory = await response.Content.ReadFromJsonAsync<TransactionCategoryGetByIdResponse>();
            Assert.IsNotNull(transactionCategory);
            Assert.IsNotNull(transactionCategory.TransactionCategory);
            Assert.AreEqual(id, transactionCategory.TransactionCategory.Id);
            Assert.IsNotNull(transactionCategory.TransactionCategory.Name);
        }

        [TestMethod]
        public async Task ShouldGetList()
        {
            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(TransactionCategoryIntegrationTestConstant.GetListEndpointUrl);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        [DataRow(1, "TestCategory2")]
        public async Task ShouldUpdate(int id, string name)
        {
            // Arrange
            TransactionCategoryUpdateRequest request = new TransactionCategoryUpdateRequest(id, name);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage? response = await _httpClient!.PutAsync(TransactionCategoryIntegrationTestConstant.UpdateEndpointUrl, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}