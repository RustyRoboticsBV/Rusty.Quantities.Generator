namespace Generators
{
    /// <summary>
    /// An square root method generator.
    /// </summary>
    public class SqrtMethod : MathdMethodPair
    {
        /* Constructors. */
        public SqrtMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Sqrt",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns the square root of PRONOUN QUANTITY_NAME value.",
                quantityName)) { }
    }
}