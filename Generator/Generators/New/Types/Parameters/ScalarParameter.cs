namespace Generators.New
{
    public abstract class ScalarParameter : Parameter
    {
        /* Public properties. */
        public new ScalarType Type => base.Type as ScalarType;

        /* Constructors. */
        public ScalarParameter(ScalarType type, string name) : base(type, name) { }

        /* Public methods. */
        public abstract string ToNumeric();

        public override string UnaryOperator(string op)
        {
            return $"{op}{ToNumeric()}";
        }

        public override string BinaryOperator(string op, Parameter other)
        {
            if (other is ScalarParameter scalar)
            {
                return $"{ToNumeric()} {op} {scalar.ToNumeric()}";
            }
            else if (other is VectorParameter vec)
            {
                return $"{ToNumeric()} {op} {vec.ToNumericX()}, "
                    + $"{ToNumeric()} {op} {vec.ToNumericY()}, "
                    + $"{ToNumeric()} {op} {vec.ToNumericZ()}";
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}