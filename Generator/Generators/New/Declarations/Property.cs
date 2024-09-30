namespace Generators
{
    /// <summary>
    /// A read-only property generator.
    /// </summary>
    public class Property : Id
    {
        /* Public properties. */
        public string Type { get; set; }
        public string Value { get; set; }

        /* Constructors. */
        public Property(string type, string name, string value, string? summary) : base(name, summary)
        {
            Type = type;
            Value = value;
        }

        /* Public methods. */
        public static string Generate(string type, string name, string value, string? summary = null)
        {
            return new Property(type, name, value, summary).Generate();
        }

        /* Protected methods. */
        protected sealed override string IdContents()
        {
            return $"public static {Type} {Name} => {Value};";
        }
    }
}