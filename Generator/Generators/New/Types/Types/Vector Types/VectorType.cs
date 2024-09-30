namespace Generators
{
    public abstract class VectorType : Type
    {
        public VectorType(string name, string structScope = "") : base(name, structScope) { }
    }
}