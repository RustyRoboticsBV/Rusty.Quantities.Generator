namespace Generators
{
    public class VectorNumericType : VectorType
    {
        public VectorNumericType(string name) : this(name, name) { }
        public VectorNumericType(string name, string structScope = "") : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            if (to is ScalarNumericType sn)
                return "VEC_NUM_TO_SCL_NUM";
            if (to is ScalarNumericType sq)
                return "VEC_NUM_TO_SCL_Q";
            if (to is VectorNumericType vn)
                return "VEC_NUM_TO_VEC_NUM";
            if (to is VectorQuantityType vq)
                return "VEC_NUM_TO_VEC_Q";
            if (to is StringType)
                return "\"{x.ToString()}, {y.ToString()}, {z.ToString()}\"";

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{value} from {Name} to {to.Name}");
        }

        public override Type Rescope(string scope)
        {
            return new VectorNumericType(Name, scope);
        }
    }
}