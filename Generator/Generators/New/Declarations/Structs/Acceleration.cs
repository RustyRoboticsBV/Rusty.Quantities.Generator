namespace Generators
{
    /// <summary>
    /// A acceleration quantity struct generator.
    /// </summary>
    public sealed class Acceleration : ScalarQuantityStruct
    {
        /* Constructors. */
        public Acceleration(FormulaSet[] formulas) : base("Acceleration", "Represents a acceleration quantity.")
        {
            AddBinaryOperator(typeof(Speed).Name, "*", typeof(Time).Name);

            AddFormulas(formulas, 'a');
        }
    }
}