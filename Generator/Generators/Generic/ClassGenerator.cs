

namespace Generators.Generic
{
    /// <summary>
    /// A base class for class generators.
    /// </summary>
    public abstract class ClassGenerator : Generator
    {
        /* Public properties. */
        public static string Namespace => "Rusty.Quantities";

        /* Protected properties. */
        protected string ClassName { get; private set; }

        /* Protected methods. */
        protected string GenerateClass(string name, string summary)
        {
            ClassName = name;

            return "using System;"
                + "\n"
                + "\n" + $"namespace {Namespace}"
                + "\n" + "{"
                + "\n" + "    /// <summary>"
                + "\n" + "    /// " + summary
                + "\n" + "    /// </summary>"
                + "\n" + "    [Serializable]"
                + "\n" + $"    public struct {name}"
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
