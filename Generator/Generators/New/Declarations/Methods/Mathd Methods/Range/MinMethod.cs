namespace Generators
{
    /// <summary>
    /// A min method generator.
    /// </summary>
    public class MinMethod : MathdMethodPair
    {
        /* Constructors. */
        public MinMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Min",
            new ScalarQuantityParameter(quantity, "other"),
            new(new ScalarQuantityParameter(quantity, "a"), new ScalarQuantityParameter(quantity, "b")),
            new("Returns the smallest of this QUANTITY_NAME value and another.",
                "Returns the smallest of two QUANTITY_NAME values.",
                quantity.Name)) { }
    }
}