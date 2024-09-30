namespace Generators
{
    public class MathdSummary : GeneratorPair<ContextualSummary>
    {
        /* Constructors. */
        public MathdSummary(string text, string quantityName) : this(text, text, quantityName) { }

        public MathdSummary(string localText, string staticText, string quantityName)
            : this(localText, staticText, new string[] { "PRONOUN", "QUANTITY_NAME" },
                  new string[] { "this", quantityName.ToLower() },
                  new string[] { GetPronoun(quantityName.ToLower()), quantityName.ToLower() })
        { }

        private MathdSummary(string localText, string staticText, string[] keywords, string[] localValues, string[] staticValues)
            : base(new(localText, keywords, localValues), new(staticText, keywords, staticValues)) { }

        /* Private methods. */
        private static string GetPronoun(string quantityName)
        {
            if (quantityName == null || quantityName.Length == 0)
                return "a";
            switch (quantityName[0])
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                case 'y':
                    return "an";
                default:
                    return "a";
            }
        }
    }
}