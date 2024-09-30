namespace Generators
{
    /// <summary>
    /// An arithmetic operator generator.
    /// </summary>
    public class ArithmeticOperator : Operator
    {
        /* Constructors. */
        public ArithmeticOperator(string returnType, string name, ParameterList parameters, string implementation)
            : base("static", returnType, name, parameters, implementation) { }

        /* Public methods. */
        public static string Generate(string returnType, string name, ParameterList parameters, string implementation)
        {
            return new ArithmeticOperator(returnType, name, parameters, implementation).Generate();
        }
    }
}