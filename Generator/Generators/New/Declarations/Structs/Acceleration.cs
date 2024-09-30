namespace Generators.New
{
    /// <summary>
    /// A acceleration quantity struct generator.
    /// </summary>
    public sealed class Acceleration : ScalarQuantityStruct
    {
        /* Public properties. */
        public FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public Acceleration(FormulaSet[] formulas) : base("Acceleration", "Represents a acceleration quantity.")
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static string Generate(FormulaSet[] formulas)
        {
            return new Acceleration(formulas).Generate();
        }

        /* Protected methods. */
        protected override string MethodContents()
        {
            string code = "";
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (formulaSet.HasFormula('a'))
                {
                    if (code != "")
                        code += "\n";
                    code += FormulaMethod.Generate(formulaSet, 'a');
                }
            }
            return base.MethodContents() + "\n\n" + code;
        }
    }
}