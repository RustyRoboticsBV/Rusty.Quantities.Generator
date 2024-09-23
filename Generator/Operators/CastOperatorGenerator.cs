

namespace Generator
{
    /// <summary>
    /// A generator for blocks of casting operators.
    /// </summary>
    public static class CastOperatorGenerator
    {
        /* Public methods. */
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
                + "\n" + GenerateToClassType(className, "double");
        }

        /* Private methods. */
        private static string GenerateFromClassType(string className, string typeName, string plicit)
        {
            return Generator.Indent + $"public static {plicit}plicit operator {typeName}({className} value) => {(typeName != "double" ? $"({typeName})" : "")}value.value;";
        }

        private static string GenerateToClassType(string className, string typeName)
        {
            return Generator.Indent + $"public static implicit operator {className}({typeName} value) => new {className}(value);";
        }

    }
}
