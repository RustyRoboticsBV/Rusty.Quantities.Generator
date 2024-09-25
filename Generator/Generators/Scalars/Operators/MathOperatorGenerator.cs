

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
        private static string GenerateCC(string className, string opName)
        {
            return GenerateBinary(className,
                opName,
                className, className,
                $"return new {className}(a.value {opName} b.value);");
        }

        private static string GenerateTC(string typeName, string opName, string className)
        {
            return GenerateBinary(className,
                opName,
                typeName, className,
                $"return new {className}(a {opName} b.value);");
        }

        private static string GenerateCT(string className, string opName, string typeName)
        {
            return GenerateBinary(className,
                opName,
                className, typeName,
                $"return new {className}(a.value {opName} b);");
        }

        private static string GenerateUnary(string className, string opName)
        {
            return GenerateUnary(className,
                opName,
                $"return new {className}({opName}value.value);");
        }

        private static string GenerateAll(string className, string opName)
        {
            return GenerateTC("byte", opName, className)
                + "\n" + GenerateTC("ushort", opName, className)
                + "\n" + GenerateTC("uint", opName, className)
                + "\n" + GenerateTC("ulong", opName, className)
                + "\n" + GenerateTC("sbyte", opName, className)
                + "\n" + GenerateTC("short", opName, className)
                + "\n" + GenerateTC("int", opName, className)
                + "\n" + GenerateTC("long", opName, className)
                + "\n" + GenerateTC("float", opName, className)
                + "\n" + GenerateTC("double", opName, className)
                + "\n" + GenerateCT(className, opName, "byte")
                + "\n" + GenerateCT(className, opName, "ushort")
                + "\n" + GenerateCT(className, opName, "uint")
                + "\n" + GenerateCT(className, opName, "ulong")
                + "\n" + GenerateCT(className, opName, "sbyte")
                + "\n" + GenerateCT(className, opName, "short")
                + "\n" + GenerateCT(className, opName, "int")
                + "\n" + GenerateCT(className, opName, "long")
                + "\n" + GenerateCT(className, opName, "float")
                + "\n" + GenerateCT(className, opName, "double")
                + "\n" + GenerateCC(className, opName);
        }
    }
}
