namespace Generators
{
    /// <summary>
    /// A fractional method generator.
    /// </summary>
    public class FracMethod : MathdMethodPair
    {
        /* Constructors. */
        public FracMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Frac",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the fractional part of PRONOUN QUANTITY_NAME value.",
                quantity.Name)) { }
    }
}