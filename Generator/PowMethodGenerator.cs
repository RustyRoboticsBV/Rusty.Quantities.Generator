

namespace Quantities
{

    public static class PowMethodGenerator
    {
        public static string GenerateLocal(string className, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public readonly {className} Pow(double power) => new {className}(Mathd.Pow(value, power));";
        }

        public static string GenerateStatic(string className, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public static {className} Pow({className} value, double power) => new {className}(Mathd.Pow(value.value, power));";
        }

        public static string GenerateBoth(string className)
        {
            return GenerateLocal(className, GenerateDesc(className, false))
                + "\n" + GenerateStatic(className, GenerateDesc(className, true));
        }

        private static string GenerateDesc(string className, bool isStatic)
        {
            return $"Return the result of raising {(isStatic ? "a" : "this")} {className.ToLower()} value to the specified power.";
        }
    }
}
