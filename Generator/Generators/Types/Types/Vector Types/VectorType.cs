namespace Generators
{
    public abstract class VectorType : Type
    {
        /* Public properties. */
        public ScalarType ScalarType { get; private set; }
        public int Size { get; private set; }

        /* Constructors. */
        public VectorType(string name, ScalarType scalarType, int size) : base(name)
        {
            ScalarType = scalarType;
            Size = size;
        }

        /* Publi methods. */
        public abstract string CastXTo(string vectorName, ScalarType type, string scope);
        public abstract string CastYTo(string vectorName, ScalarType type, string scope);
        public abstract string CastZTo(string vectorName, ScalarType type, string scope);
        public abstract string CastWTo(string vectorName, ScalarType type, string scope);
    }
}