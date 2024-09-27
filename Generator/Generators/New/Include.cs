namespace Generators.New
{
    /// <summary>
    /// A namespace include directive generator.
    /// </summary>
    public sealed class Include : Generator
    {
        /* Public properties. */
        public string Name { get; set; }

        /* Constructors. */
        public Include(string name)
        {
            Name = name;
        }

        /* Public methods. */
        public static string Generate(string text)
        {
            return new Include(text).Generate();
        }

        public override string Generate()
        {
            return $"using {Name};";
        }
    }
}