

namespace Generator
{
    /// <summary>
    /// A generator for static properties with the same return type as the class.
    /// </summary>
    public static class StaticPropertyGenerator
    {
        /* Public methods. */
        public static string Generate(string className, string propertyName, string value)
        {
            return ClassGenerator.Indent + $"public static {className} {propertyName} => new {className}({value});";
        }
    }
}
