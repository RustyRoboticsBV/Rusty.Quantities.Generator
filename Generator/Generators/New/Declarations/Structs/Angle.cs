namespace Generators
{
    /// <summary>
    /// A angle quantity struct generator.
    /// </summary>
    public sealed class Angle : ScalarQuantityStruct
    {
        /* Constructors. */
        public Angle() : base("Angle", "Represents an angle quantity.")
        {
            AddMethodPair(new ToDegreesMethod(Name));
            AddMethodPair(new ToRadiansMethod(Name));
        }
    }
}