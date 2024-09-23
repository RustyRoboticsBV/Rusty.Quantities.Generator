

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

            string formulaCode = "";
            foreach (FormulaSet formulaSet in formulas)
            {
                if (formulaCode != "")
                    formulaCode += "\n";
                formulaCode += formulaSet.GenerateMethod("Acceleration", 'a', "Calculate", "uvast");
            }
            code = code.Replace("//FORMULAS", formulaCode);

            FileWriter.Write("Acceleration", code);
        }
    }
}
