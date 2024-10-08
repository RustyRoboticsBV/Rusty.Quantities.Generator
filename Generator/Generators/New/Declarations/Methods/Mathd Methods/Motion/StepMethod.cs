namespace Generators
{
    /// <summary>
    /// A step method generator.
    /// </summary>
    public class StepMethod : MathdMethodPair
    {
        /* Constructors. */
        public StepMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Step",
            new(new ScalarQuantityParameter(quantity, "target"), new ScalarQuantityParameter(quantity, "delta")),
            new(new ScalarQuantityParameter(quantity, "value"), new ScalarQuantityParameter(quantity, "target"), new ScalarQuantityParameter(quantity, "delta")),
            new($"Returns PRONOUN QUANTITY_NAME value, moved by some distance in the direction of some target value.",
                quantity.Name)) { }
    }
}