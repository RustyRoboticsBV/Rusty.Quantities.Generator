namespace Generators
{
    /// <summary>
    /// A cosine method generator.
    /// </summary>
    public class CosMethod : MathdMethodPair
    {
        /* Constructors. */
        public CosMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Cos",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the cosine of PRONOUN QUANTITY_NAME value.",
                quantity.Name)) { }
    }
}