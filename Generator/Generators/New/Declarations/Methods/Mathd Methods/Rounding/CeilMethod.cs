namespace Generators
{
    /// <summary>
    /// An ceil method generator.
    /// </summary>
    public class CeilMethod : MathdMethodPair
    {
        /* Constructors. */
        public CeilMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Ceil",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value rounded up to the nearest integer.",
                quantityName))
        { }
    }
}