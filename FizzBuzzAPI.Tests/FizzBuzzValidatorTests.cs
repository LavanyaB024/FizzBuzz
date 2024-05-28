using FizzBuzzAPI;
using NUnit.Framework;

namespace FizzBuzzAPI.Tests
{
    [TestFixture]
    public class FizzBuzzValidatorTests
    {
        private FizzBuzzValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new FizzBuzzValidator();
        }

        [Test]
        [TestCase("3", true)]
        [TestCase("invalid", false)]
        [TestCase("", false)]
        public void TryValidate_Values_ReturnsExpectedResults(string value, bool expected)
        {
            // Act
            var result = _validator.TryValidate(value, out int validatedValue);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
