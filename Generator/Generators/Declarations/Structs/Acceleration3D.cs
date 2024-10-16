namespace Generators
{
    /// <summary>
    /// A 3D acceleration quantity struct generator.
    /// </summary>
    public sealed class Acceleration3D : Vector3QuantityStruct
    {
        /* Constructors. */
        public Acceleration3D(FormulaSet[] formulas) : base(Quantities.Acceleration3D, "Represents a 3D acceleration vector.") { }
    }
}