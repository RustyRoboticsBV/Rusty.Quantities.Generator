namespace Generators
{
    /// <summary>
    /// A ping-pong method.
    /// </summary>
    public class PingPongMethod : MathdMethodPair
    {
        /* Constructors. */
        public PingPongMethod(ScalarQuantityType quantity) : base(
            quantity,
            "PingPong",
            new(new ScalarQuantityParameter(quantity, "min"), new ScalarQuantityParameter(quantity, "max")),
            new(new ScalarQuantityParameter(quantity, "value"), new ScalarQuantityParameter(quantity, "min"), new ScalarQuantityParameter(quantity, "max")),
            new($"Returns PRONOUN QUANTITY_NAME mapped to some ping-ponging range between a minimum and maximum value.",
                quantity.Name)) { }
    }
}