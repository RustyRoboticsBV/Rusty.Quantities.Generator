using CSharpGenerator;

namespace Generators
{
    /// <summary>
    /// A map method.
    /// </summary>
    public class MapMethod : MathdMethodPair
    {
        /* Constructors. */
        public MapMethod(ScalarQuantityType quantity) : base(
            quantity,
            "Map",
            new(new ScalarQuantityParameter(quantity, "fromMin"), new ScalarQuantityParameter(quantity, "fromMax"), new ScalarQuantityParameter(quantity, "toMin"), new ScalarQuantityParameter(quantity, "toMax")),
            new(new ScalarQuantityParameter(quantity, "value"), new ScalarQuantityParameter(quantity, "fromMin"), new ScalarQuantityParameter(quantity, "fromMax"), new ScalarQuantityParameter(quantity, "toMin"), new ScalarQuantityParameter(quantity, "toMax")),
            new($"Returns PRONOUN QUANTITY_NAME value mapped from one range to another. The value may be outside of the first range and the method will still work.",
                quantity.Name)) { }
    }
}