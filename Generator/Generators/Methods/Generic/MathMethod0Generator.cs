

namespace Generators
{
    /// <summary>
    /// A generator for math methods with no arguments in the non-static version.
    /// </summary>
    public class MathMethod0Generator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className, string methodName, string summary)
        {
            return MethodGenerator.Generate("public readonly", className, methodName, "",
                $"return new {className}(Mathd.{methodName}(value));", summary);
        }

        public static string GenerateStatic(string className, string methodName, string summary)
        {
            return MethodGenerator.Generate("public static", className, methodName, $"{className} value",
                $"return new {className}(Mathd.{methodName}(value.value));", summary);
        }
    }
}
