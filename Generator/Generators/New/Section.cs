namespace Generators
{
    /// <summary>
    /// A generator for code sections.
    /// </summary>
    public sealed class Section : Generator
    {
        /* Public properties. */
        public MultiLineComment Title { get; set; }
        public string? Contents { get; set; }

        /* Constructors. */
        public Section(string? title, string? contents)
        {
            Title = new(title);
            Contents = contents;
        }

        /* Public methods. */
        public static string Generate(string? title, string? contents)
        {
            return new Section(title, contents).Generate();
        }
        
        public sealed override string Generate()
        {
            if (Title.Text != null && Contents != null)
                return Title.Generate() + "\n" + Contents;
            else
                return "";
        }
    }
}