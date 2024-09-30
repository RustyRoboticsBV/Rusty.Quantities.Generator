namespace Generators
{
    /// <summary>
    /// A time quantity struct generator.
    /// </summary>
    public sealed class Time : ScalarQuantityStruct
    {
        /* Public properties. */
        public FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public Time(FormulaSet[] formulas) : base("Time", "Represents a time quantity.")
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static string Generate(FormulaSet[] formulas)
        {
            return new Time(formulas).Generate();
        }

        /* Protected methods. */
        protected override string MethodContents()
        {
            string code = "";
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (formulaSet.HasFormula('t'))
                {
                    if (code != "")
                        code += "\n";
                    code += FormulaMethod.Generate(formulaSet, 't');
                }
            }
            return base.MethodContents() + "\n\n" + code;
        }
    }
}