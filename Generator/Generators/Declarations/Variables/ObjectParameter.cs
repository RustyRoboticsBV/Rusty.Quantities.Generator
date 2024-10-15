namespace Generators
{
    /// <summary>
    /// Represents a parameter of type System.Object.
    /// </summary>
    public class ObjectParameter : Variable
    {
        /* Public properties. */
        public new ObjectType Type => base.Type as ObjectType;

        /* Constructors. */
        public ObjectParameter() : base(new ObjectType(), "obj") { }

        /* Public methods. */
        public override string Generate()
        {
            return "object " + Name;
        }
    }
}
