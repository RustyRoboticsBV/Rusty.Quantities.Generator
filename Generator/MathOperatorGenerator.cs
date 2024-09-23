

namespace Quantities
{
    public static class MathOperatorGenerator
    {
        public static string GenerateCC(string className, char operatorSymbol)
        {
            return Generator.Indent + $"public static {className} operator {operatorSymbol}({className} a, {className} b) => new {className}(a.value {operatorSymbol} b.value);";
        }

        public static string GenerateTC(string typeName, char operatorName, string className)
        {
            return Generator.Indent + $"public static {className} operator {operatorName}({typeName} a, {className} b) => new {className}(a {operatorName} b.value);";
        }

        public static string GenerateCT(string className, char operatorSymbol, string typeName)
        {
            return Generator.Indent + $"public static {className} operator {operatorSymbol}({className} a, {typeName} b) => new {className}(a.value {operatorSymbol} b);";
        }

        public static string GenerateUnaryMinus(string className)
        {
            return Generator.Indent + $"public static {className} operator -({className} value) => new {className}(-value.value);";
        }

        public static string GenerateAll(string className, char operatorSymbol)
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

        public static string GenerateAll(string className)
        {
            return GenerateAll(className, '+')
                + "\n" + GenerateAll(className, '-')
                + "\n" + GenerateAll(className, '*')
                + "\n" + GenerateAll(className, '/')
                + "\n" + GenerateAll(className, '%')
                + "\n" + GenerateUnaryMinus(className);
        }

        private static string GetCastStr(string typeName)
        {
            if (typeName != "double")
                return "(double)";
            return "";
        }
    }
}
