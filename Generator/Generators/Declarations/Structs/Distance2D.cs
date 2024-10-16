namespace Generators
{
    /// <summary>
    /// A 2D distance quantity struct generator.
    /// </summary>
    public sealed class Distance2D : Vector2QuantityStruct
    {
        /* Constructors. */
        public Distance2D(FormulaSet[] formulas) : base(Quantities.Distance2D, "Represents a 2D distance vector.") { }
    }
}