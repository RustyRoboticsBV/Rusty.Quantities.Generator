

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for blocks of casting operators.
    /// </summary>
    public class ComparisonOperatorGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string type1, string type2, string operatorName, string term1, string term2, string summary = null)
        {
            return OperatorGenerator.Generate(
                null,
                "bool",
                operatorName,
                $"{type1} a, {type2} b",
                $"return {term1} {operatorName} {term2};",
                summary);
        }

        public static string Generate(string className, string operatorName)
        {
            return Generate(className, className, operatorName, "a.value", "b.value");
        }

        public static string Generate(string className)
        {
            return Generate(className, "==")
                + "\n" + Generate(className, "!=")
                + "\n" + Generate(className, ">")
                + "\n" + Generate(className, "<")
                + "\n" + Generate(className, ">=")
                + "\n" + Generate(className, "<=");
        }
    }
}
