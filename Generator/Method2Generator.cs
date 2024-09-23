

namespace Quantities
{
    public static class Method2Generator
    {
        public static string GenerateLocal(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public readonly {className} {methodName}({className} other) => new {className}(Mathd.{methodName}(value, other.value));";
        }

        public static string GenerateStatic(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public static {className} {methodName}({className} a, {className} b) => new {className}(Mathd.{methodName}(a.value, b.value));";
        }

        public static string GenerateBoth(string className, string methodName, string localDesc, string staticDesc)
        {
            return GenerateLocal(className, methodName, localDesc)
                + "\n" + GenerateStatic(className, methodName, staticDesc);
        }
    }
}
