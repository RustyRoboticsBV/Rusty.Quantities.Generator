

namespace Generators
{
    /// <summary>
    /// A generator for arithmetic operator blocks.
    /// </summary>
    public class MathOperatorGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string className)
        {
            return GenerateAll(className, '+')
                + "\n" + GenerateAll(className, '-')
                + "\n" + GenerateAll(className, '*')
                + "\n" + GenerateAll(className, '/')
                + "\n" + GenerateAll(className, '%')
                + "\n" + GenerateUnary(className, "+")
                + "\n" + GenerateUnary(className, "-")
                + "\n" + GenerateUnary(className, "++")
                + "\n" + GenerateUnary(className, "--");
        }

        public static string Generate(string returnType, string operand1Type, bool isClass1, string operatorName, string operand2Type, bool isClass2)
        {
            return $"public static {returnType} operator {operatorName}({operand1Type} a, {operand2Type} b) => {ToDouble("a", isClass1)} {operatorName} {ToDouble("b", isClass2)};";
        }

        /* Private methods. */
        private static string GenerateCC(string className, char operatorSymbol)
        {
            return Indent + $"public static {className} operator {operatorSymbol}({className} a, {className} b) => new {className}(a.value {operatorSymbol} b.value);";
        }

        private static string GenerateTC(string typeName, char operatorName, string className)
        {
            return Indent + $"public static {className} operator {operatorName}({typeName} a, {className} b) => new {className}(a {operatorName} b.value);";
        }

        private static string GenerateCT(string className, char operatorSymbol, string typeName)
        {
            return Indent + $"public static {className} operator {operatorSymbol}({className} a, {typeName} b) => new {className}(a.value {operatorSymbol} b);";
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

        private static string GenerateUnary(string className, string operatorSymbol)
        {
            return Indent + $"public static {className} operator {operatorSymbol}({className} value) => new {className}({operatorSymbol}value.value);";
        }

        private static string ToDouble(string id, bool isMainClass)
        {
            if (isMainClass)
                return $"{id}.value";
            else
                return $"(double){id}";
        }
    }
}
