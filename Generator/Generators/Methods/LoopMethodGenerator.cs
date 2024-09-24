

namespace Generators
{
    /// <summary>
    /// A generator for loop methods.
    /// </summary>
    public class LoopMethodGenerator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return MathMethod1Generator.GenerateLocal(className, "Loop", "max", GetSummary(className, false));
        }

        public static string GenerateStatic(string className)
        {
            return MathMethod1Generator.GenerateStatic(className, "Loop", "value", "max", GetSummary(className, true));
        }

        /* Private methods. */
        private static string GetSummary(string className, bool isStatic)
        {
            return $"Return the result of forcing {(isStatic ? "an" : "this")} {className.ToLower()} into a range from 0 to the specified max (through a modulo operation).";
        }
    }
}
