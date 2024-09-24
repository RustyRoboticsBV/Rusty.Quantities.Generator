

namespace Generators
{
    /// <summary>
    /// A generator for the time quantity class.
    /// </summary>
    public class TimeGenerator : Generator
    {
        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = ClassGenerator.Generate("Time", "Represents a time quantity.");

            string props = "";
            code = code.Replace("//PROPS", props);

            string casts = "";
            code = code.Replace("//CASTS", casts);

            string math = "";
            code = code.Replace("//MATH", math);

            string formulaCode = "";
            foreach (FormulaSet formulaSet in formulas)
            {
                if (formulaCode != "")
                    formulaCode += "\n";
                if (formulaSet.ContainsFormula('t'))
                    formulaCode += FormulaMethodGenerator.Generate(formulaSet, "Time", 't', "Calculate");
            }
            code = code.Replace("//METHODS", formulaCode);

            FileWriter.Write("Time", code);
        }
    }
}
