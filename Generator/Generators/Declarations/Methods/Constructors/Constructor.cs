namespace Generators
{
    /// <summary>
    /// A constructor generator.
    /// </summary>
    public class Constructor : Method
    {
        /* Constructors. */
        public Constructor(string name, ParameterList parameters, string implementation)
            : base("public", null, null, name, parameters, implementation) { }
    }
}