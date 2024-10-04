namespace Generators
{
    /// <summary>
    /// A time quantity struct generator.
    /// </summary>
    public sealed class Time : ScalarQuantityStruct
    {
        /* Constructors. */
        public Time(FormulaSet[] formulas) : base("Time", "Represents a time quantity.")
        {
            AddBinaryOperator(typeof(Distance).Name, "*", typeof(Speed).Name);
            AddBinaryOperator(typeof(Speed).Name, "*", typeof(Acceleration).Name);

            AddFormulas(formulas, 't');
        }
    }
}