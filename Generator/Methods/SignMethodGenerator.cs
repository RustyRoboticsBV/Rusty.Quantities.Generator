

namespace Generator
{
    /// <summary>
    /// A generator for sign methods.
    /// </summary>
    public static class SignMethodGenerator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return MethodGenerator.GenerateSummary(GenerateDesc(className, false))
                + "\n" + ClassGenerator.Indent + $"public readonly int Sign() => Mathd.Sign(value);";
        }

        public static string GenerateStatic(string className)
        {
            return MethodGenerator.GenerateSummary(GenerateDesc(className, true))
                + "\n" + ClassGenerator.Indent + $"public static int Sign({className} value) => Mathd.Sign(value.value);";
        }

        /* Private methods. */
        private static string GenerateDesc(string className, bool isStatic)
        {
            return $"Return the sign of {(isStatic ? "a" : "this")} {className.ToLower()} value; -1 if negative, 1 if positive and 0 if equal to 0.";
        }
    }
}
