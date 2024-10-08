namespace Generators
{
    /// <summary>
    /// A ceil method generator.
    /// </summary>
    public class CeilMethod : MathdMethodPair
    {
        /* Constructors. */
        public CeilMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Ceil",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value rounded up to the nearest integer.",
                quantity.Name)) { }
    }
}