namespace Generators.New
{
    /// <summary>
    /// A function parameter generator.
    /// </summary>
    public sealed class Parameter : Generator
    {
        /* Public properties. */
        public string Type { get; set; }
        public string Name { get; set; }

        /* Constructors. */
        public Parameter(string type, string name)
        {
            Type = type;
            Name = name;
        }

        /* Public methods. */
        public static string Generate(string type, string text)
        {
            return new Parameter(type, text).Generate();
        }

        public override string Generate()
        {
            return $"{Type} {Name}";
        }
    }
}