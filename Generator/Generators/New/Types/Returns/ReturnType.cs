namespace Generators
{
    /// <summary>
    /// A base class for all return statement generators.
    /// </summary>
    public abstract class ReturnType : Generator
    {
        /* Public properties. */
        public Type Type { get; set; }

        /* Constructors. */
        public ReturnType(Type type)
        {
            Type = type;
        }

        /* Public methods. */
        public abstract string Generate(Type fromType, string fromValue);

        public static ReturnType Create(Type type)
        {
            if (type is ScalarNumericType sn)
                return new ReturnScalarNumeric(sn);
            if (type is ScalarQuantityType sq)
                return new ReturnScalarQuantity(sq);
            throw new ArgumentOutOfRangeException();
        }
    }
}