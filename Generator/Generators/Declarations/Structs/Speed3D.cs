namespace Generators
{
    /// <summary>
    /// A speed3D quantity struct generator.
    /// </summary>
    public sealed class Speed3D : VectorQuantityStruct
    {
        /* Constructors. */
        public Speed3D(FormulaSet[] formulas) : base(Quantities.Velocity3D, "Represents a 3D speed vector.")
        {

        }
    }
}