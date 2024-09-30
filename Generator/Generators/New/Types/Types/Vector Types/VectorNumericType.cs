namespace Generators
{
    public class VectorNumericType : ScalarType
    {
        public VectorNumericType(string name) : this(name, name) { }
        public VectorNumericType(string name, string structScope = "") : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            throw new NotImplementedException();
        }

        public override Type Rescope(string scope)
        {
            throw new NotImplementedException();
        }
    }
}