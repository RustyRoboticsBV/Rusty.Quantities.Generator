namespace Generators
{
    public class VectorNumericParameter : VectorParameter
    {
        /* Constructors. */
        public VectorNumericParameter(VectorNumericType type, string name)
            : base(type, name) { }

        public VectorNumericParameter(string type, string name)
            : this(new VectorNumericType(type), name) { }

        /* Public methods. */
        public static string Generate(VectorNumericType type, string name)
        {
            return new VectorNumericParameter(type, name).Generate();
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