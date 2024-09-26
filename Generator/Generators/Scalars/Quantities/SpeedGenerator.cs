using Generators.Generic;

namespace Generators.Scalars
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
            : base("Speed", "Represents a speed quantity.")
        {
            ConstantFormula = constantFormula;
            Formulas = formulas;
        }

        /* Public methods. */
        public static void Generate(FormulaSet constantFormula, params FormulaSet[] formulas)
        {
            string code = new SpeedGenerator(constantFormula, formulas).GenerateClass();

            FileWriter.Write("Speed", code);
        }

        /* Protected methods. */
        protected override string GenerateArithmetic()
        {
            string code = MathOperatorGenerator.Generate(
                    "Distance", "*", "Speed a, Time b", "return new Distance(a.value * (double)b);")
                + "\n" + MathOperatorGenerator.Generate(
                        "Acceleration", "/", "Speed a, Time b", "return new Acceleration(a.value / (double)b);");
            return base.GenerateArithmetic() + "\n" + code + "\n";
        }

        protected override string GenerateLocalMethods()
        {
            string code = MethodGenerator.Generate("public readonly",
                "Speed",
                "AccelerateTowards",
                "Speed to, Acceleration acceleration, Time time",
                "return Step(to, acceleration * time);",
                "Move towards some speed value, using an acceleration and time.");

            return base.GenerateLocalMethods() + "\n\n" + code;
        }

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
