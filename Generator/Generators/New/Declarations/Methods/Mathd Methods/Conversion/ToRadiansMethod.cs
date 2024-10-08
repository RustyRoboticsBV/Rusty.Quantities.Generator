namespace Generators
{
    /// <summary>
    /// A degrees to radians method.
    /// </summary>
    public class ToRadiansMethod : MathdMethodPair
    {
        /* Constructors. */
        public ToRadiansMethod(ScalarQuantityType quantity) : base(
            quantity,
            "ToRadians",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns PRONOUN QUANTITY_NAME value converted from degrees to radians.",
                quantity.Name))
        {
            Local.Implementation = "return Mathd.Deg2Rad * value;";
            Static.Implementation = "return Mathd.Deg2Rad * value.value;";
        }
    }
}