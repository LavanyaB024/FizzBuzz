using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzApi.Tests
{
    public class FizzBuzzControllerTests
    {
        private Mock<IFizzBuzzServiceFactory> _mockServiceFactory;
        private Mock<IFizzBuzzService> _mockFizzBuzzService;
        private FizzBuzzController _controller;

        [SetUp]
        public void Setup()
        {
            _mockServiceFactory = new Mock<IFizzBuzzServiceFactory>();
            _mockFizzBuzzService = new Mock<IFizzBuzzService>();
            _mockServiceFactory.Setup(f => f.CreateService()).Returns(_mockFizzBuzzService.Object);
            _controller = new FizzBuzzController(_mockServiceFactory.Object);
        }

        [Test]
        public void Post_ShouldReturnOkResultWithFizzBuzzResponses()
        {
            // Arrange
            var values = new[] { "3", "5", "15", "7" };
            var responseList = new List<FizzBuzzResponse>
            {
                new FizzBuzzResponse { Result = "Fizz" },
                new FizzBuzzResponse { Result = "Buzz" },
                new FizzBuzzResponse { Result = "FizzBuzz" },
                new FizzBuzzResponse { Result = "7", Operation = new List<string> { "Divided 7 by 3", "Divided 7 by 5" } }
            };
            _mockFizzBuzzService.Setup(s => s.GetFizzBuzzListOfValues(values)).Returns(responseList);

            // Act
            var result = _controller.Post(values) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var returnedList = result.Value as List<FizzBuzzResponse>;
            Assert.AreEqual(4, returnedList.Count);
            Assert.AreEqual("Fizz", returnedList[0].Result);
            Assert.AreEqual("Buzz", returnedList[1].Result);
            Assert.AreEqual("FizzBuzz", returnedList[2].Result);
            Assert.AreEqual("7", returnedList[3].Result);
            CollectionAssert.AreEqual(new List<string> { "Divided 7 by 3", "Divided 7 by 5" }, returnedList[3].Operation);
        }

        [Test]
        public void Post_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var values = new[] { "3", "5", "15", "7" };
           // _mockFizzBuzzService.Setup(s => s.GetFizzBuzzListOfValues(values)).Throws(new Exception());
            _mockFizzBuzzService.Setup(s => s.GetFizzBuzzListOfValues(It.IsAny<string[]>())).Throws(new Exception());
            // Act
            var result = _controller.Post(values) as ObjectResult;
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
