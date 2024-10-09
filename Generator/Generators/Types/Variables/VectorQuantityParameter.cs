namespace Generators
{
    public class VectorQuantityParameter : VectorParameter
    {
        /* Public properties. */
        public new VectorQuantityType Type => base.Type as VectorQuantityType;

        /* Constructors. */
        public VectorQuantityParameter(VectorQuantityType type, string name) : base(type, name) { }
    }
}