

namespace Generator
{
    /// <summary>
    /// A generator for math methods with one argument in the static version.
    /// </summary>
    public static class Method1Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + ClassGenerator.Indent + $"public readonly {className} {methodName}() => new {className}(Mathd.{methodName}(value));";
        }

        public static string GenerateStatic(string className, string methodName, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + ClassGenerator.Indent + $"public static {className} {methodName}({className} value) => new {className}(Mathd.{methodName}(value.value));";
        }
    }
}
