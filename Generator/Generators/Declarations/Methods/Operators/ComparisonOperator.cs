namespace Generators
{
    /// <summary>
    /// An comparison operator generator.
    /// </summary>
    public class ComparisonOperator : Operator
    {
        /* Public properties. */
        public Variable A => Parameters[0];
        public Variable B => Parameters[1];

        /* Constructors. */
        public ComparisonOperator(string name, Variable a, Variable b)
            : base("static", Types.Bool, name, new(a, b), "") { }

        /* Private methods. */
        protected override string IdContents()
        {
            if (A is ScalarParameter && B is ScalarParameter)
                Implementation = $"return {A.CastTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)};";
            else if (A is VectorParameter vecA && B is VectorParameter vecB)
            {
                Implementation = $"return {vecA.CastXTo(Numerics.Core)} {OpName} {vecB.CastXTo(Numerics.Core)}"
                    + $" && {vecA.CastYTo(Numerics.Core)} {OpName} {vecB.CastYTo(Numerics.Core)}"
                    + $" && {vecA.CastZTo(Numerics.Core)} {OpName} {vecB.CastZTo(Numerics.Core)};";
            }
            return base.IdContents();
        }
    }
}