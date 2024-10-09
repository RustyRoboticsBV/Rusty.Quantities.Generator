namespace Generators
{
    /// <summary>
    /// A sign method generator.
    /// </summary>
    public class SignMethod : MathdMethodPair
    {
        /* Constructors. */
        public SignMethod(ScalarQuantityType quantity) : base(
            Numerics.Int,
            "Sign",
            new(),
            new ScalarQuantityParameter(quantity, "value"),
            new($"Returns the mathematical sign of PRONOUN QUANTITY_NAME value; 1 if positive, -1 if negative and 0 is equal to zero.",
                quantity.Name))
        {
            Local.Implementation = Local.Implementation.Replace("(int)", "");
            Static.Implementation = Static.Implementation.Replace("(int)", "");
        }
    }
}