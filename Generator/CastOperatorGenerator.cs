

namespace Quantities
{

    public static class CastOperatorGenerator
    {
        public static string GenerateFromClassType(string className, string typeName, string plicit)
        {
            return Generator.Indent + $"public static {plicit}plicit operator {typeName}({className} value) => {(typeName != "double" ? $"({typeName})" : "")}value.value;";
        }

        public static string GenerateToClassType(string className, string typeName)
        {
            return Generator.Indent + $"public static implicit operator {className}({typeName} value) => new {className}(value);";
        }

        public static string GenerateAll(string className)
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
    }
}
