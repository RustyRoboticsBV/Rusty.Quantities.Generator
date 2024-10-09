namespace Generators
{
    /// <summary>
    /// A speed quantity struct generator.
    /// </summary>
    public sealed class Speed : ScalarQuantityStruct
    {
        /* Constructors. */
        public Speed(FormulaSet[] formulas) : base(Quantities.Speed, "Represents a speed quantity.")
        {
            ArithmeticOperators.Space();
            AddBinaryOperator(Quantities.Distance, "*", Quantities.Time);
            AddBinaryOperator(Quantities.Acceleration, "/", Quantities.Time);

            StaticMethods.Space();
            AddFormulas(formulas, 'V');
            AddFormulas(formulas, 'v');
            AddFormulas(formulas, 'u');
        }
    }
}