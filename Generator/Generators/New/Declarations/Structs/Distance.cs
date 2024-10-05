namespace Generators
{
    /// <summary>
    /// A distance quantity struct generator.
    /// </summary>
    public sealed class Distance : ScalarQuantityStruct
    {
        /* Constructors. */
        public Distance(FormulaSet[] formulas) : base("Distance", "Represents a distance quantity.")
        {
            ArithmeticOperators.Space();
            AddBinaryOperator(typeof(Speed).Name, "/", typeof(Time).Name);

            StaticMethods.Space();
            AddFormulas(formulas, 's');
        }
    }
}