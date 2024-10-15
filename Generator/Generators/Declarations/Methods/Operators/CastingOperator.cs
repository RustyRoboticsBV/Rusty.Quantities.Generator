namespace Generators
{
    /// <summary>
    /// A casting operator.
    /// </summary>
    public class CastingOperator : Operator
    {
        /* Constructors. */
        public CastingOperator(bool @implicit, Type returnType, Variable parameter)
            : base("static " + (@implicit ? "implicit" : "explicit"), returnType, returnType.Name,
                  new ParameterList(parameter), "")
        {
            HideReturnType = true;
        }

        /* Public methods. */
        protected override string IdContents()
        {
            Implementation = Parameters[0].Return(ReturnType);
            return base.IdContents();
        }
    }
}