namespace Generators.New
{
    /// <summary>
    /// An comparison operator generator.
    /// </summary>
    public class ComparisonOperator : Operator
    {
        /* Constructors. */
        public ComparisonOperator(string name, Parameter a, Parameter b)
            : base("static", "bool", name, new(a, b), GetImpl(a, name, b)) { }

        /* Public methods. */
        public static string Generate(string name, Parameter a, Parameter b)
        {
            return new ComparisonOperator(name, a, b).Generate();
        }

        private static string GetImpl(Parameter a, string op, Parameter b)
        {
            if (a is ScalarParameter && b is ScalarParameter)
                return $"return {a.Type.CastTo(a.Name, Numerics.CoreType)} {op} {b.Type.CastTo(b.Name, Numerics.CoreType)};";
            return "";
        }
    }
}