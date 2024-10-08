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
            Implementation = $"return {A.CastTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)};";
            return base.IdContents();
        }
    }
}