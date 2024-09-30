namespace Generators
{
    /// <summary>
    /// An unary arithmetic operator generator.
    /// </summary>
    public class UnaryArithmeticOperator : ArithmeticOperator
    {
        /* Constructors. */
        public UnaryArithmeticOperator(ReturnType returnType, string name, Parameter parameter)
            : base(returnType.Type.Name, name, new ParameterList(parameter), GetImpl(returnType, name, parameter)) { }

        /* Public methods. */
        public static string Generate(ReturnType returnType, string name, Parameter parameter)
        {
            return new UnaryArithmeticOperator(returnType, name, parameter).Generate();
        }

        /* Private methods. */
        private static string GetImpl(ReturnType returnType, string op, Parameter parameter)
        {
            return returnType.Generate(Numerics.CoreType, $"{op}{parameter.Type.CastTo(parameter.Name, Numerics.CoreType)}");
        }
    }
}