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

        /* Public methods. */
        public static string Generate(string type, string name, string value, string? summary = null)
        {
            return new Property(type, name, value, summary).Generate();
        }

        /* Protected methods. */
        protected sealed override string IdContents()
        {
            return $"private {Type} {Name};";
        }
    }
}