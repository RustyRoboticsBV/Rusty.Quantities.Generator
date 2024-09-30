namespace Generators
{
    /// <summary>
    /// A summary generator.
    /// </summary>
    public class Summary : Generator
    {
        /* Public properties. */
        public string? Text { get; set; }

        /* Casting oeprators. */
        public static implicit operator Summary(string text)
        {
            return new Summary(text);
        }

        /* Constructors. */
        public Summary()
        {
            Text = null;
        }

        public Summary(string text)
        {
            Text = text;
        }

        public Summary(Summary other)
        {
            Text = other.Text;
        }

        /* Public methods. */
        public override string Generate()
        {
            Console.WriteLine(GetText());
            return $"/// <summary>"
                + $"\n/// {GetText()}"
                + $"\n/// </summary>";
        }

        /* Protected methods. */
        protected virtual string GetText()
        {
            if (Text == null)
                return "";
            return Text;
        }
    }
}