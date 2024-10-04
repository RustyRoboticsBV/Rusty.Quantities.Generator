namespace Generators
{
    /// <summary>
    /// An ping-pong method generator.
    /// </summary>
    public class PingPongMethod : MathdMethodPair
    {
        /* Constructors. */
        public PingPongMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "PingPong",
            new(new ScalarQuantityParameter(quantityName, "min"), new ScalarQuantityParameter(quantityName, "max")),
            new(new ScalarQuantityParameter(quantityName, "value"), new ScalarQuantityParameter(quantityName, "min"), new ScalarQuantityParameter(quantityName, "max")),
            new($"Returns PRONOUN QUANTITY_NAME mapped to some ping-ponging range between a minimum and maximum value.",
                quantityName)) { }
    }
}