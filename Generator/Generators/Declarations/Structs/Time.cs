namespace Generators
{
    /// <summary>
    /// A time quantity struct generator.
    /// </summary>
    public sealed class Time : ScalarQuantityStruct
    {
        /* Constructors. */
        public Time(FormulaSet[] formulas) : base(Quantities.Time, "Represents a time quantity.")
        {
            ArithmeticOperators.Space();
            AddBinaryOperator(Quantities.Distance, "*", Quantities.Speed);
            AddBinaryOperator(Quantities.Speed, "*", Quantities.Acceleration);

            StaticMethods.Space();
            AddFormulas(formulas, 't');
        }
    }
}