namespace Generators
{
    /// <summary>
    /// A tangent method generator.
    /// </summary>
    public class TanMethod : MathdMethodPair
    {
        /* Constructors. */
        public TanMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Tan",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns the tangent of PRONOUN QUANTITY_NAME value.",
                quantityName))
        { }
    }
}