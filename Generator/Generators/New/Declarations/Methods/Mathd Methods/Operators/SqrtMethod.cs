namespace Generators
{
    /// <summary>
    /// A square root method generator.
    /// </summary>
    public class SqrtMethod : MathdMethodPair
    {
        /* Constructors. */
        public SqrtMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Sqrt",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the square root of PRONOUN QUANTITY_NAME value.",
                quantity.Name)) { }
    }
}