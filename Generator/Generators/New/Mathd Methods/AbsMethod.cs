namespace Generators.New
{
    /// <summary>
    /// An absolute method generator.
    /// </summary>
    public class AbsMethod : MathdMethodPair
    {
        /* Constructors. */
        public AbsMethod(string quantityName) : base(quantityName, "Abs",
            new(),
            new ThisParameter(quantityName, "value"),
            new($"Returns the absolute value of PRONOUN QUANTITY_NAME value.",
                quantityName))
        { }

        /* Public methods. */
        public static string Generate(bool isStatic, string quantityName)
        {
            return new AbsMethod(quantityName).Generate(isStatic);
        }
    }
}