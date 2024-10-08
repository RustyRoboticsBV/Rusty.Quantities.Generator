namespace Generators
{
    /// <summary>
    /// An operator generator.
    /// </summary>
    public abstract class Operator : Method
    {
        /* Public properties. */
        public string OpName { get; private set; }

        /* Constructors. */
        public Operator(string modifiers, Type returnType, string name, ParameterList parameters, string implementation)
            : base("public", modifiers, returnType, $"operator {name}", parameters, implementation)
        {
            OpName = name;
        }
    }
}