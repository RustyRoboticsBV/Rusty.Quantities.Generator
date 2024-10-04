namespace Generators
{
    /// <summary>
    /// A min method generator.
    /// </summary>
    public class MinMethod : MathdMethodPair
    {
        /* Constructors. */
        public MinMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Min",
            new ScalarQuantityParameter(quantityName, "other"),
            new(new ScalarQuantityParameter(quantityName, "a"), new ScalarQuantityParameter(quantityName, "b")),
            new("Returns the smallest of this QUANTITY_NAME value and another.",
                "Returns the smallest of two QUANTITY_NAME values.",
                quantityName)) { }
    }
}