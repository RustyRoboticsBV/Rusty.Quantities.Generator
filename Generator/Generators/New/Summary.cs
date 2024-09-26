namespace Generators.New
{
    /// <summary>
    /// A summary generator.
    /// </summary>
    public sealed class Summary : Generator
    {
        /* Public properties. */
        public string? Text { get; set; }

        /* Constructors. */
        public Summary(string? text)
        {
            Text = text;
        }

        /* Protected methods. */
        protected override string Generate()
        {
            return $"/// <summary>\n/// {Text}\n/// </summary>";
        }
    }
}