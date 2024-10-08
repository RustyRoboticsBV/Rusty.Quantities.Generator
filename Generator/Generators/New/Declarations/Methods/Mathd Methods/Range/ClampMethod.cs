namespace Generators
{
    /// <summary>
    /// A clamp method generator.
    /// </summary>
    public class ClampMethod : MathdMethodPair
    {
        /* Constructors. */
        public ClampMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Clamp",
            new(new ScalarQuantityParameter(quantity, "min"), new ScalarQuantityParameter(quantity, "max")),
            new(new ScalarQuantityParameter(quantity, "value"), new ScalarQuantityParameter(quantity, "min"), new ScalarQuantityParameter(quantity, "max")),
            new($"Returns PRONOUN QUANTITY_NAME value clamped between a minimum and maximum value.",
                quantity.Name)) { }
    }
}