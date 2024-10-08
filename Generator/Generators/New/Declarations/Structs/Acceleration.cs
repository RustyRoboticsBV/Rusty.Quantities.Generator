namespace Generators
{
    /// <summary>
    /// A acceleration quantity struct generator.
    /// </summary>
    public sealed class Acceleration : ScalarQuantityStruct
    {
        /* Constructors. */
        public Acceleration(FormulaSet[] formulas) : base(Quantities.Acceleration, "Represents a acceleration quantity.")
        {
            ArithmeticOperators.Space();
            AddBinaryOperator(Quantities.Speed, "*", Quantities.Time);

            StaticMethods.Space();
            AddFormulas(formulas, 'a');
        }
    }
}