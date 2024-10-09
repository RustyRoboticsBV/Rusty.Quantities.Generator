namespace Generators
{
    /// <summary>
    /// An binary arithmetic operator generator.
    /// </summary>
    public class BinaryArithmeticOperator : ArithmeticOperator
    {
        /* Public properties. */
        public Variable A => Parameters[0];
        public Variable B => Parameters[1];

        /* Constructors. */
        public BinaryArithmeticOperator(Type returnType, string name, Variable a, Variable b)
            : base(returnType, name, new ParameterList(a, b), "") { }

        /* Protected methods. */
        protected override string IdContents()
        {
            Implementation = Numerics.Core.Return(
                $"{A.CastTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}",
                ReturnType,
                GetScope()
            );
            return base.IdContents();
        }
    }
}