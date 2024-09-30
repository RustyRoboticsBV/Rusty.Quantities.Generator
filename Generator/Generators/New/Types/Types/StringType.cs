namespace Generators
{
    public class StringType : Type
    {
        public StringType() : base("string") { }

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