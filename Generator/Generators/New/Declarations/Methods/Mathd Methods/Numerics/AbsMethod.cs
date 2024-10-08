namespace Generators
{
    /// <summary>
    /// An absolute method generator.
    /// </summary>
    public class AbsMethod : MathdMethodPair
    {
        /* Constructors. */
        public AbsMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Abs",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the absolute value of PRONOUN QUANTITY_NAME value.",
                quantity.Name)) { }
    }
}