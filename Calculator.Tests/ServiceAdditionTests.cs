using Calculator.Services.Implementations;
using Calculator.Services.Interfaces;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class ServiceAdditionTests
    {
        private ICalculateService _calculateService;

        [SetUp]
        public void Setup()
        {
            _calculateService = new AdditionCalculationService();
        }

        [TestCase(5, 5)]
        public void CalculateAddition(double firstNumber, double secondNumber)
        {
            var result = _calculateService.Calculate(firstNumber, secondNumber);

            Assert.AreEqual(10, result);
        }
    }
}
