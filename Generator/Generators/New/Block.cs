namespace Generators.New
{
    /// <summary>
    /// A code block generator.
    /// </summary>
    public sealed class Block : Generator
    {
        /* Public properties. */
        public string? Contents { get; set; }

        /* Constructors. */
        public Block(string? contents)
        {
            Contents = contents;
        }

        /* Public methods. */
        public static string Generate(string? contents)
        {
            return new Block(contents).Generate();
        }

        public sealed override string Generate()
        {
            if (Contents != null)
            {
                return "{"
                    + "\n" + Indent(Contents)
                    + "\n}";
            }
            else
                return "";
        }
    }
}