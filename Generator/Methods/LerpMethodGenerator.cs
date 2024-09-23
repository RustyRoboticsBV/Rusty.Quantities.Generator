

namespace Generator
{
    /// <summary>
    /// A generator for static linear interpolation methods.
    /// </summary>
    public static class LerpMethodGenerator
    {
        /* Public methods. */
        public static string Generate(string className)
        {
            return MethodGenerator.GenerateSummary($"Return the result of linearly interpolating between two {className.ToLower()} values, using the specified interpolation factor.")
                + "\n" + Generator.Indent + $"public static {className} Lerp({className} min, {className} max, double factor) => new {className}(Mathd.Lerp(min.value, max.value, factor));";
        }
    }
}
