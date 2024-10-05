namespace Generators
{
    public class VectorQuantityType : VectorType
    {
        public VectorQuantityType(string name) : this(name, name) { }
        public VectorQuantityType(string name, string structScope = "") : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            // Vector numerics.
            if (to is VectorNumericType vn)
                return $"new {Numerics.Vector3}((float){value}.x, (float){value}.y, (float){value}.z)";

            if (to is ScalarNumericType sn)
                return "VEC_Q_TO_SCL_NUM";
            if (to is ScalarNumericType sq)
                return "VEC_Q_TO_SCL_Q";
            if (to is VectorQuantityType vq)
                return $"new {to.Name}({value})";

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{value} from {Name} to {to.Name}");
        }

        public override Type Rescope(string scope)
        {
            return new VectorQuantityType(Name, scope);
        }
    }
}