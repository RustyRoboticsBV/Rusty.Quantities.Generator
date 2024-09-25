using Generators.Scalars;

namespace Generators.Quantities
{
    /// <summary>
    /// A generator for the speed quantity class.
    /// </summary>
    public class SpeedGenerator : ClassGenerator
    {
        /* Private properties. */
        private FormulaSet ConstantFormula { get; set; }
        private FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public SpeedGenerator(FormulaSet constantFormula, FormulaSet[] formulas)
            : base()
        {
            ConstantFormula = constantFormula;
            Formulas = formulas;
        }

        /* Public methods. */
        public static void Generate(FormulaSet constantFormula, params FormulaSet[] formulas)
        {
            string code = new SpeedGenerator(constantFormula, formulas).GenerateClass("Speed", "Represents a speed quantity.");

            FileWriter.Write("Speed", code);
        }

        /* Protected methods. */
        protected override string GenerateStaticMethods()
        {
            string code = "";
            code += FormulaMethodGenerator.Generate(ConstantFormula, "Speed", 'v', "CalcConstSpeedFrom");
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (formulaSet.ContainsFormula('u'))
                {
                    if (code != "")
                        code += "\n";
                    code += FormulaMethodGenerator.Generate(formulaSet, "Speed", 'u', "Calc" + formulaSet.FindParameter('u').CamelCase + "From");
                }
            }
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (formulaSet.ContainsFormula('v'))
                {
                    if (code != "")
                        code += "\n";
                    code += FormulaMethodGenerator.Generate(formulaSet, "Speed", 'v', "Calc" + formulaSet.FindParameter('v').CamelCase + "From");
                }
            }
            return base.GenerateStaticMethods() + "\n\n" + code;
        }
    }
}
