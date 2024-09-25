using Generators.Generic;

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for the time quantity class.
    /// </summary>
    public class TimeGenerator : ClassGenerator
    {
        /* Private properties. */
        private FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public TimeGenerator(FormulaSet[] formulas)
            : base()
        {
            Formulas = formulas;
        }

        /* Public methods. */
        protected override string GenerateArithmetic()
        {
            string code = MathOperatorGenerator.Generate(
                    "Distance", "*", "Time a, Speed b", "return new Distance(a.value * (double)b);")
                + "\n" + MathOperatorGenerator.Generate(
                        "Speed", "*", "Time a, Acceleration b", "return new Speed(a.value * (double)b);");
            return base.GenerateArithmetic() + "\n" + code + "\n";
        }

        public static void Generate(params FormulaSet[] formulas)
        {
            string code = new TimeGenerator(formulas).GenerateClass("Time", "Represents a time quantity.");

            FileWriter.Write("Time", code);
        }

        /* Protected methods. */
        protected override string GenerateStaticMethods()
        {
            string code = "";
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (code != "")
                    code += "\n";
                if (formulaSet.ContainsFormula('a'))
                    code += FormulaMethodGenerator.Generate(formulaSet, "Time", 't', "CalcFrom");
            }
            return base.GenerateStaticMethods() + "\n\n" + code;
        }
    }
}
