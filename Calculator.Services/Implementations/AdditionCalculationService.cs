using Calculator.Services.Interfaces;
using Calculator.Types;


namespace Calculator.Services.Implementations
{
    public class AdditionCalculationService : ICalculateService
    {
        public OperationEnum Operation => OperationEnum.Addition;

        public double Calculate(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
