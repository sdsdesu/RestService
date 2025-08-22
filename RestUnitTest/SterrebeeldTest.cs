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
        
        // string OngeeldigeDatum = null!;

        [TestInitialize]
        public void Initialize()
        {
            mockService = new Mock<IDatumLezerService>();
            controler = new SterrebeeldControler(mockService.Object);
            
        }

        [TestMethod]
        [DataRow(21, 3, "Ram")]
        [DataRow(20, 4, "Stier")]
        [DataRow(21, 5, "Tweelingen")]
        
        public async Task TestOkData(int dag, int maand, string sterebeeld)
        {
            mockService.Setup(s => s.sterrebeeldNaam(dag, maand)).ReturnsAsync(sterebeeld);
            var result = await controler.FindById(dag, maand);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(sterebeeld, okResult?.Value);
        }
        
        [TestMethod]
        [DataRow(32, 13, "")]
        [DataRow(0, 0, "")]
        public async Task TestGetOngeeldigeData(int dag, int maand, string sterebeeld)
        {
            mockService.Setup(s => s.sterrebeeldNaam(dag, maand)).ReturnsAsync(sterebeeld);
            var result = await controler.FindById(dag, maand);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


    }
}
