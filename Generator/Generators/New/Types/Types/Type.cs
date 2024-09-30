namespace Generators.New
{
    public abstract class Type
    {
        /* Public properties. */
        public string Name { get; set; }
        public string StructScope { get; set; }

        /* Constructors. */
        public Type(string name, string structScope = "")
        {
            Name = name;
            StructScope = structScope;
        }

        /* Public methods. */
        public abstract string CastTo(string value, Type to);

        public abstract Type Rescope(string scope);
    }
}