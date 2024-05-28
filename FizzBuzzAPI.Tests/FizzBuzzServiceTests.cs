using FizzBuzzAPI;
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
        private FizzBuzzService _fizzBuzzService;

        [SetUp]
        public void Setup()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnFizz_ForMultipleOf3()
        {
            var values = new string[] { "3" };
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("Fizz", result.First().Result);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnBuzz_ForMultipleOf5()
        {
            var values = new string[] { "5" };
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("Buzz", result.First().Result);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnFizzBuzz_ForMultipleOf15()
        {
            var values = new string[] { "15" };
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("FizzBuzz", result.First().Result);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnOriginalValue_ForNonMultiplesOf3Or5()
        {
            var values = new string[] { "7" };
            var result = _fizzBuzzService.GetFizzBuzzListOfValues(values);

            Assert.AreEqual("7", result.First().Result);
            CollectionAssert.AreEqual(new List<string> { "Divided 7 by 3", "Divided 7 by 5" }, result.First().Operation);
        }

        [Test]
        public void GetFizzBuzzListOfValues_ShouldReturnInvalidItem_ForNonNumericValues()
        {
            var values = new string[] { "A" };
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
    }
}
