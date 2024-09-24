

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
            return MethodGenerator.Generate("public readonly", "int", "Sign", "", "return Mathd.Sign(value);",
                GetSummary(className, false));
        }

        public static string GenerateStatic(string className)
        {
            return MethodGenerator.Generate("public static", "int", "Sign", $"{className} value",
                "return Mathd.Sign(value.value);", GetSummary(className, false));
        }

        /* Private methods. */
        private static string GetSummary(string className, bool isStatic)
        {
            return $"Return the sign of {(isStatic ? "a" : "this")} {className.ToLower()} value; -1 if negative, 1 if positive and 0 if equal to 0.";
        }
    }
}
