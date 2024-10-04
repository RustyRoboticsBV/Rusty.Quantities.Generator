namespace Generators
{
    public abstract class ScalarParameter : Parameter
    {
        /* Public properties. */
        public new ScalarType Type => base.Type as ScalarType;

        /* Constructors. */
        public ScalarParameter(ScalarType type, string name) : base(type, name) { }

        /* Public methods. */
        public abstract string CastToCore();

        public override string UnaryOperator(string op)
        {
            return $"{op}{CastToCore()}";
        }

        public override string BinaryOperator(string op, Parameter other)
        {
            if (other is ScalarParameter scalar)
            {
                return $"{CastToCore()} {op} {scalar.CastToCore()}";
            }
            else if (other is VectorParameter vec)
            {
                return $"{CastToCore()} {op} {vec.ToNumericX()}, "
                    + $"{CastToCore()} {op} {vec.ToNumericY()}, "
                    + $"{CastToCore()} {op} {vec.ToNumericZ()}";
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}