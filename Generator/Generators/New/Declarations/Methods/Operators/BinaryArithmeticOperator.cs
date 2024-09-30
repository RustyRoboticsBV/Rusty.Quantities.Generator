using System.Xml.Linq;

namespace Generators.New
{
    /// <summary>
    /// An binary arithmetic operator generator.
    /// </summary>
    public class BinaryArithmeticOperator : ArithmeticOperator
    {
        /* Constructors. */
        public BinaryArithmeticOperator(ReturnType returnType, string name, Parameter a, Parameter b)
            : base(returnType.Type.Name, name, new ParameterList(a, b), GetImpl(returnType, a, name, b)) { }

        /* Public methods. */
        public static string Generate(ReturnType returnType, string name, Parameter a, Parameter b)
        {
            return new BinaryArithmeticOperator(returnType, name, a, b).Generate();
        }

        /* Private methods. */
        private static string GetImpl(ReturnType returnType, Parameter a, string op, Parameter b)
        {
            return returnType.Generate(Numerics.CoreType,
                $"{a.Type.CastTo("a", Numerics.CoreType)} {op} {b.Type.CastTo("b", Numerics.CoreType)}");
        }
    }
}