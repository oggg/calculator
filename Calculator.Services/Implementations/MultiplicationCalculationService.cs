using Calculator.Services.Interfaces;
using Calculator.Types;

namespace Calculator.Services.Implementations
{
    public class MultiplicationCalculationService : ICalculateService
    {
        public OperationEnum Operation => OperationEnum.Multiplication;

        public double Calculate(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}
