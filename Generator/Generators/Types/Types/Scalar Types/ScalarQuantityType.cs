using System;

namespace Generators
{
    /// <summary>
    /// Represents a scalar quantity struct type.
    /// </summary>
    public class ScalarQuantityType : ScalarType
    {
        /* Puclic properties. */
        public ScalarQuantityType(string name) : base(name) { }

        /* Public methods. */
        public override string CastTo(string instanceName, Type to, string scope)
        {
            // Scalar numerics.
            if (to is ScalarNumericType sn)
            {
                if (scope == Name)
                {
                    if (Numerics.Core.MustExplicitCastTo(sn))
                        return $"({sn}){instanceName}.value";
                    else
                        return $"{instanceName}.value";
                }
                else
                    return $"({sn}){instanceName}";
            }

            // Scalar quantities.
            else if (to is ScalarQuantityType sq)
            {
                if (Name == sq.Name)
                    return instanceName;
                else if (scope == Name)
                    return $"new {sq}({instanceName}.value)";
                else
                    return $"new {sq}(({Numerics.Core}){instanceName})";
            }

            // Vector numerics.
            else if (to is VectorNumericType vn)
            {
                string elementCode = CastTo(instanceName, Numerics.Core, scope);
                if (Numerics.Core.MustExplicitCastTo(vn.ScalarType))
                {
                    elementCode = Numerics.Core.CastTo(elementCode, vn.ScalarType, scope);
                    return $"new {vn}({elementCode}, {elementCode}, {elementCode})";
                }
                else
                    return $"new {vn}({elementCode}, {elementCode}, {elementCode})";
            }

            // Vector quantities.
            else if (to is VectorQuantityType vq)
            {
                string elementCode = CastTo(instanceName, vq.ScalarType, scope);
                return $"new {vq}({elementCode}, {elementCode}, {elementCode})";
            }

            // Strings.
            else if (to is StringType)
                return $"{instanceName}.ToString()";

            // Objects.
            else if (to is ObjectType)
                return $"(object){instanceName}";

            // Invalid types.
            if (to == null)
                throw new ArgumentOutOfRangeException($"{instanceName} from {Name} to null");
            else
                throw new ArgumentOutOfRangeException($"{instanceName} from {Name} to {to.Name}");
        }
    }
}