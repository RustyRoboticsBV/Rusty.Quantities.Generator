namespace Generators
{
    /// <summary>
    /// A return statement generators for scalar numeric types.
    /// </summary>
    public class ReturnScalarNumeric : ReturnType
    {
        /* Public properties. */
        public new ScalarNumericType Type => base.Type as ScalarNumericType;
        public Type FromType { get; set; }
        public string FromValue { get; set; }

        /* Constructors. */
        public ReturnScalarNumeric(ScalarNumericType type) : base(type) { }
        public ReturnScalarNumeric(string type) : base(new ScalarNumericType(type)) { }

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