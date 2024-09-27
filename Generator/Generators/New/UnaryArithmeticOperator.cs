namespace Generators.New
{
    /// <summary>
    /// An unary arithmetic operator generator.
    /// </summary>
    public class UnaryArithmeticOperator : ArithmeticOperator
    {
        /* Constructors. */
        public UnaryArithmeticOperator(string returnType, string name, Parameter parameter, string implementation)
            : base(returnType, name, new ParameterList(parameter), implementation) { }

        /* Public methods. */
        public static string Generate(string returnType, string name, Parameter parameter, string implementation)
        {
            return new UnaryArithmeticOperator(returnType, name, parameter, implementation).Generate();
        }
    }
}