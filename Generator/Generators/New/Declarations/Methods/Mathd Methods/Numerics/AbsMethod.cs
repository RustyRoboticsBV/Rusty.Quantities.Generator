namespace Generators
{
    /// <summary>
    /// An absolute method generator.
    /// </summary>
    public class AbsMethod : MathdMethodPair
    {
        /* Constructors. */
        public AbsMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Abs",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns the absolute value of PRONOUN QUANTITY_NAME value.",
                quantityName)) { }
    }
}