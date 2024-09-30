namespace Generators
{
    /// <summary>
    /// An operator generator.
    /// </summary>
    public abstract class Operator : Method
    {
        /* Constructors. */
        public Operator(string? modifiers, string? returnType, string name, ParameterList parameters, string implementation)
            : base("public", modifiers, returnType, $"operator {name}", parameters, implementation) { }
    }
}