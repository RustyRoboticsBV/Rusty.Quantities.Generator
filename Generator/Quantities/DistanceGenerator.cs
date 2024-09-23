

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

            string formulaCode = "";
            foreach (FormulaSet formulaSet in formulas)
            {
                if (formulaCode != "")
                    formulaCode += "\n";
                formulaCode += formulaSet.GenerateMethod("Distance", 's', "Calculate", "uvast");
            }
            code = code.Replace("//FORMULAS", formulaCode);

            FileWriter.Write("Distance", code);
        }
    }
}
