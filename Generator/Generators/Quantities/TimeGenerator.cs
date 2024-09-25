using Generators.Scalars;

namespace Generators.Quantities
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
