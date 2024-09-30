namespace Generators
{
    /// <summary>
    /// A multi-line comment generator.
    /// </summary>
    public sealed class MultiLineComment : Generator
    {
        /* Public properties. */
        public string? Text { get; set; }

        /* Constructors. */
        public MultiLineComment(string? text)
        {
            Text = text;
        }

        /* Public methods. */
        public static string Generate(string? text)
        {
            return new MultiLineComment(text).Generate();
        }

        public override string Generate()
        {
            return $"/* {Text} */";
        }
    }
}