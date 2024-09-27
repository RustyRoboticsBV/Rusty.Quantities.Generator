namespace Generators.New
{
    /// <summary>
    /// A sign method generator.
    /// </summary>
    public class SignMethod : MathdMethodPair
    {
        /* Constructors. */
        public SignMethod(string quantityName) : base("int", "Sign", quantityName, "value",
            new($"Returns the mathematical sign of PRONOUN QUANTITY_NAME; 1 if positive, -1 if negative and 0 is equal to zero.",
                quantityName))
        { }

        /* Public methods. */
        public static string Generate(bool isStatic, string quantityName)
        {
            return new SignMethod(quantityName).Generate(isStatic);
        }
    }
}