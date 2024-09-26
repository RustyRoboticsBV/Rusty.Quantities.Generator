using Generators.Generic;

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for the acceleration quantity class.
    /// </summary>
    public class AccelerationGenerator : ClassGenerator
    {
        /* Private properties. */
        private FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public AccelerationGenerator(FormulaSet[] formulas)
            : base("Acceleration", "Represents an acceleration quantity.")
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = new AccelerationGenerator(formulas).GenerateClass();

            FileWriter.Write("Acceleration", code);
        }

        /* Protected methods. */
        protected override string GenerateArithmetic()
        {
            string code = MathOperatorGenerator.Generate("Speed", "*", "Acceleration a, Time b", "return a.value * (double)b;");
            return base.GenerateArithmetic() + "\n" + code + "\n";
        }

        protected override string GenerateStaticMethods()
        {
            string code = "";
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (code != "")
                    code += "\n";
                if (formulaSet.ContainsFormula('a'))
                    code += FormulaMethodGenerator.Generate(formulaSet, "Acceleration", 'a', "CalcFrom");
            }

            return base.GenerateStaticMethods() + "\n\n" + code;
        }
    }
}
