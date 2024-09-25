using Generators.Generic;

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for math methods with one argument in the non-static version.
    /// </summary>
    public class MathMethod1Generator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className, string methodName, string summary)
        {
            return GenerateLocal(className, methodName, "other", summary);
        }

        public static string GenerateLocal(string className, string methodName, string argName, string summary)
        {
            return MethodGenerator.Generate("public readonly", className, methodName, $"{className} {argName}",
                $"return new {className}(Mathd.{methodName}(value, {argName}.value));", summary);
        }

        public static string GenerateStatic(string className, string methodName, string summary)
        {
            return GenerateStatic(className, methodName, "a", "b", summary);
        }

        public static string GenerateStatic(string className, string methodName, string arg1Name, string arg2Name, string summary)
        {
            return MethodGenerator.Generate("public static", className, methodName, $"{className} {arg1Name}, {className} {arg2Name}",
                $"return new {className}(Mathd.{methodName}({arg1Name}.value, {arg2Name}.value));", summary);
        }
    }
}
