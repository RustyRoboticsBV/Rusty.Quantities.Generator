namespace Generators
{
    /// <summary>
    /// Represents a scalar type.
    /// </summary>
    public abstract class ScalarType : Type
    {
        /* Public properties. */
        public string Zero { get; private set; } 

        /* Constructors. */
        public ScalarType(string name, string zero = "0") : base(name)
        {
            Zero = zero;
        }
    }
}