

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for power of methods.
    /// </summary>
    public class PowMethodGenerator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return MethodGenerator.Generate("public readonly", className, "Pow", "double power",
                $"return new {className}(Mathd.Pow(value, power));", GetSummary(className, false));
        }

        public static string GenerateStatic(string className)
        {
            return MethodGenerator.Generate("public static", className, "Pow", $"{className} value, double power",
                $"return new {className}(Mathd.Pow(value.value, power));", GetSummary(className, false));
        }

        /* Private methods. */
        private static string GetSummary(string className, bool isStatic)
        {
            return $"Return the result of raising {(isStatic ? "a" : "this")} {className.ToLower()} value to the specified power.";
        }
    }
}
