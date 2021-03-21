using System.ComponentModel.DataAnnotations;

namespace Calculator.Types
{
    public class CalculateModel
    {
        [Required]
        public double FirstNumber { get; set; }
        [Required]
        public double SecondNumber { get; set; }
        public OperationEnum Operation { get; set; }
        public double Result { get; set; }
    }
}