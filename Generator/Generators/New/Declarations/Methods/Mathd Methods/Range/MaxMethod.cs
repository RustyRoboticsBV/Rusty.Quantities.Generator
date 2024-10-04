namespace Generators
{
    /// <summary>
    /// A max method generator.
    /// </summary>
    public class MaxMethod : MathdMethodPair
    {
        /* Constructors. */
        public MaxMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Max",
            new ScalarQuantityParameter(quantityName, "other"),
            new(new ScalarQuantityParameter(quantityName, "a"), new ScalarQuantityParameter(quantityName, "b")),
            new("Returns the largest of this QUANTITY_NAME value and another.",
                "Returns the largest of two QUANTITY_NAME values.",
                quantityName)) { }
    }
}