

namespace Generators.Generic
{
    /// <summary>
    /// A base class for class generators.
    /// </summary>
    public abstract class ClassGenerator : Generator
    {
        /* Constructors. */
        public ClassGenerator(string className, string summary)
        {
            ClassName = className;
            Summary = summary;
        }

        /* Public properties. */
        public static string Namespace => "Rusty.Quantities";

        /* Protected properties. */
        protected string ClassName { get; private set; }
        protected string Summary { get; private set; }

        /* Protected methods. */
        protected string GenerateClass()
        {
            return "using System;"
                + "\n"
                + "\n" + $"namespace {Namespace}"
                + "\n" + "{"
                + "\n" + "    /// <summary>"
                + "\n" + "    /// " + Summary
                + "\n" + "    /// </summary>"
                + "\n" + "    [Serializable]"
                + "\n" + $"    public struct {ClassName}"
                + "\n" + "    {"
                + "\n" + "        /* Fields. */"
                + "\n" + GenerateField()
                + "\n"
                + "\n" + "        /* Public properties. */"
                + "\n" + GenerateProperties()
                + "\n" + "        /* Constructors. */"
                + "\n" + GenerateConstructor()
                + "\n" + "        /* Casting operators. */"
                + "\n" + GenerateCasting()
                + "\n" + "        /* Arithmetic operators. */"
                + "\n" + GenerateArithmetic()
                + "\n" + "        /* Comparison operators. */"
                + "\n" + GenerateComparison()
                + "\n" + "        /* Public methods. */"
                + "\n" + GenerateLocalMethods()
                + "\n"
                + "\n" + GenerateStaticMethods()
                + "\n" + "    }"
                + "\n" + "}";
        }

        protected abstract string GenerateField();
        protected abstract string GenerateProperties();
        protected abstract string GenerateConstructor();
        protected abstract string GenerateCasting();
        protected abstract string GenerateArithmetic();
        protected abstract string GenerateComparison();
        protected abstract string GenerateLocalMethods();
        protected abstract string GenerateStaticMethods();
    }
}
