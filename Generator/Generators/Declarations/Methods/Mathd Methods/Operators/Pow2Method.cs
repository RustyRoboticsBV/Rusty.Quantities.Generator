namespace Generators
{
    /// <summary>
    /// A power of two method generator.
    /// </summary>
    public class Pow2Method : MathdMethodPair
    {
        /* Constructors. */
        public Pow2Method(ScalarQuantityType quantity) : base(
            quantity,
            "Pow2",
            ScalarParameterList.Empty,
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the value of PRONOUN QUANTITY_NAME raised to the power of two.",
                quantity.Name)) { }
    }
}