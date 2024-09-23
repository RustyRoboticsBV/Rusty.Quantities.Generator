

namespace Generator
{
    /// <summary>
    /// A generator for power of methods.
    /// </summary>
    public static class PowMethodGenerator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return MethodGenerator.GenerateSummary(GenerateDesc(className, false))
                + "\n" + ClassGenerator.Indent + $"public readonly {className} Pow(double power) => new {className}(Mathd.Pow(value, power));";
        }

        public static string GenerateStatic(string className)
        {
            return MethodGenerator.GenerateSummary(GenerateDesc(className, true))
                + "\n" + ClassGenerator.Indent + $"public static {className} Pow({className} value, double power) => new {className}(Mathd.Pow(value.value, power));";
        }

        /* Private methods. */
        private static string GenerateDesc(string className, bool isStatic)
        {
            return $"Return the result of raising {(isStatic ? "a" : "this")} {className.ToLower()} value to the specified power.";
        }
    }
}
