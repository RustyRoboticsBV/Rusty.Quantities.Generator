namespace Generators
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
    }
}