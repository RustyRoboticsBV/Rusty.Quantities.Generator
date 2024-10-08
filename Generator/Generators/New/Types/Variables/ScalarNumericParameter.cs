namespace Generators
{
    /// <summary>
    /// Represents a parameter of a scalar numeric type (int, uint, float, etc.).
    /// </summary>
    public class ScalarNumericParameter : ScalarParameter
    {
        /* Public properties. */
        public new ScalarNumericType Type => base.Type as ScalarNumericType;

        /* Constructors. */
        public ScalarNumericParameter(ScalarNumericType type, string name) : base(type, name) { }
    }
}