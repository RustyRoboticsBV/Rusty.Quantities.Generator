namespace Generators.New
{
    /// <summary>
    /// An casting operator generator.
    /// </summary>
    public class CastingOperator : Operator
    {
        /* Constructors. */
        public CastingOperator(bool @implicit, string name, Parameter parameter, string implementation)
            : base("static " + (@implicit ? "implicit" : "explicit"), null, name,
                  new ParameterList(parameter), implementation) { }

        /* Public methods. */
        public static string Generate(bool @implicit, string name, Parameter parameter, string implementation)
        {
            return new CastingOperator(@implicit, name, parameter, implementation).Generate();
        }
    }
}