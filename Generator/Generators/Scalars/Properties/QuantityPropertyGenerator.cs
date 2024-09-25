

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for static, read-only properties with the same return type as the class.
    /// </summary>
    public class QuantityPropertyGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string className, string propertyName, string value, string desc)
        {
            return PropertyGenerator.Generate("public static", className, propertyName, $"new {className}({value})",
                $"A {className.ToLower()} equal to {desc}.");
        }
    }
}
