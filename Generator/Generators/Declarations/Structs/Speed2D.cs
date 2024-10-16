namespace Generators
{
    /// <summary>
    /// A 2D speed quantity struct generator.
    /// </summary>
    public sealed class Speed2D : VectorQuantityStruct
    {
        /* Constructors. */
        public Speed2D(FormulaSet[] formulas) : base(Quantities.Speed2D, "Represents a 2D speed vector.")
        {

        }
    }
}