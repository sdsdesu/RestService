using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using RestService.Controllers;
using RestService.Services;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.DependencyInjection;


namespace RestIntegrationTest
{
    [TestClass]
    public sealed class SterrebeeldTest2
    {
        HttpClient client = null!;
        Mock<IDatumLezerService> mockService = null!;

        [TestInitialize]
        public void Initialize()
        {
            mockService = new Mock<IDatumLezerService>();
            var service = mockService.Object;
            var factory = new WebApplicationFactory<SterrebeeldControler>();
            client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped<IDatumLezerService>(_ => service);
                });
            }).CreateClient();
        }
        [TestMethod]
        public async Task VerwerkRamDatum()
        {
            mockService.Setup(Mock => Mock.sterrebeeldNaam(21, 3)).ReturnsAsync("Ram");
            var response = await client.GetAsync("sterrebeelden/21-3");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            mockService.Verify(mock => mock.sterrebeeldNaam(21, 3));

        }
    }
}
