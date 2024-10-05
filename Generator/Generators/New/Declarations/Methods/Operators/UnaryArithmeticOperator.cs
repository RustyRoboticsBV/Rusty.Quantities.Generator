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

        /* Private methods. */
        private static string GetImpl(ReturnType returnType, string op, Parameter parameter)
        {
            if (op == "++")
                return returnType.Generate(Numerics.CoreType, $"{parameter.Type.CastTo(parameter.Name, Numerics.CoreType)} + 1");
            if (op == "--")
                return returnType.Generate(Numerics.CoreType, $"{parameter.Type.CastTo(parameter.Name, Numerics.CoreType)} - 1");
            else
                return returnType.Generate(Numerics.CoreType, $"{op}{parameter.Type.CastTo(parameter.Name, Numerics.CoreType)}");
        }
    }
}