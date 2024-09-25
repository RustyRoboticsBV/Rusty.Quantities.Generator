

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for static linear interpolation methods.
    /// </summary>
    public class LerpMethodGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string className)
        {
            string summary = $"Return the result of linearly interpolating between two {className.ToLower()} values, using the specified interpolation factor.";
            return MethodGenerator.Generate("public static", className, "Lerp",
                $"{className} min, {className} max, double factor",
                $"return new {className}(Mathd.Lerp(min.value, max.value, factor));", summary);
        }
    }
}
