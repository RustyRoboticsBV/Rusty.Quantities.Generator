

namespace Generator
{
    /// <summary>
    /// A generator for a quantity class.
    /// </summary>
    public static class ClassGenerator
    {
        /* Public properties. */
        public static string Namespace => "Modules.L0.Quantities";
        public static string Indent => new(' ', 8);

        /* Public methods. */
        public static string Generate(string className, string desc)
        {
            return "using System;"
                + "\n"
                + "\n" + $"namespace {Namespace}"
                + "\n" + "{"
                + "\n" + "    /// <summary>"
                + "\n" + "    /// " + desc
                + "\n" + "    /// </summary>"
                + "\n" + "    [Serializable]"
                + "\n" + $"    public struct {className}"
                + "\n" + "    {"
                + "\n" + "        /* Fields. */"
                + "\n" + "        private double value;"
                + "\n"
                + "\n" + "        /* Public properties. */"
                + "\n" + StaticPropertyGenerator.Generate(className, "Zero", "0.0", "0")
                + "\n" + StaticPropertyGenerator.Generate(className, "One", "1.0", "1")
                + "\n" + StaticPropertyGenerator.Generate(className, "Pi", "Mathd.Pi", "pi")
                + "\n" + StaticPropertyGenerator.Generate(className, "TwoPi", "2.0 * Mathd.Pi", "2 * pi")
                + "\n//PROPS"
                + "\n" + "        /* Constructors. */"
                + "\n" + $"        public {className}(double value)"
                + "\n" + "        {"
                + "\n" + "            this.value = value;"
                + "\n" + "        }"
                + "\n"
                + "\n" + "        /* Casting operators. */"
                + "\n" + CastOperatorGenerator.Generate(className)
                + "\n//CASTS"
                + "\n" + "        /* Arithmetic operators. */"
                + "\n" + MathOperatorGenerator.Generate(className)
                + "\n//MATH"
                + "\n" + "        /* Comparison operators. */"
                + "\n" + ComparisonOperatorGenerator.Generate(className)
                + "\n"
                + "\n" + "        /* Public methods. */"
                + "\n" + $"        public override readonly int GetHashCode() => value.GetHashCode();"
                + "\n" + $"        public override readonly bool Equals(object? obj) => obj is {className} {className.ToLower()} && value == {className.ToLower()}.value;"
                + "\n" + "        public override readonly string ToString() => value.ToString();"
                + "\n"
                + "\n" + MethodGenerator.GenerateAll(className)
                + "\n"
                + "\n//METHODS"
                + "\n" + "    }"
                + "\n" + "}";
        }
    }
}
