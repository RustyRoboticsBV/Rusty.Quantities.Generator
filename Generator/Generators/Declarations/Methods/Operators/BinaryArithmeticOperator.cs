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
            // Scalar OP scalar.
            if (A is ScalarParameter && B is ScalarParameter)
            {
                Implementation = Numerics.Core.Return(
                    $"{A.CastTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}",
                    ReturnType,
                    GetScope()
                );
            }

            // Scalar OP vector.
            else if (A is ScalarParameter && B is VectorParameter vecB)
            {
                if (vecB.Size == 2)
                {
                    Implementation = B.Type.Return(
                        $"{A.CastTo(Numerics.Core)} {OpName} {vecB.CastXTo(Numerics.Core)}"
                            + $", {A.CastTo(Numerics.Core)} {OpName} {vecB.CastYTo(Numerics.Core)}",
                        ReturnType,
                        GetScope()
                    );
                }

                else if (vecB.Size == 3)
                {
                    Implementation = B.Type.Return(
                        $"{A.CastTo(Numerics.Core)} {OpName} {vecB.CastXTo(Numerics.Core)}"
                            + $", {A.CastTo(Numerics.Core)} {OpName} {vecB.CastYTo(Numerics.Core)}"
                            + $", {A.CastTo(Numerics.Core)} {OpName} {vecB.CastZTo(Numerics.Core)}",
                        ReturnType,
                        GetScope()
                    );
                }

                else if (vecB.Size == 4)
                {
                    Implementation = B.Type.Return(
                        $"{A.CastTo(Numerics.Core)} {OpName} {vecB.CastXTo(Numerics.Core)}"
                            + $", {A.CastTo(Numerics.Core)} {OpName} {vecB.CastYTo(Numerics.Core)}"
                            + $", {A.CastTo(Numerics.Core)} {OpName} {vecB.CastZTo(Numerics.Core)}"
                            + $", {A.CastTo(Numerics.Core)} {OpName} {vecB.CastWTo(Numerics.Core)}",
                        ReturnType,
                        GetScope()
                    );
                }
            }

            // Vector OP scalar.
            else if (A is VectorParameter vecA && B is ScalarParameter)
            {
                if (vecA.Size == 2)
                {
                    Implementation = A.Type.Return(
                        $"{vecA.CastXTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}"
                            + $", {vecA.CastYTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}",
                        ReturnType,
                        GetScope()
                    );
                }

                else if (vecA.Size == 3)
                {
                    Implementation = A.Type.Return(
                        $"{vecA.CastXTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}"
                            + $", {vecA.CastYTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}"
                            + $", {vecA.CastZTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}",
                        ReturnType,
                        GetScope()
                    );
                }

                else if (vecA.Size == 4)
                {
                    Implementation = A.Type.Return(
                        $"{vecA.CastXTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}"
                            + $", {vecA.CastYTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}"
                            + $", {vecA.CastZTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}"
                            + $", {vecA.CastWTo(Numerics.Core)} {OpName} {B.CastTo(Numerics.Core)}",
                        ReturnType,
                        GetScope()
                    );
                }
            }

            // Vector OP scalar.
            else if (A is VectorParameter vecA2 && B is VectorParameter vecB2)
            {
                // Get return type.
                Type returnType = A.Type;
                if (B.Type is VectorQuantityType)
                    returnType = B.Type;


                if (vecA2.Size == 2 && vecB2.Size == 2)
                {
                    Implementation = $"return new {returnType}("
                        + $"{vecA2.CastXTo(Numerics.Core)} {OpName} {vecB2.CastXTo(Numerics.Core)}"
                            + $", {vecA2.CastYTo(Numerics.Core)} {OpName} {vecB2.CastYTo(Numerics.Core)}"
                      + ");";
                }

                else if (vecA2.Size == 3 && vecB2.Size == 3)
                {
                    Implementation = $"return new {returnType}("
                        + $"{vecA2.CastXTo(Numerics.Core)} {OpName} {vecB2.CastXTo(Numerics.Core)}"
                            + $", {vecA2.CastYTo(Numerics.Core)} {OpName} {vecB2.CastYTo(Numerics.Core)}"
                            + $", {vecA2.CastZTo(Numerics.Core)} {OpName} {vecB2.CastZTo(Numerics.Core)}"
                      + ");";
                }

                else if (vecA2.Size == 4 && vecB2.Size == 4)
                {
                    Implementation = $"return new {returnType}("
                        + $"{vecA2.CastXTo(Numerics.Core)} {OpName} {vecB2.CastXTo(Numerics.Core)}"
                            + $", {vecA2.CastYTo(Numerics.Core)} {OpName} {vecB2.CastYTo(Numerics.Core)}"
                            + $", {vecA2.CastZTo(Numerics.Core)} {OpName} {vecB2.CastZTo(Numerics.Core)}"
                            + $", {vecA2.CastWTo(Numerics.Core)} {OpName} {vecB2.CastWTo(Numerics.Core)}"
                      + ");";
                }
            }

            return base.IdContents();
        }
    }
}