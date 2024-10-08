namespace Generators
{
    /// <summary>
    /// A distance quantity struct generator.
    /// </summary>
    public sealed class Distance : ScalarQuantityStruct
    {
        /* Constructors. */
        public Distance(FormulaSet[] formulas) : base(Quantities.Distance, "Represents a distance quantity.")
        {
            ArithmeticOperators.Space();
            AddBinaryOperator(Quantities.Speed, "/", Quantities.Time);

            StaticMethods.Space();
            AddFormulas(formulas, 's');
        }
    }
}