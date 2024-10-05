namespace Generators
{
    /// <summary>
    /// A speed quantity struct generator.
    /// </summary>
    public sealed class Speed : ScalarQuantityStruct
    {
        /* Constructors. */
        public Speed(FormulaSet[] formulas) : base("Speed", "Represents a speed quantity.")
        {
            ArithmeticOperators.Space();
            AddBinaryOperator(typeof(Distance).Name, "*", typeof(Time).Name);
            AddBinaryOperator(typeof(Acceleration).Name, "/", typeof(Time).Name);

            StaticMethods.Space();
            AddFormulas(formulas, 'V');
            AddFormulas(formulas, 'v');
            AddFormulas(formulas, 'u');
        }
    }
}