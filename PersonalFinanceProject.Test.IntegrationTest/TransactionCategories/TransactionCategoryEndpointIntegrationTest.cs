using Microsoft.AspNetCore.Mvc.Testing;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Responses;
using PersonalFinanceProject.Web.Api;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PersonalFinanceProject.Test.IntegrationTest.TransactionCategories
{
    [TestClass]
    internal class TransactionCategoryEndpointIntegrationTest
    {
        private HttpClient? _httpClient;

        [TestInitialize]
        public void Setup()
        {
            WebApplicationFactory<Program> applicationFactory = new WebApplicationFactory<Program>();
            _httpClient = applicationFactory.CreateClient();
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

            // Act
            HttpResponseMessage? response = await _httpClient!.DeleteAsync(url);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public async Task ShouldGetById(int id)
        {
            // Arrange
            string url = $"{TransactionCategoryIntegrationTestConstant.GetEndpointUrl}/{id}";

            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(url);
            string responseContent = await response.Content.ReadAsStringAsync();

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