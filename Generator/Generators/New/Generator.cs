namespace Generators.New
{
    /// <summary>
    /// The base class for all source generators.
    /// </summary>
    public abstract class Generator
    {
        /* Public methods. */
        /// <summary>
        /// Generate code from this object, at some indentation level.
        /// </summary>
        public string Generate(int indent = 0)
        {
            return Indent(Generate(), indent);
        }

        /* Protected methods. */
        /// <summary>
        /// Generate code from this object.
        /// </summary>
        protected abstract string Generate();

        /// <summary>
        /// Apply indentation to a block or line of code.
        /// </summary>
        protected static string Indent(string code, int indent = 1)
        {
            if (indent <= 0)
                return code;
            else
            {
                string spaces = new string(' ', indent * 4);
                return spaces + code.Replace("\n", "\n" + spaces);
            }
        }
    }
}