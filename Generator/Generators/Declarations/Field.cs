namespace Generators
{
    /// <summary>
    /// A private field generator.
    /// </summary>
    public class Field : Id
    {
        /* Public properties. */
        public Type Type { get; set; }

        /* Constructors. */
        public Field(Type type, string name, string summary) : base(name, summary)
        {
            Type = type;
        }

        /* Protected methods. */
        protected sealed override string IdContents()
        {
            return $"private readonly {Type} {Name};";
        }
    }
}