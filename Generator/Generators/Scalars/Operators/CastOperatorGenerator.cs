

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
            return GenerateFromClassType(className, "short", "ex")
                + "\n" + GenerateFromClassType(className, "int", "ex")
                + "\n" + GenerateFromClassType(className, "long", "ex")
                + "\n" + GenerateFromClassType(className, "float", "im")
                + "\n" + GenerateFromClassType(className, "double", "im")
                + "\n" + GenerateToClassType(className, "short")
                + "\n" + GenerateToClassType(className, "int")
                + "\n" + GenerateToClassType(className, "long")
                + "\n" + GenerateToClassType(className, "float")
                + "\n" + GenerateToClassType(className, "double")
                + "\n" + GenerateToString(className);
        }

        /* Private methods. */
        private static string GenerateFromClassType(string className, string typeName, string plicit)
        {
            return Generate(plicit, className, typeName, $"return {(typeName != "double" ? $"({typeName})" : "")}value.value;");
        }

        private static string GenerateToClassType(string className, string typeName)
        {
            return Generate("im", typeName, className, $"return new {className}(value);");
        }

        private static string GenerateToString(string className)
        {
            return Generate("ex", className, "string", "return value.ToString();");
        }
    }
}
