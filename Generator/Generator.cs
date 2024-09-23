

namespace Quantities
{
    public static class Generator
    {
        public static string Indent => new(' ', 8);

        public static string GetAbsPath(string filePath)
        {
            if (filePath.StartsWith("."))
                filePath = Path.GetFullPath(filePath);
            return filePath;
        }

        public static string Generate(string className, string desc)
        {
            return "using System;"
                + "\n"
                + "\n" + "namespace Modules.L0.Quantities"
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
                + "\n" + CastOperatorGenerator.GenerateAll(className)
                + "\n"
                + "\n" + "        /* Arithmetic operators. */"
                + "\n" + MathOperatorGenerator.GenerateAll(className)
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
