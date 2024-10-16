namespace Generators
{
    /// <summary>
    /// A 3D speed quantity struct generator.
    /// </summary>
    public sealed class Speed3D : VectorQuantityStruct
    {
        /* Constructors. */
        public Speed3D(FormulaSet[] formulas) : base(Quantities.Speed3D, "Represents a 3D speed vector.")
        {

        }
    }
}