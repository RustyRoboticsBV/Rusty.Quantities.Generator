using System;

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
                string x = $"{CastXTo(instanceName, vn.ScalarType, scope)}";
                string y = $"{CastYTo(instanceName, vn.ScalarType, scope)}";
                string z = $"{CastZTo(instanceName, vn.ScalarType, scope)}";
                string w = $"{CastWTo(instanceName, vn.ScalarType, scope)}";

                if (vn.Size == 2)
                    return $"new {vn.Name}({x}, {y})";
                if (vn.Size == 3)
                    return $"new {vn.Name}({x}, {y}, {z})";
                if (vn.Size == 4)
                    return $"new {vn.Name}({x}, {y}, {z}, {w})";
                throw new ArgumentOutOfRangeException();
            }

            if (to is ScalarNumericType sn)
                return "VEC_Q_TO_SCL_NUM";
            if (to is ScalarNumericType sq)
                return "VEC_Q_TO_SCL_Q";
            if (to is VectorQuantityType)
                return $"new {to.Name}({instanceName})";

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{instanceName} from {Name} to {to.Name}");
        }

        public override string CastXTo(string vectorName, ScalarType type, string scope)
        {
            if (Size < 1)
                return type.Zero;
            else
            {
                if (scope == Name)
                    return Numerics.Core.CastTo($"{vectorName}.x", type, scope);
                else
                    return ScalarType.CastTo($"{vectorName}.X", type, scope);
            }
        }

        public override string CastYTo(string vectorName, ScalarType type, string scope)
        {
            if (Size < 2)
                return type.Zero;
            else
            {
                if (scope == Name)
                    return Numerics.Core.CastTo($"{vectorName}.y", type, scope);
                else
                    return ScalarType.CastTo($"{vectorName}.Y", type, scope);
            }
        }

        public override string CastZTo(string vectorName, ScalarType type, string scope)
        {
            if (Size < 3)
                return type.Zero;
            else
            {
                if (scope == Name)
                    return Numerics.Core.CastTo($"{vectorName}.z", type, scope);
                else
                    return ScalarType.CastTo($"{vectorName}.Z", type, scope);
            }
        }

        public override string CastWTo(string vectorName, ScalarType type, string scope)
        {
            if (Size < 4)
                return type.Zero;
            else
            {
                if (scope == Name)
                    return Numerics.Core.CastTo($"{vectorName}.w", type, scope);
                else
                    return ScalarType.CastTo($"{vectorName}.W", type, scope);
            }
        }
    }
}