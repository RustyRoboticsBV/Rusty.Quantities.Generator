using Generators.Scalars;

namespace Generators.Quantities
{
    /// <summary>
    /// A generator for the distance quantity class.
    /// </summary>
    public class DistanceGenerator : ClassGenerator
    {
        /* Private properties. */
        private FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public DistanceGenerator(FormulaSet[] formulas)
            : base()
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = new DistanceGenerator(formulas).GenerateClass("Distance", "Represents a distance quantity.");

            FileWriter.Write("Distance", code);
        }

        /* Protected methods. */
        protected override string GenerateArithmetic()
        {
            string code = MathOperatorGenerator.Generate(
                "Speed", "/", "Distance a, Time b", "return new Speed(a.value / (double)b);"
            );
            return base.GenerateArithmetic() + "\n" + code + "\n";
        }

        protected override string GenerateLocalMethods()
        {
            string code = MethodGenerator.Generate("public readonly",
                "Distance",
                "MoveTowards",
                "Distance to, Speed speed, Time time",
                "return Step(to, speed * time);",
                "Move towards some distance value, using a speed and time.");

            return base.GenerateLocalMethods() + "\n\n" + code;
        }

        protected override string GenerateStaticMethods()
        {
            string code = "";
            foreach (FormulaSet formulaSet in Formulas)
            {
                if (code != "")
                    code += "\n";
                if (formulaSet.ContainsFormula('a'))
                    code += FormulaMethodGenerator.Generate(formulaSet, "Distance", 's', "CalcFrom");
            }
            return base.GenerateStaticMethods() + "\n\n" + code;
        }
    }
}
