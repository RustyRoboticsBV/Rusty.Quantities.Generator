

namespace Generator
{
    /// <summary>
    /// A generator for arithmetic operator blocks.
    /// </summary>
    public static class MathOperatorGenerator
    {
        /* Public methods. */
        public static string Generate(string className)
        {
            return GenerateAll(className, '+')
                + "\n" + GenerateAll(className, '-')
                + "\n" + GenerateAll(className, '*')
                + "\n" + GenerateAll(className, '/')
                + "\n" + GenerateAll(className, '%')
                + "\n" + GenerateUnaryMinus(className);
        }

        /* Private methods. */
        private static string GenerateCC(string className, char operatorSymbol)
        {
            return Generator.Indent + $"public static {className} operator {operatorSymbol}({className} a, {className} b) => new {className}(a.value {operatorSymbol} b.value);";
        }

        private static string GenerateTC(string typeName, char operatorName, string className)
        {
            return Generator.Indent + $"public static {className} operator {operatorName}({typeName} a, {className} b) => new {className}(a {operatorName} b.value);";
        }

        private static string GenerateCT(string className, char operatorSymbol, string typeName)
        {
            return Generator.Indent + $"public static {className} operator {operatorSymbol}({className} a, {typeName} b) => new {className}(a.value {operatorSymbol} b);";
        }

        private static string GenerateAll(string className, char operatorSymbol)
        {
            return GenerateTC("short", operatorSymbol, className)
                + "\n" + GenerateTC("int", operatorSymbol, className)
                + "\n" + GenerateTC("long", operatorSymbol, className)
                + "\n" + GenerateTC("float", operatorSymbol, className)
                + "\n" + GenerateTC("double", operatorSymbol, className)
                + "\n" + GenerateCT(className, operatorSymbol, "short")
                + "\n" + GenerateCT(className, operatorSymbol, "int")
                + "\n" + GenerateCT(className, operatorSymbol, "long")
                + "\n" + GenerateCT(className, operatorSymbol, "float")
                + "\n" + GenerateCT(className, operatorSymbol, "double")
                + "\n" + GenerateCC(className, operatorSymbol);
        }

        private static string GenerateUnaryMinus(string className)
        {
            return Generator.Indent + $"public static {className} operator -({className} value) => new {className}(-value.value);";
        }
    }
}
