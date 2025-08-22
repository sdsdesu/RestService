using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using RestService.Controllers;
using RestService.Services;
using Moq;

namespace RestIntegrationTest
{
    [TestClass]
    public sealed class SterrebeeldTest
    {
        HttpClient _client = null!;
        [TestInitialize]
        public void Initialize()
        {
            var factory = new WebApplicationFactory<SterrebeeldControler>();
            _client = factory.CreateDefaultClient();
        }
        [TestMethod]
        public async Task VerwerkRamDatum()
        {
            var response = await _client.GetAsync("sterrebeelden/21-3");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
