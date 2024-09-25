

namespace Generators.Generic
{
    /// <summary>
    /// A generator for operators.
    /// </summary>
    public class OperatorGenerator : Generator
    {
        public static string Generate(string prefix, string returnType, string name, string parameters, string implementation, string summary = null)
        {
            if (prefix == null)
                prefix = "";
            else
                prefix = $" {prefix}";

            if (returnType == null)
                returnType = "";
            else
                returnType = $" {returnType}";

            string code = "";
            if (summary != null)
                code += "\n" + SummaryGenerator.Generate(summary) + "\n";
            code += Indent + $"public static{prefix}{returnType} operator {name}({parameters})"
                + "\n" + Indent + "{"
                + "\n" + MethodIndent + implementation.Replace("\n", "\n" + MethodIndent)
                + "\n" + Indent + "}";
            return code;
        }
    }
}
