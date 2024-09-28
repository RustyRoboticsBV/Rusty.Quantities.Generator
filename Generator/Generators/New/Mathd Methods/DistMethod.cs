namespace Generators.New
{
    /// <summary>
    /// A sign method generator.
    /// </summary>
    public class DistMethod : MathdMethodPair
    {
        /* Constructors. */
        public DistMethod(string quantityName) : base(quantityName, "Dist",
            new ThisParameter(quantityName, "other"),
            new(new ThisParameter(quantityName, "a"), new ThisParameter(quantityName, "b")),
            new("Returns the absolute distance between PRONOUN QUANTITY_NAME value and another.",
                "Returns the absolute distance between two QUANTITY_NAME values.",
                quantityName))
        { }

        /* Public methods. */
        public static string Generate(bool isStatic, string quantityName)
        {
            return new DistMethod(quantityName).Generate(isStatic);
        }
    }
}