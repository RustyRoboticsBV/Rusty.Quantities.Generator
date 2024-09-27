namespace Generators.New
{
    /// <summary>
    /// An binary arithmetic operator generator.
    /// </summary>
    public class BinaryArithmeticOperator : ArithmeticOperator
    {
        /* Constructors. */
        public BinaryArithmeticOperator(string returnType, string name, Parameter a, Parameter b, string implementation)
            : base(returnType, name, new ParameterList(a, b), implementation) { }

        /* Public methods. */
        public static string Generate(string returnType, string name, Parameter a, Parameter b, string implementation)
        {
            return new BinaryArithmeticOperator(returnType, name, a, b, implementation).Generate();
        }
    }
}