namespace Generators
{
    public class ObjectParameter : Parameter
    {
        public ObjectParameter() : base(new ObjectType(), "obj") { }

        public override string Generate()
        {
            return "object " + Name;
        }

        public override string BinaryOperator(string op, Parameter other)
        {
            throw new NotImplementedException();
        }

        public override string UnaryOperator(string op)
        {
            throw new NotImplementedException();
        }
    }
}
