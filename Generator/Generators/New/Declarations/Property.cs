namespace Generators
{
    /// <summary>
    /// A read-only property generator.
    /// </summary>
    public class Property : Id
    {
        /* Public properties. */
        public string Modifiers { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        /* Constructors. */
        public Property(bool isStatic, string type, string name, string value, string? summary) : base(name, summary)
        {
            Modifiers = isStatic ? "static" : "readonly";
            Type = type;
            Value = value;
        }

        /* Protected methods. */
        protected sealed override string IdContents()
        {
            return $"public {Modifiers} {Type} {Name} => {Value};";
        }
    }
}