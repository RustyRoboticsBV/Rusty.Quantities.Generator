namespace Generators
{
    /// <summary>
    /// A private field generator.
    /// </summary>
    public class Field : Id
    {
        /* Public properties. */
        public string Type { get; set; }

        /* Constructors. */
        public Field(string type, string name, string? summary) : base(name, summary)
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