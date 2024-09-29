namespace Generators.New
{
    /// <summary>
    /// A return statement generators for strings.
    /// </summary>
    public class ReturnString : ReturnType
    {
        /* Public properties. */
        public new StringType Type => base.Type as StringType;
        public Type FromType { get; set; }
        public string FromValue { get; set; }

        /* Constructors. */
        public ReturnString() : base(new StringType()) { }

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