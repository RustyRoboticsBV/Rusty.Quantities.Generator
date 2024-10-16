namespace Generators
{
    /// <summary>
    /// A 2D acceleration quantity struct generator.
    /// </summary>
    public sealed class Acceleration2D : Vector2QuantityStruct
    {
        /* Constructors. */
        public Acceleration2D(FormulaSet[] formulas) : base(Quantities.Acceleration2D, "Represents a 2D acceleration vector.") { }
    }
}