namespace Generators
{
    /// <summary>
    /// Represents a parameter of some scalar quantity type.
    /// </summary>
    public class ScalarQuantityParameter : ScalarParameter
    {
        /* Public properties. */
        public new ScalarQuantityType Type => base.Type as ScalarQuantityType;

        /* Constructors. */
        public ScalarQuantityParameter(ScalarQuantityType type, string name) : base(type, name) { }
    }
}