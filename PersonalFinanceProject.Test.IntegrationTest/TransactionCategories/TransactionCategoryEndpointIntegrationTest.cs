using Microsoft.AspNetCore.Mvc.Testing;
using PersonalFinanceProject.Web.Api;

namespace PersonalFinanceProject.Test.IntegrationTest.TransactionCategories
{
    [TestClass]
    internal class TransactionCategoryEndpointIntegrationTest
    {
        [TestMethod]
        public async Task ShouldGetListTransactionCategory()
        {
            await using var application = new WebApplicationFactory<Program>();

            using var client = application.CreateClient();

            var response = await client.GetAsync("/api/transaction-category/get/list");

            response.EnsureSuccessStatusCode();
        }
    }
}