namespace Generators.New.Deprecated
{
    /// <summary>
    /// A mathd method generator.
    /// </summary>
    public abstract class MathdMethod : Method
    {
        /* Constructors. */
        public MathdMethod(bool isStatic, string returnType, string name, ParameterList parameters, string implementation, string summary)
            : base("public", isStatic ? "static" : "readonly", returnType, name, parameters, implementation, summary) { }

        /* Protected methods. */
        protected string GetMethodCall(string arguments)
        {
            return $"Mathd.{Name}({arguments})";
        }
    }
}