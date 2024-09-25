

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for blocks of casting operators.
    /// </summary>
    public class CastOperatorGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string plicit, string from, string to, string implementation, string summary = null)
        {
            return OperatorGenerator.Generate(
                $"{plicit}plicit",
                null,
                to,
                $"{from} value",
                implementation,
                summary);
        }

        public static string Generate(string className)
        {
            return GenerateFromClassType(className, "byte", "ex")
                + "\n" + GenerateFromClassType(className, "ushort", "ex")
                + "\n" + GenerateFromClassType(className, "uint", "ex")
                + "\n" + GenerateFromClassType(className, "ulong", "ex")
                + "\n" + GenerateFromClassType(className, "sbyte", "ex")
                + "\n" + GenerateFromClassType(className, "short", "ex")
                + "\n" + GenerateFromClassType(className, "int", "ex")
                + "\n" + GenerateFromClassType(className, "long", "ex")
                + "\n" + GenerateFromClassType(className, "float", "im")
                + "\n" + GenerateFromClassType(className, "double", "im")
                + "\n" + GenerateFromClassType(className, "decimal", "ex")
                + "\n" + GenerateToClassType(className, "byte", "im")
                + "\n" + GenerateToClassType(className, "ushort", "im")
                + "\n" + GenerateToClassType(className, "uint", "im")
                + "\n" + GenerateToClassType(className, "ulong", "im")
                + "\n" + GenerateToClassType(className, "sbyte", "im")
                + "\n" + GenerateToClassType(className, "short", "im")
                + "\n" + GenerateToClassType(className, "int", "im")
                + "\n" + GenerateToClassType(className, "long", "im")
                + "\n" + GenerateToClassType(className, "float", "im")
                + "\n" + GenerateToClassType(className, "double", "im")
                + "\n" + GenerateToClassType(className, "decimal", "ex")
                + "\n" + GenerateToString(className);
        }

        /* Private methods. */
        private static string GenerateFromClassType(string className, string typeName, string plicit)
        {
            return Generate(plicit, className, typeName, $"return {(typeName != "double" ? $"({typeName})" : "")}value.value;");
        }

        private static string GenerateToClassType(string className, string typeName, string plicit)
        {
            return Generate(plicit, typeName, className, $"return new {className}({(typeName == "decimal" ? $"(double)" : "")}value);");
        }

        private static string GenerateToString(string className)
        {
            return Generate("ex", className, "string", "return value.ToString();");
        }
    }
}
