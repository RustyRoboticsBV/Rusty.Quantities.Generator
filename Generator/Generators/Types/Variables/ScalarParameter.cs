namespace Generators
{
    /// <summary>
    /// Represents a parameter of a scalar type.
    /// </summary>
    public abstract class ScalarParameter : Variable
    {
        /* Public properties. */
        public new ScalarType Type => base.Type as ScalarType;

        /* Constructors. */
        public ScalarParameter(ScalarType type, string name) : base(type, name) { }
    }
}