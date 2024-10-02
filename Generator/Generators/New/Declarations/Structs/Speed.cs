namespace Generators
{
    /// <summary>
    /// A speed quantity struct generator.
    /// </summary>
    public sealed class Speed : ScalarQuantityStruct
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

        /* Protected methods. */
        protected override string MathOpContents()
        {
            string code = "";
            code += BinaryArithmeticOperator.Generate(new ReturnScalarQuantity("Distance"), "*",
                new ScalarQuantityParameter("Speed", "a"),
                new ScalarQuantityParameter(new ScalarQuantityType("Time", "Speed"), "b"));
            code += "\n" + BinaryArithmeticOperator.Generate(new ReturnScalarQuantity("Acceleration"), "/",
                new ScalarQuantityParameter("Speed", "a"),
                new ScalarQuantityParameter(new ScalarQuantityType("Time", "Speed"), "b"));
            return base.MathOpContents() + "\n\n" + code;
        }

        protected override string MethodContents()
        {
            string code = "";
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (formulaSet.HasFormula('V'))
                {
                    if (code != "")
                        code += "\n";
                    code += FormulaMethod.Generate(formulaSet, 'V');
                }
            }
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (formulaSet.HasFormula('u'))
                {
                    if (code != "")
                        code += "\n";
                    code += FormulaMethod.Generate(formulaSet, 'u');
                }
            }
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (formulaSet.HasFormula('v'))
                {
                    if (code != "")
                        code += "\n";
                    code += FormulaMethod.Generate(formulaSet, 'v');
                }
            }
            return base.MethodContents() + "\n\n" + code;
        }
    }
}