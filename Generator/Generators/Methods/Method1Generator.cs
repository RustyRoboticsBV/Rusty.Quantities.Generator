

namespace Generators
{
    /// <summary>
    /// A generator for math methods with one argument in the static version.
    /// </summary>
    public class Method1Generator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Indent + $"public readonly {className} {methodName}() => new {className}(Mathd.{methodName}(value));";
        }

        public static string GenerateStatic(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Indent + $"public static {className} {methodName}({className} value) => new {className}(Mathd.{methodName}(value.value));";
        }
    }
}
