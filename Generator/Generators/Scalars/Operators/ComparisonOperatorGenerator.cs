

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for casting operators.
    /// </summary>
    public class ComparisonOperatorGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string type1, string type2, string opName, string term1, string term2, string summary = null)
        {
            return OperatorGenerator.Generate(
                null,
                "bool",
                opName,
                $"{type1} a, {type2} b",
                $"return {term1} {opName} {term2};",
                summary);
        }
    }
}
