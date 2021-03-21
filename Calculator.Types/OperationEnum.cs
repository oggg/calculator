using System.ComponentModel;

namespace Calculator.Types
{
    public enum OperationEnum
    {
        [Description("+")]
        Addition,
        [Description("-")]
        Subtraction,
        [Description("*")]
        Multiplication,
        [Description("/")]
        Division
    }
}
