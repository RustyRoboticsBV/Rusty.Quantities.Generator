namespace Generators
{
    /// <summary>
    /// A velocity quantity struct generator.
    /// </summary>
    public sealed class Velocity : VectorQuantityStruct
    {
        /* Constructors. */
        public Velocity(FormulaSet[] formulas, ScalarQuantityStruct scalarType)
            : base("Velocity", new ScalarQuantityType(scalarType.Name, "Velocity"), "Represents a 3D speed quantity.")
        {
        }
    }
}