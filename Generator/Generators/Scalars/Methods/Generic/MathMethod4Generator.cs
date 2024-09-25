using Generators.Generic;

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for math methods with four arguments in the non-static version.
    /// </summary>
    public class MathMethod4Generator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className, string methodName, string summary)
        {
            return GenerateLocal(className, methodName, "fromMin", "fromMax", "toMin", "toMax", summary);
        }

        public static string GenerateLocal(string className, string methodName, string arg1Name, string arg2Name,
            string arg3Name, string arg4Name, string summary)
        {
            return MethodGenerator.Generate("public readonly",
                className,
                methodName,
                $"{className} {arg1Name}, {className} {arg2Name}, {className} {arg3Name}, {className} {arg4Name}",
                $"return new {className}(Mathd.{methodName}(value, {arg1Name}.value, {arg2Name}.value, {arg3Name}.value, "
                    + $"{arg4Name}.value));", summary);
        }

        public static string GenerateStatic(string className, string methodName, string summary)
        {
            return GenerateStatic(className, methodName, "value", "fromMin", "fromMax", "toMin", "toMax", summary);
        }

        public static string GenerateStatic(string className, string methodName, string arg1Name, string arg2Name,
            string arg3Name, string arg4Name, string arg5Name, string summary)
        {
            return MethodGenerator.Generate("public static",
                className,
                methodName,
                $"{className} {arg1Name}, {className} {arg2Name}, {className} {arg3Name}, {className} {arg4Name}, "
                    + $"{className} {arg5Name}",
                $"return new {className}(Mathd.{methodName}({arg1Name}.value, {arg2Name}.value, {arg3Name}.value, "
                    + $"{arg4Name}.value, {arg5Name}.value));", summary);
        }
    }
}
