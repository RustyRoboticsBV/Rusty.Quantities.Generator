namespace Generators
{
    /// <summary>
    /// An step method generator.
    /// </summary>
    public class StepMethod : MathdMethodPair
    {
        /* Constructors. */
        public StepMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Step",
            new(new ScalarQuantityParameter(quantityName, "target"), new ScalarQuantityParameter(quantityName, "delta")),
            new(new ScalarQuantityParameter(quantityName, "value"), new ScalarQuantityParameter(quantityName, "target"), new ScalarQuantityParameter(quantityName, "delta")),
            new($"Returns PRONOUN QUANTITY_NAME value, moved by some distance in the direction of some target value.",
                quantityName))
        { }
    }
}