namespace Generators
{
    /// <summary>
    /// A return statement generators for scalar quantity types.
    /// </summary>
    public class ReturnScalarQuantity : ReturnType
    {
        /* Public properties. */
        public new ScalarQuantityType Type => base.Type as ScalarQuantityType;
        public Type FromType { get; set; }
        public string FromValue { get; set; }

        /* Constructors. */
        public ReturnScalarQuantity(ScalarQuantityType type) : base(type) { }
        public ReturnScalarQuantity(string type) : this(new ScalarQuantityType(type)) { }

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

        public static string Generate(Type fromType, string fromValue, ScalarQuantityType toType)
        {
            return new ReturnScalarQuantity(toType).Generate(fromType, fromValue);
        }
    }
}