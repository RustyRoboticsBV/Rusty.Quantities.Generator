namespace Generators
{
    /// <summary>
    /// A floor method generator.
    /// </summary>
    public class FloorMethod : MathdMethodPair
    {
        /* Constructors. */
        public FloorMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Floor",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value rounded down to the nearest integer.",
                quantity.Name)) { }
    }
}