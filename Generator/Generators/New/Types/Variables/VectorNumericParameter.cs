namespace Generators
{
    public class VectorNumericParameter : VectorParameter
    {
        /* Public properties. */
        public new VectorNumericType Type => base.Type as VectorNumericType;

        /* Constructors. */
        public VectorNumericParameter(VectorNumericType type, string name)
            : base(type, name) { }
    }
}