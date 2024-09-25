

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for math methods with two arguments in the non-static version.
    /// </summary>
    public class MathMethod2Generator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className, string methodName, string summary)
        {
            return GenerateLocal(className, methodName, "min", "max", summary);
        }

        public static string GenerateLocal(string className, string methodName, string arg1Name, string arg2Name,
            string summary)
        {
            return MethodGenerator.Generate("public readonly",
                className, methodName, $"{className} {arg1Name}, {className} {arg2Name}",
                $"return new {className}(Mathd.{methodName}(value, {arg1Name}.value, {arg2Name}.value));", summary);
        }

        public static string GenerateStatic(string className, string methodName, string summary)
        {
            return GenerateStatic(className, methodName, "value", "min", "max", summary);
        }

        public static string GenerateStatic(string className, string methodName, string arg1Name, string arg2Name,
            string arg3Name, string summary)
        {
            return MethodGenerator.Generate("public static",
                className, methodName, $"{className} {arg1Name}, {className} {arg2Name}, {className} {arg3Name}",
                $"return new {className}(Mathd.{methodName}({arg1Name}.value, {arg2Name}.value, {arg3Name}.value));", summary);
        }
    }
}
