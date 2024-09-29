namespace Generators.New
{
    public class VectorQuantityType : VectorType
    {
        public VectorQuantityType(string name) : this(name, name) { }
        public VectorQuantityType(string name, string structScope = "") : base(name, structScope) { }

        public override string CastTo(string value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}