

namespace Generators
{
    /// <summary>
    /// A generator for sign methods.
    /// </summary>
    public class SignMethodGenerator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return SummaryGenerator.Generate(GenerateDesc(className, false))
                + "\n" + Indent + $"public readonly int Sign() => Mathd.Sign(value);";
        }

        public static string GenerateStatic(string className)
        {
            return SummaryGenerator.Generate(GenerateDesc(className, true))
                + "\n" + Indent + $"public static int Sign({className} value) => Mathd.Sign(value.value);";
        }

        /* Private methods. */
        private static string GenerateDesc(string className, bool isStatic)
        {
            return $"Return the sign of {(isStatic ? "a" : "this")} {className.ToLower()} value; -1 if negative, 1 if positive and 0 if equal to 0.";
        }
    }
}
