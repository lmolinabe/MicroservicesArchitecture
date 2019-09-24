
namespace Math.API.Model
{
    enum OperationType
    {
        Addition = 1,
        Subtraction = 2,
        Multiplication = 3,
        Division = 4
    }

    public class MathOperation
    {
        public int OperationType { get; set; }

        public int Value1 { get; set; }

        public int Value2 { get; set; }
    }
}
