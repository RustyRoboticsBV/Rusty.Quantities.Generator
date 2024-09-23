

namespace Quantities
{
    public static class Method3Generator
    {
        public static string GenerateLocal(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public readonly {className} {methodName}({className} min, {className} max) => new {className}(Mathd.{methodName}(value, min.value, max.value));";
        }

        public static string GenerateStatic(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public static {className} {methodName}({className} value, {className} min, {className} max) => new {className}(Mathd.{methodName}(value.value, min.value, max.value));";
        }

        public static string GenerateBoth(string className, string methodName, string localDesc, string staticDesc)
        {
            return GenerateLocal(className, methodName, localDesc)
                + "\n" + GenerateStatic(className, methodName, staticDesc);
        }
    }
}
