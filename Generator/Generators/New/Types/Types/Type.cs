namespace Generators
{
    public abstract class Type
    {
        /* Public properties. */
        public string Name { get; set; }
        public string Scope { get; set; }

        /* Constructors. */
        public Type(string name, string structScope = "")
        {
            Name = name;
            Scope = structScope;
        }

        /* Public methods. */
        public abstract string CastTo(string value, Type to);

        public abstract Type Rescope(string scope);
    }
}