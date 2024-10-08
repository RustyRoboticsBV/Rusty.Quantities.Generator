namespace Generators
{
    /// <summary>
    /// An arithmetic operator generator.
    /// </summary>
    public class ArithmeticOperator : Operator
    {
        /* Constructors. */
        public ArithmeticOperator(Type returnType, string name, ParameterList parameters, string implementation)
            : base("static", returnType, name, parameters, implementation) { }
    }
}