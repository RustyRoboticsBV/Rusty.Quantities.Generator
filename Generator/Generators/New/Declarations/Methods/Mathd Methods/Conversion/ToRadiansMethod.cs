namespace Generators
{
    /// <summary>
    /// A to radians method generator.
    /// </summary>
    public class ToRadiansMethod : MathdMethodPair
    {
        /* Constructors. */
        public ToRadiansMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "ToRadians",
            new(),
            new ScalarQuantityParameter(quantityName, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value converted from degrees to radians.",
                quantityName))
        {
            Local.Implementation = "return Mathd.Deg2Rad * value;";
            Static.Implementation = "return Mathd.Deg2Rad * value.value;";
        }
    }
}