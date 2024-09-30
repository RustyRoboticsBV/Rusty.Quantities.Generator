namespace Generators.New
{
    /// <summary>
    /// A summary that replaces looks for certain keywords in the summary text, and replaces them with other values.
    /// </summary>
    public class ContextualSummary : Summary
    {
        /* Public properties. */
        public string[] Keywords { get; set; }
        public string[] Values { get; set; }

        /* Constructors. */
        public ContextualSummary(string text, string[] keywords, string[] values)
        : base(text)
        {
            Keywords = keywords;
            Values = values;
        }

        /* Protected methods. */
        protected override string GetText()
        {
            if (Text == null)
                return "";

            string text = Text;
            for (int i = 0; i < Keywords.Length && i < Values.Length; i++)
            {
                text = text.Replace(Keywords[i], Values[i]);
            }

            return text;
        }
    }
}