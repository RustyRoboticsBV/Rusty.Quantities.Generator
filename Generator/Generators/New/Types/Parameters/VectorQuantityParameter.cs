namespace Generators
{
    public class VectorQuantityParameter : VectorParameter
    {
        /* Constructors. */
        public VectorQuantityParameter(VectorQuantityType type, string name)
            : base(type, name) { }

        public VectorQuantityParameter(string type, string name)
            : this(new VectorQuantityType(type), name) { }

        /* Public methods. */
        public static string Generate(VectorQuantityType type, string name)
        {
            return new VectorQuantityParameter(type, name).Generate();
        }

        public override string Generate()
        {
            return $"{Type.Name} {Name}";
        }

        public override string ToNumericX()
        {
            return "_x";
        }

        public override string ToNumericY()
        {
            return "_y";
        }

        public override string ToNumericZ()
        {
            return "_z";
        }
    }
}