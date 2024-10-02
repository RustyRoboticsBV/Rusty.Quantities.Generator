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
        protected override string MathOpContents()
        {
            string code = "";
            code += BinaryArithmeticOperator.Generate(new ReturnScalarQuantity("Distance"), "*",
                new ScalarQuantityParameter("Time", "a"),
                new ScalarQuantityParameter(new ScalarQuantityType("Speed", "Time"), "b"));
            code += "\n" + BinaryArithmeticOperator.Generate(new ReturnScalarQuantity("Speed"), "*",
                new ScalarQuantityParameter("Time", "a"),
                new ScalarQuantityParameter(new ScalarQuantityType("Acceleration", "Time"), "b"));
            return base.MathOpContents() + "\n\n" + code;
        }

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