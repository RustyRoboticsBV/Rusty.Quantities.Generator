namespace Generators
{
    public class ObjectType : Type
    {
        /* Constructors. */
        public ObjectType() : base("object", "object") { }

        /* Public methods. */
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