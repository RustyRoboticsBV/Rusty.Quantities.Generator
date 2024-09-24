

namespace Generators
{
    /// <summary>
    /// A generator for static properties with the same return type as the class.
    /// </summary>
    public class StaticPropertyGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string className, string propertyName, string value, string desc)
        {
            return SummaryGenerator.Generate($"A {className.ToLower()} equal to {desc}.")
                + "\n" + Indent + $"public static {className} {propertyName} => new {className}({value});";
        }
    }
}
