namespace Generators
{
    /// <summary>
    /// A #D vector struct generator.
    /// </summary>
    public abstract class Vector3QuantityStruct : VectorQuantityStruct
    {
        /* Constructors. */
        public Vector3QuantityStruct(VectorQuantityType type, string summary) : base(type, summary) { }

        /* Protected methods. */
        protected override string ToStringImpl()
        {
            return "return $\"({x}, {y}, {z})\";";
        }

        protected override string GetHashCodeImpl()
        {
            return "return (x.GetHashCode() * 13 + y.GetHashCode()) * 13 + z.GetHashCode();";
        }
    }
}