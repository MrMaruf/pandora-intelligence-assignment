using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using pandora_intelligence_assignment.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandora_intelligence_assignment.Controllers.Tests
{
    [TestClass()]
    public class CarLookupControllerTests
    {

        [TestMethod()]
        public async Task GetReturnsStringOnNoArguments_Test()
        {
            var mockLogger = new Mock<ILogger<CarLookupController>>();
            CarLookupController _controller = new CarLookupController(mockLogger.Object);

            var response = await _controller.Get();
            var content = response.Content;

            Assert.IsNotNull(content);
            Assert.AreEqual(content, "No arguments provided");

        }
        [DataTestMethod]
        [DataRow("001TJ", null, null)]
        public async Task GetReturnsObjectOnCorrectArguments_Test(string licensePlate, string? brand, string? type)
        {
            var mockLogger = new Mock<ILogger<CarLookupController>>();
            CarLookupController _controller = new CarLookupController(mockLogger.Object);
            string expectedContent = "\"kenteken\":\"0001TJ\"";

            var response = await _controller.Get(licensePlate, brand, type);
            var content = response.Content;

            Assert.IsNotNull(content);
            Assert.IsTrue(content.Contains(expectedContent));

        }
        [TestMethod()]
        public async Task GetReturnsErrorOnWrongArguments_Test()
        {
            var mockLogger = new Mock<ILogger<CarLookupController>>();
            CarLookupController _controller = new CarLookupController(mockLogger.Object);
            string wrongLicensePlateArgument = "0001TJ&xxx=Where=1111";
            string expectedErrorState = "\"error\" : true";
            string expectedErrorMessage = "\"message\" : \"Unrecognized arguments [xxx]";

            var response = await _controller.Get(wrongLicensePlateArgument);
            var content = response.Content;

            Assert.IsNotNull(content);
            Assert.IsTrue(content.Contains(expectedErrorState));
            Assert.IsTrue(content.Contains(expectedErrorMessage));

        }
    }
}