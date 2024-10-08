namespace Generators
{
    /// <summary>
    /// A wrap method generator.
    /// </summary>
    public class WrapMethod : MathdMethodPair
    {
        /* Constructors. */
        public WrapMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Wrap",
            new(new ScalarQuantityParameter(quantity, "min"), new ScalarQuantityParameter(quantity, "max")),
            new(new ScalarQuantityParameter(quantity, "value"), new ScalarQuantityParameter(quantity, "min"), new ScalarQuantityParameter(quantity, "max")),
            new($"Returns PRONOUN QUANTITY_NAME mapped to some looping range between a minimum and maximum value.",
                quantity.Name)) { }
    }
}