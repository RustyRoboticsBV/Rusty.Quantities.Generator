namespace Generators
{
    /// <summary>
    /// A radians to degrees method.
    /// </summary>
    public class ToDegreesMethod : MathdMethodPair
    {
        /* Constructors. */
        public ToDegreesMethod(ScalarQuantityType quantity) : base(
            quantity,
            "ToDegrees",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value converted from radians to degrees.",
                quantity.Name))
        {
            Local.Implementation = "return Mathd.Rad2Deg * value;";
            Static.Implementation = "return Mathd.Rad2Deg * value.value;";
        }
    }
}