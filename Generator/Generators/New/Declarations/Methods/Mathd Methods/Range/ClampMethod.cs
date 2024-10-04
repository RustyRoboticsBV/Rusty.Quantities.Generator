namespace Generators
{
    /// <summary>
    /// An clamp method generator.
    /// </summary>
    public class ClampMethod : MathdMethodPair
    {
        /* Constructors. */
        public ClampMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Clamp",
            new(new ScalarQuantityParameter(quantityName, "min"), new ScalarQuantityParameter(quantityName, "max")),
            new(new ScalarQuantityParameter(quantityName, "value"), new ScalarQuantityParameter(quantityName, "min"), new ScalarQuantityParameter(quantityName, "max")),
            new($"Returns PRONOUN QUANTITY_NAME value clamped between a minimum and maximum value.",
                quantityName)) { }
    }
}