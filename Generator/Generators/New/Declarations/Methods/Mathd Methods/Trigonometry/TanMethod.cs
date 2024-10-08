namespace Generators
{
    /// <summary>
    /// A tangent method generator.
    /// </summary>
    public class TanMethod : MathdMethodPair
    {
        /* Constructors. */
        public TanMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Tan",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the tangent of PRONOUN QUANTITY_NAME value.",
                quantity.Name)) { }
    }
}