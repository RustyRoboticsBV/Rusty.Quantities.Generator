namespace Generators
{
    /// <summary>
    /// A to degrees method generator.
    /// </summary>
    public class ToDegreesMethod : MathdMethodPair
    {
        /* Constructors. */
        public ToDegreesMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "ToDegrees",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value converted from radians to degrees.",
                quantityName))
        {
            Local.Implementation = "return Mathd.Rad2Deg * value;";
            Static.Implementation = "return Mathd.Rad2Deg * value.value;";
        }
    }
}