namespace Generators
{
    /// <summary>
    /// A max method generator.
    /// </summary>
    public class MaxMethod : MathdMethodPair
    {
        /* Constructors. */
        public MaxMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Max",
            new ScalarQuantityParameter(quantity, "other"),
            new(new ScalarQuantityParameter(quantity, "a"), new ScalarQuantityParameter(quantity, "b")),
            new("Returns the largest of this QUANTITY_NAME value and another.",
                "Returns the largest of two QUANTITY_NAME values.",
                quantity.Name)) { }
    }
}