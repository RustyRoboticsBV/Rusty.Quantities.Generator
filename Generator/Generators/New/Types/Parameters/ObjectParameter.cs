namespace Generators
{
    public class ObjectParameter : Parameter
    {
        public ObjectParameter() : base(new ObjectType(), "obj") { }

        public override string Generate()
        {
            return "object " + Name;
        }
    }
}
