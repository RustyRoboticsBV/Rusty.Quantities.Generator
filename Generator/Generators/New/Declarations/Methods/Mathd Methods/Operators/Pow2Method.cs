namespace Generators
{
    /// <summary>
    /// A power of two method generator.
    /// </summary>
    public class Pow2Method : MathdMethodPair
    {
        /* Constructors. */
        public Pow2Method(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Pow2",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns the value of PRONOUN QUANTITY_NAME raised to the power of two.",
                quantityName)) { }
    }
}