

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for wrap methods.
    /// </summary>
    public class WrapMethodGenerator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return MathMethod2Generator.GenerateLocal(className, "Wrap", "min", "max", GetSummary(className, false));
        }

        public static string GenerateStatic(string className)
        {
            return MathMethod2Generator.GenerateStatic(className, "Wrap", "value", "min", "max", GetSummary(className, true));
        }

        /* Private methods. */
        private static string GetSummary(string className, bool isStatic)
        {
            return $"Return the result of mapping {(isStatic ? "an" : "this")} {className.ToLower()} to the specified, looping range.";
        }
    }
}
