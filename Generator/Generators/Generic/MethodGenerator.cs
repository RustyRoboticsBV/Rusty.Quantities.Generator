

namespace Generators.Generic
{
    /// <summary>
    /// A generator for methods.
    /// </summary>
    public class MethodGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string prefixes, string returnType, string name, string parameters, string implementation, string summary = null)
        {
            string code = "";
            if (summary != null)
                code += SummaryGenerator.Generate(summary) + "\n";
            code += Indent + $"{prefixes} {returnType} {name}({parameters})"
                + "\n" + Indent + "{"
                + "\n" + MethodIndent + implementation.Replace("\n", "\n" + MethodIndent)
                + "\n" + Indent + "}";
            return code;
        }
    }
}
