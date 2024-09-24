

namespace Generators
{
    /// <summary>
    /// A generator for power of methods.
    /// </summary>
    public class PowMethodGenerator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return SummaryGenerator.Generate(GenerateDesc(className, false))
                + "\n" + Indent + $"public readonly {className} Pow(double power) => new {className}(Mathd.Pow(value, power));";
        }

        public static string GenerateStatic(string className)
        {
            return SummaryGenerator.Generate(GenerateDesc(className, true))
                + "\n" + Indent + $"public static {className} Pow({className} value, double power) => new {className}(Mathd.Pow(value.value, power));";
        }

        /* Private methods. */
        private static string GenerateDesc(string className, bool isStatic)
        {
            return $"Return the result of raising {(isStatic ? "a" : "this")} {className.ToLower()} value to the specified power.";
        }
    }
}
