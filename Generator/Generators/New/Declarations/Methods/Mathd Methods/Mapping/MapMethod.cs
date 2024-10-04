namespace Generators
{
    /// <summary>
    /// An map method generator.
    /// </summary>
    public class MapMethod : MathdMethodPair
    {
        /* Constructors. */
        public MapMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Map",
            new(new ScalarQuantityParameter(quantityName, "fromMin"), new ScalarQuantityParameter(quantityName, "fromMax"), new ScalarQuantityParameter(quantityName, "toMin"), new ScalarQuantityParameter(quantityName, "toMax")),
            new(new ScalarQuantityParameter(quantityName, "value"), new ScalarQuantityParameter(quantityName, "fromMin"), new ScalarQuantityParameter(quantityName, "fromMax"), new ScalarQuantityParameter(quantityName, "toMin"), new ScalarQuantityParameter(quantityName, "toMax")),
            new($"Returns PRONOUN QUANTITY_NAME value mapped from one range to another. The value may be outside of the first range and the method will still work.",
                quantityName)) { }
    }
}