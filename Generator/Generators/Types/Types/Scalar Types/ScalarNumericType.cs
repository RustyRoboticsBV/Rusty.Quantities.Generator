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
        public ScalarNumericType(string name, NumericCategory category, byte byteCount, string zero = "0") : base(name, zero)
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
            if ((Category == NumericCategory.Integer || Category == NumericCategory.Unsigned) && other.Category == NumericCategory.Real)
                return false;

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
                return $"new {sq}({instanceName})";

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