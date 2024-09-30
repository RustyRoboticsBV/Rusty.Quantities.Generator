namespace Generators.New
{
    /// <summary>
    /// A fractional method generator.
    /// </summary>
    public class FracMethod : MathdMethodPair
    {
        /* Constructors. */
        public FracMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Frac",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns the fractional part of PRONOUN QUANTITY_NAME value.",
                quantityName))
        { }

        /* Public methods. */
        public static string Generate(bool isStatic, string quantityName)
        {
            return new FracMethod(quantityName).Generate(isStatic);
        }
    }
}