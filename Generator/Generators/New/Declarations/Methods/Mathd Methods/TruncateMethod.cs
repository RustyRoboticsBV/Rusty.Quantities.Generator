namespace Generators
{
    /// <summary>
    /// An truncate method generator.
    /// </summary>
    public class TruncateMethod : MathdMethodPair
    {
        /* Constructors. */
        public TruncateMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Truncate",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns the integral part of PRONOUN QUANTITY_NAME value.",
                quantityName)) { }

        /* Public methods. */
        public static string Generate(bool isStatic, string quantityName)
        {
            return new TruncateMethod(quantityName).Generate(isStatic);
        }
    }
}