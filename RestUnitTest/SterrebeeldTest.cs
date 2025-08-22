using RestService.Controllers;
using RestService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;



namespace RestUnitTest
{
    [TestClass]
    public class SterebeeldControlerTest
    {
        SterrebeeldControler controler = null!;
        Mock<IDatumLezerService> mockService = null!;
        string Steenbokdatum= null!;
        string Schorpiendatum = null!;
       // string OngeeldigeDatum = null!;

        [TestInitialize]
        public void Initialize()
        {
            mockService = new Mock<IDatumLezerService>();
            controler = new SterrebeeldControler(mockService.Object);
            Steenbokdatum = "Steenbok";
            Schorpiendatum = "Schorpioen";
        }

        [TestMethod]
        public async Task TestGetSteenbok()
        {
            mockService.Setup(s => s.sterrebeeldNaam(22, 12)).ReturnsAsync(Steenbokdatum);
            var result = await controler.FindById(22, 12);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(Steenbokdatum, okResult?.Value);
        }
        [TestMethod]
        public async Task TestGetSchorpioen()
        {
            mockService.Setup(s => s.sterrebeeldNaam(22, 11)).ReturnsAsync(Schorpiendatum);
            var result = await controler.FindById(22, 11);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(Schorpiendatum, okResult?.Value);
        }
        [TestMethod]
        public async Task TestGetOngeeldigeDatum()
        {
            mockService.Setup(s => s.sterrebeeldNaam(32, 13)).ReturnsAsync(string.Empty);
            var result = await controler.FindById(32, 13);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


    }
}
