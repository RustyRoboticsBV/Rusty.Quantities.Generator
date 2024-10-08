namespace Generators
{
    /// <summary>
    /// The category of numeric types: signed integer, unsigned integer, floating-point and the special decimal type.
    /// </summary>
    public enum NumericCategory { Real, Integer, Unsigned, Decimal };

    /// <summary>
    /// Represents a built-in numeric type.
    /// </summary>
    public class ScalarNumericType : ScalarType
    {
        /* Public properties. */
        public NumericCategory Category { get; private set; }
        public byte ByteCount { get; private set; }

        /* Constructors. */
        public ScalarNumericType(string name, NumericCategory category, byte byteCount) : base(name)
        {
            Category = category;
            ByteCount = byteCount;
        }

        /* Public methods. */
        /// <summary>
        /// Whether or not we must use an explicit cast to convert from this numeric scalar to another.
        /// </summary>
        public bool MustExplicitCastTo(ScalarNumericType other)
        {
            return Category == NumericCategory.Integer && other.Category == NumericCategory.Unsigned
                || Category == NumericCategory.Unsigned && other.Category == NumericCategory.Integer && ByteCount == other.ByteCount
                || Category == NumericCategory.Real && other.Category != NumericCategory.Real
                || Category == NumericCategory.Real && other.Category == NumericCategory.Decimal
                || ByteCount > other.ByteCount;
        }

        public override string CastTo(string instanceName, Type to, string scope)
        {
            // Scalar numerics.
            if (to is ScalarNumericType sn)
            {
                if (MustExplicitCastTo(sn))
                    return $"({sn}){instanceName}";
                else
                    return instanceName;
            }

            // Scalar quantities.
            else if (to is ScalarQuantityType sq)
            {
                if (MustExplicitCastTo(Numerics.Core))
                    return $"new {sq}(({Numerics.Core}){instanceName})";
                else
                    return $"new {sq}({instanceName})";
            }

            // Vector numerics.
            else if (to is VectorNumericType vn)
            {
                if (MustExplicitCastTo(vn.ScalarType))
                {
                    string elementCode = $"({vn.ScalarType}){instanceName}";
                    return $"new {vn.Name}({elementCode}, {elementCode}, {elementCode})";
                }
                else
                    return $"new {vn.Name}({instanceName}, {instanceName}, {instanceName})";
            }

            // Vector quantities.
            else if (to is VectorQuantityType vq)
            {
                if (MustExplicitCastTo(Numerics.Core))
                {
                    string elementCode = $"({Numerics.Core}){instanceName}";
                    return $"new {vq}({elementCode}, {elementCode}, {elementCode})";
                }
                else
                    return $"new {vq}({instanceName}, {instanceName}, {instanceName})";
            }

            // Strings.
            else if (to is StringType)
                return $"{instanceName}.ToString()";

            // Objects.
            else if (to is ObjectType)
                return $"(object){instanceName}";

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{instanceName} from {Name} to {to.Name}");
        }
    }
}