namespace Generators
{
    /// <summary>
    /// A return statement generators for vector numeric types.
    /// </summary>
    public class ReturnVectorNumeric : ReturnType
    {
        /* Public properties. */
        public new VectorNumericType Type => base.Type as VectorNumericType;
        public Type FromType { get; set; }
        public string FromValue { get; set; }

        /* Constructors. */
        public ReturnVectorNumeric(VectorNumericType type) : base(type) { }
        public ReturnVectorNumeric(string type) : base(new VectorNumericType(type)) { }

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