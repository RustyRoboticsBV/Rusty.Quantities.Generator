

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for blocks of casting operators.
    /// </summary>
    public class ComparisonOperatorGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string type1, string type2, string opName, string term1, string term2, string summary = null)
        {
            return OperatorGenerator.Generate(
                null,
                "bool",
                opName,
                $"{type1} a, {type2} b",
                $"return {term1} {opName} {term2};",
                summary);
        }

        public static string Generate(string className)
        {
            return GenerateAll(className, "==")
                + "\n" + GenerateAll(className, "!=")
                + "\n" + GenerateAll(className, ">")
                + "\n" + GenerateAll(className, "<")
                + "\n" + GenerateAll(className, ">=")
                + "\n" + GenerateAll(className, "<=");
        }

        /* Private methods. */
        private static string GenerateCC(string className, string opName)
        {
            return Generate(className, className, opName, "a.value", "b.value");
        }

        private static string GenerateTC(string typeName, string opName, string className)
        {
            return Generate(typeName, className, opName, "a", "b.value");
        }

        private static string GenerateCT(string typeName, string opName, string className)
        {
            return Generate(typeName, className, opName, "a.value", "b");
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
