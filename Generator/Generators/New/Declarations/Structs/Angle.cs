namespace Generators
{
    /// <summary>
    /// A angle quantity struct generator.
    /// </summary>
    public sealed class Angle : ScalarQuantityStruct
    {
        /* Constructors. */
        public Angle() : base(Quantities.Angle, "Represents an angle quantity.")
        {
            AddMethodPair(new ToDegreesMethod(Quantities.Angle));
            AddMethodPair(new ToRadiansMethod(Quantities.Angle));
        }
    }
}