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
    }
}