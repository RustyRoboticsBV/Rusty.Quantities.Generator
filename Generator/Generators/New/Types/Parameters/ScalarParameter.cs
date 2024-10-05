namespace Generators
{
    public abstract class ScalarParameter : Parameter
    {
        /* Public properties. */
        public new ScalarType Type => base.Type as ScalarType;

        /* Constructors. */
        public ScalarParameter(ScalarType type, string name) : base(type, name) { }

        /* Public methods. */
        public abstract string CastToCore();
    }
}