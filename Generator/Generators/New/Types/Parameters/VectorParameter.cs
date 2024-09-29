namespace Generators.New
{
    public abstract class VectorParameter : Parameter
    {
        /* Public properties. */
        public new VectorType Type => base.Type as VectorType;

        /* Constructors. */
        public VectorParameter(VectorType type, string name) : base(type, name) { }

        /* Public methods. */
        public abstract string ToNumericX();
        public abstract string ToNumericY();
        public abstract string ToNumericZ();

        public override string UnaryOperator(string op)
        {
            return $"{op}{ToNumericX()}, {op}{ToNumericY()}, {op}{ToNumericZ()}";
        }

        public override string BinaryOperator(string op, Parameter other)
        {
            if (other is VectorParameter vec)
            {
                return $"{ToNumericX()} {op} {vec.ToNumericX()}, "
                    + $"{ToNumericY()} {op} {vec.ToNumericY()}, "
                    + $"{ToNumericZ()} {op} {vec.ToNumericZ()}";
            }
            else if (other is ScalarParameter scalar)
            {
                return $"{ToNumericX()} {op} {scalar.ToNumeric()}, "
                    + $"{ToNumericY()} {op} {scalar.ToNumeric()}, "
                    + $"{ToNumericZ()} {op} {scalar.ToNumeric()}";
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}