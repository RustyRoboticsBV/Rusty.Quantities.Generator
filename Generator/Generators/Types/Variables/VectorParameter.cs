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
        public string CastXTo(Type to, string scope)
        {
            return Type.ScalarType.CastTo(Name + ".x", to, scope);
        }
        /// <summary>
        /// Generate code for converting the vector parameter's y component to some type.
        /// </summary>
        public string CastYTo(Type to, string scope)
        {
            return Type.ScalarType.CastTo(Name + ".y", to, scope);
        }
        /// <summary>
        /// Generate code for converting the vector parameter's z component to some type.
        /// </summary>
        public string CastZTo(Type to, string scope)
        {
            return Type.ScalarType.CastTo(Name + ".z", to, scope);
        }
    }
}