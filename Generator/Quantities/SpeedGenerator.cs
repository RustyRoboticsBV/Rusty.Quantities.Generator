

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

            string formulaCode = "";
            foreach (FormulaSet formulaSet in formulas)
            {
                if (formulaCode != "")
                    formulaCode += "\n";
                formulaCode += formulaSet.GenerateMethod("Speed", 'u', "CalculateStartSpeed", "uvast");
                if (formulaCode != "")
                    formulaCode += "\n";
                formulaCode += formulaSet.GenerateMethod("Speed", 'v', "CalculateEndSpeed", "uvast");
            }
            code = code.Replace("//FORMULAS", formulaCode);

            FileWriter.Write("Speed", code);
        }
    }
}
