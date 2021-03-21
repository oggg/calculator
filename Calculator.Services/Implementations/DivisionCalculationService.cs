using Calculator.Services.Interfaces;
using Calculator.Types;

namespace Calculator.Services.Implementations
{
    public class DivisionCalculationService : ICalculateService
    {
        public OperationEnum Operation => OperationEnum.Division;

        public double Calculate(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}
