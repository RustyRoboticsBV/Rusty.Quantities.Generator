namespace Generators.New
{
    /// <summary>
    /// An unary arithmetic operator generator.
    /// </summary>
    public class UnaryArithmeticOperator : ArithmeticOperator
    {
        /* Constructors. */
        public UnaryArithmeticOperator(ReturnType returnType, string name, Parameter parameter)
            : base(returnType.Type.Name, name, new ParameterList(parameter),
                  returnType.Generate(Numerics.CoreType, parameter.UnaryOperator(name))) { }

        /* Public methods. */
        public static string Generate(ReturnType returnType, string name, Parameter parameter)
        {
            return new UnaryArithmeticOperator(returnType, name, parameter).Generate();
        }
    }
}