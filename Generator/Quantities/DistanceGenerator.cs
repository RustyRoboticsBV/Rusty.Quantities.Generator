

namespace Generator
{
    /// <summary>
    /// A generator for the distance quantity class.
    /// </summary>
    public static class DistanceGenerator
    {
        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = ClassGenerator.Generate("Distance", "Represents a distance quantity.");

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
                if (formulaSet.ContainsFormula('s'))
                    formulaCode += formulaSet.GenerateMethod("Distance", 's', "Calculate");
            }
            code = code.Replace("//METHODS", formulaCode);

            FileWriter.Write("Distance", code);
        }
    }
}
