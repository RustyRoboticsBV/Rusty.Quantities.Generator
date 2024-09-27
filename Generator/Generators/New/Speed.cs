using Generators.Scalars;

namespace Generators.New
{
    /// <summary>
    /// A speed quantity struct generator.
    /// </summary>
    public sealed class Speed : Scalar
    {
        /* Public properties. */
        public FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public Speed(FormulaSet[] formulas) : base("Speed", "Represents a speed quantity.")
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static string Generate(FormulaSet[] formulas)
        {
            return new Speed(formulas).Generate();
        }
    }
}