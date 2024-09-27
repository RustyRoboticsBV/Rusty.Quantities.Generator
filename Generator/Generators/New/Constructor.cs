namespace Generators.New
{
    /// <summary>
    /// A constructor generator.
    /// </summary>
    public class Constructor : Method
    {
        /* Constructors. */
        public Constructor(string name, ParameterList parameters, string implementation)
            : base("public", null, null, name, parameters, implementation) { }

        /* Public methods. */
        public static string Generate(string name, ParameterList parameters, string implementation)
        {
            return new Constructor(name, parameters, implementation).Generate();
        }
    }
}