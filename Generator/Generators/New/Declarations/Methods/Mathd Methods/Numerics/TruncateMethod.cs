namespace Generators
{
    /// <summary>
    /// A truncate method generator.
    /// </summary>
    public class TruncateMethod : MathdMethodPair
    {
        /* Constructors. */
        public TruncateMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Truncate",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the integral part of PRONOUN QUANTITY_NAME value.",
                quantity.Name)) { }
    }
}