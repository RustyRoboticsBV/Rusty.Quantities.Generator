

namespace Generator
{
    /// <summary>
    /// A generator for the acceleration quantity class.
    /// </summary>
    public static class AccelerationGenerator
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
                    formulaCode += formulaSet.GenerateMethod("Acceleration", 'a', "Calculate");
            }
            code = code.Replace("//METHODS", formulaCode);

            FileWriter.Write("Acceleration", code);
        }
    }
}
