namespace Generators
{
    /// <summary>
    /// An wrap method generator.
    /// </summary>
    public class WrapMethod : MathdMethodPair
    {
        /* Constructors. */
        public WrapMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Wrap",
            new(new ScalarQuantityParameter(quantityName, "min"), new ScalarQuantityParameter(quantityName, "max")),
            new(new ScalarQuantityParameter(quantityName, "value"), new ScalarQuantityParameter(quantityName, "min"), new ScalarQuantityParameter(quantityName, "max")),
            new($"Returns PRONOUN QUANTITY_NAME mapped to some looping range between a minimum and maximum value.",
                quantityName)) { }
    }
}