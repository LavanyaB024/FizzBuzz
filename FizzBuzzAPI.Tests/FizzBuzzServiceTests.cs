using FizzBuzzAPI;
using FizzBuzzAPI.Constants;
using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzApi.Tests
{
    public class FizzBuzzServiceTests
    {
        private Mock<IFizzBuzzProcessor> _mockProcessor;
        private Mock<IFizzBuzzValidator> _mockValidator;
        private FizzBuzzService _fizzBuzzService;

        [SetUp]
        public void Setup()
        {
            _mockProcessor = new Mock<IFizzBuzzProcessor>();
            _mockValidator = new Mock<IFizzBuzzValidator>();
            _fizzBuzzService = new FizzBuzzService(_mockProcessor.Object, _mockValidator.Object);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnFizz_ForMultipleOf3()
        {
            var values = new string[] { "3" };
            _mockValidator.Setup(v => v.TryValidate("3", out It.Ref<int>.IsAny)).Returns(true).Callback(new TryValidateCallback((string s, out int i) => i = 3));
            _mockProcessor.Setup(p => p.GetFizzBuzzValue(3)).Returns("Fizz");

            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("Fizz", result.First().Result);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnBuzz_ForMultipleOf5()
        {
            var values = new string[] { "5" };
            _mockValidator.Setup(v => v.TryValidate("5", out It.Ref<int>.IsAny)).Returns(true).Callback(new TryValidateCallback((string s, out int i) => i = 5));
            _mockProcessor.Setup(p => p.GetFizzBuzzValue(5)).Returns("Buzz");
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("Buzz", result.First().Result);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnFizzBuzz_ForMultipleOf15()
        {
            var values = new string[] { "15" };
            _mockValidator.Setup(v => v.TryValidate("15", out It.Ref<int>.IsAny)).Returns(true).Callback(new TryValidateCallback((string s, out int i) => i = 15));
            _mockProcessor.Setup(p => p.GetFizzBuzzValue(15)).Returns("FizzBuzz");
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("FizzBuzz", result.First().Result);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnOriginalValue_ForNonMultiplesOf3Or5()
        {
            var values = new string[] { "7" };
            _mockValidator.Setup(v => v.TryValidate("7", out It.Ref<int>.IsAny)).Returns(true).Callback(new TryValidateCallback((string s, out int i) => i = 7));
            _mockProcessor.Setup(p => p.GetFizzBuzzValue(7)).Returns("7");

            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("7", result.First().Result);
            CollectionAssert.AreEqual(new List<string> { "Divided 7 by 3", "Divided 7 by 5" }, result.First().Operation);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnInvalidItem_ForNonNumericValues()
        {
            var values = new string[] { "A" };
            _mockValidator.Setup(v => v.TryValidate("A", out It.Ref<int>.IsAny)).Returns(false);

            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("Invalid item", result.First().Result);
            CollectionAssert.AreEqual(new List<string> { "Invalid item" }, result.First().Operation);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnInvalidItem_ForEmptyArray()
        {
            var values = new string[] { };
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("Invalid item", result.First().Result);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ValidValues_ReturnsExpectedResults()
        {
            // Arrange
            var values = new string[] { "3", "5", "15", "7" };

            _mockValidator.Setup(v => v.TryValidate("3", out It.Ref<int>.IsAny)).Returns(true).Callback(new TryValidateCallback((string s, out int i) => i = 3));
            _mockValidator.Setup(v => v.TryValidate("5", out It.Ref<int>.IsAny)).Returns(true).Callback(new TryValidateCallback((string s, out int i) => i = 5));
            _mockValidator.Setup(v => v.TryValidate("15", out It.Ref<int>.IsAny)).Returns(true).Callback(new TryValidateCallback((string s, out int i) => i = 15));
            _mockValidator.Setup(v => v.TryValidate("7", out It.Ref<int>.IsAny)).Returns(true).Callback(new TryValidateCallback((string s, out int i) => i = 7));

            _mockProcessor.Setup(p => p.GetFizzBuzzValue(3)).Returns("Fizz");
            _mockProcessor.Setup(p => p.GetFizzBuzzValue(5)).Returns("Buzz");
            _mockProcessor.Setup(p => p.GetFizzBuzzValue(15)).Returns("FizzBuzz");
            _mockProcessor.Setup(p => p.GetFizzBuzzValue(7)).Returns("7");

            // Act
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            // Assert
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("Fizz", result[0].Result);
            Assert.AreEqual("Buzz", result[1].Result);
            Assert.AreEqual("FizzBuzz", result[2].Result);
            Assert.AreEqual("7", result[3].Result);
        }

        [Test]
        public void GetFizzBuzzListOfValues_InvalidValue_ReturnsError()
        {
            // Arrange
            var values = new string[] { "invalid" };

            _mockValidator.Setup(v => v.TryValidate("invalid", out It.Ref<int>.IsAny)).Returns(false);

            // Act
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Invalid item", result[0].Result);
            Assert.AreEqual(FizzBuzzConstants.InvalidItem, result[0].Operation[0]);
        }

        delegate void TryValidateCallback(string s, out int i);

    }
}
