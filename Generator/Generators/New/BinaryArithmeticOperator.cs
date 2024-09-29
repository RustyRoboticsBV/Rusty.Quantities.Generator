namespace Generators.New
{
    /// <summary>
    /// An binary arithmetic operator generator.
    /// </summary>
    public class BinaryArithmeticOperator : ArithmeticOperator
    {
        /* Constructors. */
        public BinaryArithmeticOperator(ReturnType returnType, string name, Parameter a, Parameter b)
            : base(returnType.Type.Name, name, new ParameterList(a, b), a.BinaryOperator(name, b)) { }

        /* Public methods. */
        public static string Generate(ReturnType returnType, string name, Parameter a, Parameter b)
        {
            return new BinaryArithmeticOperator(returnType, name, a, b).Generate();
        }
    }
}