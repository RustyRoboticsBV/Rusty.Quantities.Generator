namespace Generators
{
    /// <summary>
    /// A 3D distance quantity struct generator.
    /// </summary>
    public sealed class Distance3D : Vector3QuantityStruct
    {
        /* Constructors. */
        public Distance3D(FormulaSet[] formulas) : base(Quantities.Distance3D, "Represents a 3D distance vector.") { }
    }
}