

namespace Generators
{
    /// <summary>
    /// A generator for the acceleration quantity class.
    /// </summary>
    public class AccelerationGenerator : Generator
    {
        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = ClassGenerator.Generate("Acceleration", "Represents a acceleration quantity.");

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
                if (formulaSet.ContainsFormula('a'))
                    formulaCode += FormulaMethodGenerator.Generate(formulaSet, "Acceleration", 'a', "Calculate");
            }
            code = code.Replace("//METHODS", formulaCode);

            FileWriter.Write("Acceleration", code);
        }
    }
}
