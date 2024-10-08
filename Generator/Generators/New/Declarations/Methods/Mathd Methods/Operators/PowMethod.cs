namespace Generators
{
    /// <summary>
    /// A power of method generator.
    /// </summary>
    public class PowMethod : MathdMethodPair
    {
        /* Constructors. */
        public PowMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Pow",
            new ScalarNumericParameter(Numerics.Core, "power"),
            new(new ScalarQuantityParameter(quantity, "value"), new ScalarNumericParameter(Numerics.Core, "power")),
            new($"Returns the value of PRONOUN QUANTITY_NAME raised to the specified power.",
                quantity.Name)) { }
    }
}