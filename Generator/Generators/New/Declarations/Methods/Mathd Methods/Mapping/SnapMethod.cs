namespace Generators
{
    /// <summary>
    /// An snap method generator.
    /// </summary>
    public class SnapMethod : MathdMethodPair
    {
        /* Constructors. */
        public SnapMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Snap",
            new(new ScalarQuantityParameter(quantityName, "offset"), new ScalarQuantityParameter(quantityName, "size")),
            new(new ScalarQuantityParameter(quantityName, "value"), new ScalarQuantityParameter(quantityName, "offset"), new ScalarQuantityParameter(quantityName, "size")),
            new($"Returns PRONOUN QUANTITY_NAME snapped to some grid. The grid has an offset from 0, and an interval size.",
                quantityName)) { }
    }
}