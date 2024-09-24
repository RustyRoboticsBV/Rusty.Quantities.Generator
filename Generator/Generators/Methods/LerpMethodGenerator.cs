

namespace Generators
{
    /// <summary>
    /// A generator for static linear interpolation methods.
    /// </summary>
    public class LerpMethodGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string className)
        {
            return SummaryGenerator.Generate($"Return the result of linearly interpolating between two {className.ToLower()} values, using the specified interpolation factor.")
                + "\n" + Indent + $"public static {className} Lerp({className} min, {className} max, double factor) => new {className}(Mathd.Lerp(min.value, max.value, factor));";
        }
    }
}
