

namespace Generators
{
    /// <summary>
    /// A generator for blocks of casting operators.
    /// </summary>
    public class ComparisonOperatorGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string className)
        {
            return Generate(className, "==")
                + "\n" + Generate(className, "!=")
                + "\n" + Generate(className, ">")
                + "\n" + Generate(className, "<")
                + "\n" + Generate(className, ">=")
                + "\n" + Generate(className, "<=");
        }

        /* Private methods. */
        private static string Generate(string className, string operatorName)
        {
            return Indent + $"public static bool operator {operatorName}({className} a, {className} b) => a.value {operatorName} b.value;";
        }
    }
}
