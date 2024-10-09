namespace Generators
{
    /// <summary>
    /// A distance method generator.
    /// </summary>
    public class DistMethod : MathdMethodPair
    {
        /* Constructors. */
        public DistMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Dist",
            new ScalarQuantityParameter(quantity, "other"),
            new(new ScalarQuantityParameter(quantity, "a"), new ScalarQuantityParameter(quantity, "b")),
            new("Returns the absolute distance between this QUANTITY_NAME value and another.",
                "Returns the absolute distance between two QUANTITY_NAME values.",
                quantity.Name)) { }
    }
}