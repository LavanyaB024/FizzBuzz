using FizzBuzzAPI;
using NUnit.Framework;

namespace FizzBuzzAPI.Tests
{
    [TestFixture]
    public class FizzBuzzProcessorTests
    {
        private FizzBuzzProcessor _processor;

        [SetUp]
        public void Setup()
        {
            _processor = new FizzBuzzProcessor();
        }

        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(7, "7")]
        public void GetFizzBuzzValue_ValidValues_ReturnsExpectedResults(int value, string expected)
        {
            // Act
            var result = _processor.GetFizzBuzzValue(value);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
