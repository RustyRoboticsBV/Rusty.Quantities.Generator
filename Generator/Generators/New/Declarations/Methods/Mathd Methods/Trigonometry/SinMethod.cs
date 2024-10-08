namespace Generators
{
    /// <summary>
    /// A sine method generator.
    /// </summary>
    public class SinMethod : MathdMethodPair
    {
        /* Constructors. */
        public SinMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Sin",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the sine of PRONOUN QUANTITY_NAME value.",
                quantity.Name)) { }
    }
}