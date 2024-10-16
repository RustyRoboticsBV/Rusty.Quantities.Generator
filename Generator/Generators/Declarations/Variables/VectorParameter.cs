namespace Generators
{
    public abstract class VectorParameter : Variable
    {
        /* Public properties. */
        public new VectorType Type => base.Type as VectorType;
        public int Size => Type.Size;

        /* Constructors. */
        public VectorParameter(VectorType type, string name) : base(type, name) { }

        /* Public methods. */
        /// <summary>
        /// Generate code for converting the vector parameter's x component to some type.
        /// </summary>
        public string CastXTo(ScalarType to)
        {
            return Type.CastXTo(Name, to, GetScope());
        }
        /// <summary>
        /// Generate code for converting the vector parameter's y component to some type.
        /// </summary>
        public string CastYTo(ScalarType to)
        {
            return Type.CastYTo(Name, to, GetScope());
        }
        /// <summary>
        /// Generate code for converting the vector parameter's z component to some type.
        /// </summary>
        public string CastZTo(ScalarType to)
        {
            return Type.CastZTo(Name, to, GetScope());
        }
        /// <summary>
        /// Generate code for converting the vector parameter's w component to some type.
        /// </summary>
        public string CastWTo(ScalarType to)
        {
            return Type.CastWTo(Name, to, GetScope());
        }
    }
}