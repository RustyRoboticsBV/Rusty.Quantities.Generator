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
            {
                if (scope == Name)
                {
                    string x = $"{ScalarType.CastTo($"{instanceName}.x", vn.ScalarType, scope)}";
                    string y = $"{ScalarType.CastTo($"{instanceName}.y", vn.ScalarType, scope)}";
                    string z = $"{ScalarType.CastTo($"{instanceName}.z", vn.ScalarType, scope)}";
                    return $"new {vn.Name}({x}, {y}, {z})";
                }
                else
                    return "VEC_Q_TO_VEC_NUM, NOT IN SCOPE ";
            }

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