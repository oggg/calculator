using Calculator.Services.Interfaces;
using Calculator.Types;

namespace Calculator.Services.Implementations
{
    public class SubtractionCalculationService : ICalculateService
    {
        public OperationEnum Operation => OperationEnum.Subtraction;

        public double Calculate(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}
