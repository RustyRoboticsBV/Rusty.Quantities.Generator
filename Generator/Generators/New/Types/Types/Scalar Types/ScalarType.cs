namespace Generators
{
    public abstract class ScalarType : Type
    {
        /* Constructors. */
        public ScalarType(string name, string structScope = "") : base(name, structScope) { }
    }
}