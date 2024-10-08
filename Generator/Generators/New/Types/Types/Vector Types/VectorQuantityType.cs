namespace Generators
{
    public class VectorQuantityType : VectorType
    {
        /* Constructors. */
        public VectorQuantityType(string name, ScalarType scalarType, int size) : base(name, scalarType, size) { }

        /* Public methods. */
        public override string CastTo(string instanceName, Type to, string scope)
        {
            // Vector numerics.
            if (to is VectorNumericType vn)
                return $"new {Numerics.Vector3}((float){instanceName}.x, (float){instanceName}.y, (float){instanceName}.z)";

            if (to is ScalarNumericType sn)
                return "VEC_Q_TO_SCL_NUM";
            if (to is ScalarNumericType sq)
                return "VEC_Q_TO_SCL_Q";
            if (to is VectorQuantityType vq)
                return $"new {to.Name}({instanceName})";

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{instanceName} from {Name} to {to.Name}");
        }
    }
}