

namespace Generators
{
    /// <summary>
    /// A generator for the clamp method.
    /// </summary>
    public class ClampMethodGenerator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return MethodGenerator.Generate("public readonly", className, "Clamp", $"{className} min, {className} max",
                $"return new {className}(Mathd.Clamp(value, min.value, max.value));", GetSummary(false, className));
        }

        public static string GenerateStatic(string className)
        {
            return MethodGenerator.Generate("public static", className, "Clamp", $"{className} value, {className} min, {className} max",
                $"return new {className}(Mathd.Clamp(value.value, min.value, max.value));", GetSummary(true, className));
        }

        /* Private methods. */
        private static string GetSummary(bool isStatic, string className)
        {
            return $"Return the result of clamping {(isStatic ? "a" : "this")} {className.ToLower()} value between a min and max value.";
        }
    }
}
