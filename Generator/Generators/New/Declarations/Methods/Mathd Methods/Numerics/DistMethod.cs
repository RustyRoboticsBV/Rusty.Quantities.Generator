namespace Generators
{
    /// <summary>
    /// A distance method generator.
    /// </summary>
    public class DistMethod : MathdMethodPair
    {
        /* Constructors. */
        public DistMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Dist",
            new ScalarQuantityParameter(quantityName, "other"),
            new(new ScalarQuantityParameter(quantityName, "a"), new ScalarQuantityParameter(quantityName, "b")),
            new("Returns the absolute distance between this QUANTITY_NAME value and another.",
                "Returns the absolute distance between two QUANTITY_NAME values.",
                quantityName)) { }
    }
}