

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
                + "\n" + StaticPropertyGenerator.Generate(className, "Zero", "0.0")
                + "\n" + StaticPropertyGenerator.Generate(className, "One", "1.0")
                + "\n"
                + "\n" + "        /* Constructors. */"
                + "\n" + $"        public {className}(double value)"
                + "\n" + "        {"
                + "\n" + "            this.value = value;"
                + "\n" + "        }"
                + "\n"
                + "\n" + "        /* Casting operators. */"
                + "\n" + CastOperatorGenerator.Generate(className)
                + "\n"
                + "\n" + "        /* Arithmetic operators. */"
                + "\n" + MathOperatorGenerator.Generate(className)
                + "\n"
                + "\n" + "        /* Public methods. */"
                + "\n" + "        public readonly override string ToString() => value.ToString();"
                + "\n"
                + "\n" + MethodGenerator.GenerateAll(className)
                + "\n" + "    }"
                + "\n" + "}";
        }
    }
}
