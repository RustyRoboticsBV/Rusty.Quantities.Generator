namespace Generators
{
    /// <summary>
    /// An round method generator.
    /// </summary>
    public class RoundMethod : MathdMethodPair
    {
        /* Constructors. */
        public RoundMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Round",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value rounded to the nearest integer.",
                quantityName))
        { }
    }
}