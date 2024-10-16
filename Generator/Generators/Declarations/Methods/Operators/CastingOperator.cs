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
            if (ReturnType is VectorType returnVector)
            {
                VectorParameter vector = Parameters[0] as VectorParameter;
                ScalarType scalarType = returnVector is VectorNumericType ? returnVector.ScalarType : Numerics.Core;
                if (returnVector.Size == 2)
                {
                    Implementation = $"return new {ReturnType}("
                        + $"{vector.CastXTo(scalarType)}"
                        + $", {vector.CastYTo(scalarType)}"
                        + $");";
                }
                else if (returnVector.Size == 3)
                {
                    Implementation = $"return new {ReturnType}("
                        + $"{vector.CastXTo(scalarType)}"
                        + $", {vector.CastYTo(scalarType)}"
                        + $", {vector.CastZTo(scalarType)}"
                        + $");";
                }
                else if (returnVector.Size == 4)
                {
                    Implementation = $"return new {ReturnType}("
                        + $"{vector.CastXTo(scalarType)}"
                        + $", {vector.CastYTo(scalarType)}"
                        + $", {vector.CastZTo(scalarType)}"
                        + $", {vector.CastWTo(scalarType)}"
                        + $");";
                }
            }
            else
                Implementation = Parameters[0].Return(ReturnType);

            return base.IdContents();
        }
    }
}