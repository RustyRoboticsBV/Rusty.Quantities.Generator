

namespace Generator
{
    /// <summary>
    /// A generator for math methods with two arguments in the static version.
    /// </summary>
    public static class Method2Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + ClassGenerator.Indent + $"public readonly {className} {methodName}({className} other) => new {className}(Mathd.{methodName}(value, other.value));";
        }

        public static string GenerateStatic(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + ClassGenerator.Indent + $"public static {className} {methodName}({className} a, {className} b) => new {className}(Mathd.{methodName}(a.value, b.value));";
        }
    }
}
