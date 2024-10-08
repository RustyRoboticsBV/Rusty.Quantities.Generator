namespace Generators
{
    /// <summary>
    /// A round method generator.
    /// </summary>
    public class RoundMethod : MathdMethodPair
    {
        /* Constructors. */
        public RoundMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Round",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value rounded to the nearest integer.",
                quantity.Name)) { }
    }
}