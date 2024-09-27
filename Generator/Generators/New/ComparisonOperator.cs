namespace Generators.New
{
    /// <summary>
    /// An comparison operator generator.
    /// </summary>
    public class ComparisonOperator : Operator
    {
        /* Constructors. */
        public ComparisonOperator(string name, Parameter a, Parameter b, string implementation)
            : base("static", "bool", name, new(a, b), implementation) { }

        /* Public methods. */
        public static string Generate(string name, Parameter a, Parameter b, string implementation)
        {
            return new ComparisonOperator(name, a, b, implementation).Generate();
        }
    }
}