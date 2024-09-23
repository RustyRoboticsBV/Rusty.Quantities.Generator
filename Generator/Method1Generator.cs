

namespace Quantities
{
    public static class Method1Generator
    {
        public static string GenerateLocal(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public readonly {className} {methodName}() => new {className}(Mathd.{methodName}(value));";
        }

        public static string GenerateStatic(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public static {className} {methodName}({className} value) => new {className}(Mathd.{methodName}(value.value));";
        }

        public static string GenerateBoth(string className, string methodName, string localDesc, string staticDesc)
        {
            return GenerateLocal(className, methodName, localDesc)
                + "\n" + GenerateStatic(className, methodName, staticDesc);
        }
    }
}
