namespace Generators
{
    /// <summary>
    /// An casting operator generator.
    /// </summary>
    public class CastingOperator : Operator
    {
        /* Constructors. */
        public CastingOperator(bool @implicit, ReturnType returnType, Parameter parameter)
            : base("static " + (@implicit ? "implicit" : "explicit"), null, returnType.Type.Name,
                  new ParameterList(parameter), returnType.Generate(parameter.Type, parameter.Name)) { }

        /* Public methods. */
        public static string Generate(bool @implicit, ReturnType returnType, Parameter parameter)
        {
            return new CastingOperator(@implicit, returnType, parameter).Generate();
        }
    }
}