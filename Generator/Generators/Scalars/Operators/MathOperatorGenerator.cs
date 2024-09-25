

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for arithmetic operator blocks.
    /// </summary>
    public class MathOperatorGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string returnType, string name, string parameters, string implementation, string summary = null)
        {
            return OperatorGenerator.Generate(
                null,
                returnType,
                name,
                parameters,
                implementation,
                summary);
        }

        public static string GenerateUnary(string className, string name, string implementation, string summary = null)
        {
            return Generate(className, name, $"{className} value", implementation, summary);
        }

        public static string GenerateBinary(string returnType, string name, string argType1, string argType2, string implementation, string summary = null)
        {
            return Generate(returnType, name, $"{argType1} a, {argType2} b", implementation, summary);
        }

        public static string Generate(string className)
        {
            return GenerateAll(className, "+")
                + "\n" + GenerateAll(className, "-")
                + "\n" + GenerateAll(className, "*")
                + "\n" + GenerateAll(className, "/")
                + "\n" + GenerateAll(className, "%")
                + "\n" + GenerateUnary(className, "+")
                + "\n" + GenerateUnary(className, "-")
                + "\n" + GenerateUnary(className, "++")
                + "\n" + GenerateUnary(className, "--");
        }

        /* Private methods. */
        private static string GenerateCC(string className, string operatorName)
        {
            return GenerateBinary(className,
                operatorName,
                className, className,
                $"return new {className}({ToDouble("a", true)} {operatorName} {ToDouble("b", true)});");
        }

        private static string GenerateTC(string typeName, string operatorName, string className)
        {
            return GenerateBinary(className,
                operatorName,
                typeName, className,
                $"return new {className}({ToDouble("a", false)} {operatorName} {ToDouble("b", true)});");
        }

        private static string GenerateCT(string className, string operatorName, string typeName)
        {
            return GenerateBinary(className,
                operatorName,
                className, typeName,
                $"return new {className}({ToDouble("a", true)} {operatorName} {ToDouble("b", false)});");
        }

        private static string GenerateUnary(string className, string operatorSymbol)
        {
            return GenerateUnary(className,
                operatorSymbol,
                $"return new {className}({operatorSymbol}value.value);");
        }

        private static string GenerateAll(string className, string operatorSymbol)
        {
            return GenerateTC("byte", operatorSymbol, className)
                + "\n" + GenerateTC("ushort", operatorSymbol, className)
                + "\n" + GenerateTC("uint", operatorSymbol, className)
                + "\n" + GenerateTC("ulong", operatorSymbol, className)
                + "\n" + GenerateTC("sbyte", operatorSymbol, className)
                + "\n" + GenerateTC("short", operatorSymbol, className)
                + "\n" + GenerateTC("int", operatorSymbol, className)
                + "\n" + GenerateTC("long", operatorSymbol, className)
                + "\n" + GenerateTC("float", operatorSymbol, className)
                + "\n" + GenerateTC("double", operatorSymbol, className)
                + "\n" + GenerateCT(className, operatorSymbol, "byte")
                + "\n" + GenerateCT(className, operatorSymbol, "ushort")
                + "\n" + GenerateCT(className, operatorSymbol, "uint")
                + "\n" + GenerateCT(className, operatorSymbol, "ulong")
                + "\n" + GenerateCT(className, operatorSymbol, "sbyte")
                + "\n" + GenerateCT(className, operatorSymbol, "short")
                + "\n" + GenerateCT(className, operatorSymbol, "int")
                + "\n" + GenerateCT(className, operatorSymbol, "long")
                + "\n" + GenerateCT(className, operatorSymbol, "float")
                + "\n" + GenerateCT(className, operatorSymbol, "double")
                + "\n" + GenerateCC(className, operatorSymbol);
        }

        private static string ToDouble(string id, bool isMainClass)
        {
            if (isMainClass)
                return $"{id}.value";
            else
                return id;
        }
    }
}
