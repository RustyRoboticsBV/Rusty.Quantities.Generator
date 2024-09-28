namespace Generators.New
{
    /// <summary>
    /// A scalar-only parameter list generator.
    /// </summary>
    public class ScalarParameterList : ParameterList
    {
        /* Constructors. */
        public ScalarParameterList(params ScalarParameter[] parameters)
            : base(parameters) { }

        /* Casting operators. */
        public static implicit operator ScalarParameterList(ScalarParameter parameter)
        {
            return new ScalarParameterList(parameter);
        }

        public static implicit operator ScalarParameterList(ScalarParameter[] parameters)
        {
            return new ScalarParameterList(parameters);
        }
    }
}