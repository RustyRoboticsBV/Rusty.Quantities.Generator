namespace Generators
{
    /// <summary>
    /// A 2D vector struct generator.
    /// </summary>
    public abstract class Vector2QuantityStruct : VectorQuantityStruct
    {
        /* Constructors. */
        public Vector2QuantityStruct(VectorQuantityType type, string summary) : base(type, summary)
        {
        }

        /* Protected methods. */
        protected override string ToStringImpl()
        {
            return "return $\"({x}, {y})\";";
        }

        protected override string GetHashCodeImpl()
        {
            return "return x.GetHashCode() * 13 + y.GetHashCode();";
        }
    }
}