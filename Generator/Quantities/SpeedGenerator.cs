

namespace Generator
{
    /// <summary>
    /// A generator for the speed quantity class.
    /// </summary>
    public static class SpeedGenerator
    {
        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = ClassGenerator.Generate("Speed", "Represents a speed quantity.");

            string props = "";
            code = code.Replace("//PROPS", props);

            string casts = "";
            code = code.Replace("//CASTS", casts);

            string math = "";
            code = code.Replace("//MATH", math);

            string formulaCode = "";
            foreach (FormulaSet formulaSet in formulas)
            {
                if (formulaSet.ContainsFormula('u'))
                {
                    if (formulaCode != "")
                        formulaCode += "\n";
                    formulaCode += formulaSet.GenerateMethod("Speed", 'u', "Calculate" + formulaSet.FindParameter('u').CamelCase);
                }

                if (formulaSet.ContainsFormula('v'))
                {
                    if (formulaCode != "")
                        formulaCode += "\n";
                    formulaCode += formulaSet.GenerateMethod("Speed", 'v', "Calculate" + formulaSet.FindParameter('v').CamelCase);
                }
            }
            code = code.Replace("//METHODS", formulaCode);

            FileWriter.Write("Speed", code);
        }
    }
}
