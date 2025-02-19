using System;

namespace Generators
{
    public class VectorNumericType : VectorType
    {
        /* Public properties. */
        public new ScalarNumericType ScalarType => base.ScalarType as ScalarNumericType;

        /* Constructors. */
        public VectorNumericType(string name, ScalarNumericType scalarType, int size) : base(name, scalarType, size) { }

        /* Public methods. */
        public override string CastTo(string value, Type to, string scope)
        {
            if (to is ScalarNumericType sn)
                return "VEC_NUM_TO_SCL_NUM";
            if (to is ScalarNumericType sq)
                return "VEC_NUM_TO_SCL_Q";
            if (to is VectorNumericType vn)
                return "VEC_NUM_TO_VEC_NUM";
            if (to is VectorQuantityType vq)
            {
                if (scope == to.Name)
                {
                    string x = $"{ScalarType.CastTo($"{value}.X", Numerics.Core, scope)}";
                    string y = $"{ScalarType.CastTo($"{value}.Y", Numerics.Core, scope)}";
                    string z = $"{ScalarType.CastTo($"{value}.Z", Numerics.Core, scope)}";
                    return $"new {vq.Name}({x}, {y}, {z})";
                }
                else
                    return "VEC_Q_TO_VEC_NUM, NOT IN SCOPE ";
            }
            if (to is StringType)
                return "\"{x.ToString()}, {y.ToString()}, {z.ToString()}\"";

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{value} from {Name} to {to.Name}");
        }

        public override string CastXTo(string vectorName, ScalarType type, string scope)
        {
            if (Size < 1)
                return type.Zero;
            else
                return ScalarType.CastTo($"{vectorName}.X", type, scope);
        }

        public override string CastYTo(string vectorName, ScalarType type, string scope)
        {
            if (Size < 2)
                return type.Zero;
            else
                return ScalarType.CastTo($"{vectorName}.Y", type, scope);
        }

        public override string CastZTo(string vectorName, ScalarType type, string scope)
        {
            if (Size < 3)
                return type.Zero;
            else
                return ScalarType.CastTo($"{vectorName}.Z", type, scope);
        }

        public override string CastWTo(string vectorName, ScalarType type, string scope)
        {
            if (Size < 4)
                return type.Zero;
            else
                return ScalarType.CastTo($"{vectorName}.W", type, scope);
        }
    }
}