namespace Generators
{
    /// <summary>
    /// An floor method generator.
    /// </summary>
    public class FloorMethod : MathdMethodPair
    {
        /* Constructors. */
        public FloorMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Floor",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value rounded down to the nearest integer.",
                quantityName))
        { }
    }
}