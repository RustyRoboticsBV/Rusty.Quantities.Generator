namespace Generators
{
    /// <summary>
    /// A distance quantity struct generator.
    /// </summary>
    public sealed class Distance : ScalarQuantityStruct
    {
        /* Public properties. */
        public FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public Distance(FormulaSet[] formulas) : base("Distance", "Represents a distance quantity.")
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static string Generate(FormulaSet[] formulas)
        {
            return new Distance(formulas).Generate();
        }

        /* Protected methods. */
        protected override string MathOpContents()
        {
            string code = "";
            code += BinaryArithmeticOperator.Generate(new ReturnScalarQuantity("Speed"), "/",
                new ScalarQuantityParameter("Distance", "a"),
                new ScalarQuantityParameter(new ScalarQuantityType("Time", "Distance"), "b"));
            return base.MathOpContents() + "\n\n" + code;
        }

        protected override string MethodContents()
        {
            string code = "";
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (formulaSet.HasFormula('s'))
                {
                    if (code != "")
                        code += "\n";
                    code += FormulaMethod.Generate(formulaSet, 's');
                }
            }
            return base.MethodContents() + "\n\n" + code;
        }
    }
}