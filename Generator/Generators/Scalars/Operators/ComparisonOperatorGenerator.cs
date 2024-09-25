

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
            string code = "";
            if (summary != null)
                code += "\n" + SummaryGenerator.Generate(summary) + "\n";
            code += Indent + $"public static bool operator {operatorName}({type1} a, {type2} b)"
                + "\n" + Indent + "{"
                + "\n" + MethodIndent + $"return {term1} {operatorName} {term2};"
                + "\n" + Indent + "}";
            return code;
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
