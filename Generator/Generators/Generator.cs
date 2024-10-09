namespace Generators
{
    /// <summary>
    /// The base class for all source generators.
    /// </summary>
    public abstract class Generator
    {
        /* Public properties. */
        /// <summary>
        /// The parent generator. This only affects the output of the GetScope method.
        /// </summary>
        public Generator Parent { get; set; }
        /// <summary>
        /// This generator's local struct scope.
        /// </summary>
        public string Scope { get; set; } = "";

        /* Public methods. */
        /// <summary>
        /// Generate code from this object.
        /// </summary>
        public abstract string Generate();

        /// <summary>
        /// Get the generator's struct scope in the generator hierarchy.
        /// </summary>
        /// <returns></returns>
        public string GetScope()
        {
            if (string.IsNullOrEmpty(Scope) && Parent != null)
                return Parent.GetScope();
            else
                return Scope;
        }

        /* Protected methods. */
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