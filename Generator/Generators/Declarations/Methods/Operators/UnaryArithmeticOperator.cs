namespace Generators
{
    /// <summary>
    /// An unary arithmetic operator generator.
    /// </summary>
    public class UnaryArithmeticOperator : ArithmeticOperator
    {
        /* Public properties. */
        public Variable Parameter => Parameters[0];

        /* Constructors. */
        public UnaryArithmeticOperator(Type returnType, string name, Variable parameter)
            : base(returnType, name, new ParameterList(parameter), "") { }

        /* Protected methods. */
        protected override string IdContents()
        {
            if (OpName == "++")
                Implementation = Numerics.Core.Return($"{Parameter.CastTo(Numerics.Core)} + 1", ReturnType, GetScope());
            else if (OpName == "--")
                Implementation = Numerics.Core.Return($"{Parameter.CastTo(Numerics.Core)} - 1", ReturnType, GetScope());
            else
                Implementation = Numerics.Core.Return($"{OpName}{Parameter.CastTo(Numerics.Core)}", ReturnType, GetScope());

            return base.IdContents();
        }
    }
}