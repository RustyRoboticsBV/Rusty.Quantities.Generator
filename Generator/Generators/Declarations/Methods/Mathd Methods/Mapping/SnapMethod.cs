namespace Generators
{
    /// <summary>
    /// A snap method.
    /// </summary>
    public class SnapMethod : MathdMethodPair
    {
        /* Constructors. */
        public SnapMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Snap",
            new(new ScalarQuantityParameter(quantity, "offset"), new ScalarQuantityParameter(quantity, "size")),
            new(new ScalarQuantityParameter(quantity, "value"), new ScalarQuantityParameter(quantity, "offset"), new ScalarQuantityParameter(quantity, "size")),
            new($"Returns PRONOUN QUANTITY_NAME snapped to some grid. The grid has an offset from 0, and an interval size.",
                quantity.Name)) { }
    }
}