namespace Generators
{
    /// <summary>
    /// A cosine method generator.
    /// </summary>
    public class CosMethod : MathdMethodPair
    {
        /* Constructors. */
        public CosMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Cos",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns the cosine of PRONOUN QUANTITY_NAME value.",
                quantityName))
        { }
    }
}