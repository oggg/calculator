using Calculator.Types;

namespace Calculator.Services.Interfaces
{
    public interface ICalculateService
    {
        OperationEnum Operation { get;  }
        double Calculate(double firstNumber, double secondNumber);
    }
}
