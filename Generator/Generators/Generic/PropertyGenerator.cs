

namespace Generators.Generic
{
    /// <summary>
    /// A generator for read-only properties.
    /// </summary>
    public class PropertyGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string prefixes, string returnType, string name, string implementation, string summary = null)
        {
            string code = "";
            if (summary != null)
                code += SummaryGenerator.Generate(summary) + "\n";
            code += Indent + $"{prefixes} {returnType} {name} => {implementation};";
            return code;
        }
    }
}
