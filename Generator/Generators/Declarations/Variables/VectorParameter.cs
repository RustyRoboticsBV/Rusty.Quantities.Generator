namespace Generators
{
    public abstract class VectorParameter : Variable
    {
        /* Public properties. */
        public new VectorType Type => base.Type as VectorType;

        /* Constructors. */
        public VectorParameter(VectorType type, string name) : base(type, name) { }

        /* Public methods. */
        /// <summary>
        /// Generate code for converting the vector parameter's x component to some type.
        /// </summary>
        public virtual string CastXTo(Type to)
        {
            return Type.ScalarType.CastTo(Name + ".X", to, GetScope());
        }
        /// <summary>
        /// Generate code for converting the vector parameter's y component to some type.
        /// </summary>
        public virtual string CastYTo(Type to)
        {
            return Type.ScalarType.CastTo(Name + ".Y", to, GetScope());
        }
        /// <summary>
        /// Generate code for converting the vector parameter's z component to some type.
        /// </summary>
        public virtual string CastZTo(Type to)
        {
            return Type.ScalarType.CastTo(Name + ".Z", to, GetScope());
        }
        /// <summary>
        /// Generate code for converting the vector parameter's w component to some type.
        /// </summary>
        public virtual string CastWTo(Type to)
        {
            return Type.ScalarType.CastTo(Name + ".W", to, GetScope());
        }
    }
}