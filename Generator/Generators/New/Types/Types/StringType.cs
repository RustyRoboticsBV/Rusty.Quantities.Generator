namespace Generators.New
{
    public class StringType : Type
    {
        public StringType() : base("string") { }

        public override string CastTo(string value, Type to)
        {
            throw new NotImplementedException();
        }
    }
}