using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Wallet.DbContexts;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;
using PersonalFinanceProject.Communication.Message.RevenueSource.Responses;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;
using PersonalFinanceProject.Test.IntegrationTest.Factories;
using PersonalFinanceProject.Web.Api;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PersonalFinanceProject.Test.IntegrationTest.RevenueSources
{
    [TestClass]
    internal class RevenueSourceEndpointIntegrationTest
    {
        private CustomWebApplicationFactory<Program>? _applicationFactory;
        private WalletDbContext? _dbContext;
        private HttpClient? _httpClient;

        [TestInitialize]
        public async Task Setup()
        {
            _applicationFactory = new CustomWebApplicationFactory<Program>();

            _dbContext = _applicationFactory.Services.GetRequiredService<WalletDbContext>();
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
        [DataRow("RevenueSource1")]
        public async Task ShouldAdd(string name)
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            RevenueSourceAddRequest request = new RevenueSourceAddRequest(name, userId);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage? response = await _httpClient!.PostAsync(RevenueSourceIntegrationTestConstant.AddEndpointUrl, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task ShouldDeleteById()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string url = $"{RevenueSourceIntegrationTestConstant.DeleteEndpointUrl}/{id}";
            RevenueSourceDeleteByIdRequest request = new RevenueSourceDeleteByIdRequest(id);

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
        [DataRow("RevenueSource1")]
        public async Task ShouldGetById(string name)
        {
            // Arrange
            Guid id = Guid.Empty;
            Guid userId = Guid.NewGuid();

            RevenueSourceAddRequest request = new RevenueSourceAddRequest(name, userId);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            await _httpClient!.PostAsync(RevenueSourceIntegrationTestConstant.AddEndpointUrl, content);
            HttpResponseMessage? getListResponse = await _httpClient!.GetAsync(RevenueSourceIntegrationTestConstant.GetListEndpointUrl);
            RevenueSourceGetListResponse? revenueSources = await getListResponse.Content.ReadFromJsonAsync<RevenueSourceGetListResponse>();
            if (revenueSources is not null && revenueSources.RevenueSources is not null && revenueSources.RevenueSources.Any())
            {
                id = revenueSources.RevenueSources.First().Id;
            }

            string url = $"{RevenueSourceIntegrationTestConstant.GetEndpointUrl}/{id}";

            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(url);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);

            RevenueSourceGetByIdResponse? revenueSource = await response.Content.ReadFromJsonAsync<RevenueSourceGetByIdResponse>();
            Assert.IsNotNull(revenueSource);
            Assert.IsNotNull(revenueSource.RevenueSource);
            Assert.AreEqual(id, revenueSource.RevenueSource.Id);
            Assert.AreEqual(name, revenueSource.RevenueSource.Name);
            Assert.AreEqual(userId, revenueSource.RevenueSource.UserId);
        }

        [TestMethod]
        public async Task ShouldGetList()
        {
            // Act
            HttpResponseMessage? response = await _httpClient!.GetAsync(RevenueSourceIntegrationTestConstant.GetListEndpointUrl);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        [DataRow("RevenueSource", "RevenueSource2")]
        public async Task ShouldUpdate(string name, string newName)
        {
            // Arrange
            Guid id = Guid.Empty;
            Guid userId = Guid.NewGuid();

            RevenueSourceAddRequest addRequest = new RevenueSourceAddRequest(name, userId);
            HttpContent addContent = new StringContent(JsonSerializer.Serialize(addRequest), Encoding.UTF8, "application/json");
            await _httpClient!.PostAsync(RevenueSourceIntegrationTestConstant.AddEndpointUrl, addContent);
            HttpResponseMessage? getListResponse = await _httpClient!.GetAsync(RevenueSourceIntegrationTestConstant.GetListEndpointUrl);
            RevenueSourceGetListResponse? revenueSources = await getListResponse.Content.ReadFromJsonAsync<RevenueSourceGetListResponse>();
            if (revenueSources is not null && revenueSources.RevenueSources is not null && revenueSources.RevenueSources.Any())
            {
                id = revenueSources.RevenueSources.First().Id;
            }

            Guid newUserId = Guid.NewGuid();

            RevenueSourceUpdateRequest request = new RevenueSourceUpdateRequest(id, newName, newUserId);
            HttpContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage? response = await _httpClient!.PutAsync(RevenueSourceIntegrationTestConstant.UpdateEndpointUrl, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}