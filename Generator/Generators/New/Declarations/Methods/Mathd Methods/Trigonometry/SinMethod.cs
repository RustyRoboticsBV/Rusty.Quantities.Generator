namespace Generators
{
    /// <summary>
    /// A sine method generator.
    /// </summary>
    public class SinMethod : MathdMethodPair
    {
        /* Constructors. */
        public SinMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Sin",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns the sine of PRONOUN QUANTITY_NAME value.",
                quantityName)) { }
    }
}