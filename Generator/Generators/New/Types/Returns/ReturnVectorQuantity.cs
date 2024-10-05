namespace Generators
{
    /// <summary>
    /// A return statement generators for vector quantity types.
    /// </summary>
    public class ReturnVectorQuantity : ReturnType
    {
        /* Public properties. */
        public new VectorQuantityType Type => base.Type as VectorQuantityType;
        public Type FromType { get; set; }
        public string FromValue { get; set; }

        /* Constructors. */
        public ReturnVectorQuantity(VectorQuantityType type) : base(type) { }
        public ReturnVectorQuantity(string type) : this(new VectorQuantityType(type)) { }

        /* Public methods. */
        public override string Generate()
        {
            return $"return {FromType.CastTo(FromValue, Type)};";
        }

        public override string Generate(Type fromType, string fromValue)
        {
            FromType = fromType;
            FromValue = fromValue;
            return Generate();
        }
    }
}