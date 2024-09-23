

namespace Generator
{
    /// <summary>
    /// A generator for the distance quantity class.
    /// </summary>
    public static class DistanceGenerator
    {
        /* Public methods. */
        public static void Generate(FormulaSet tsuv)
        {
            string code = ClassGenerator.Generate("Distance", "Represents a distance quantity.");

            code = code.Replace("//FORMULAS", tsuv.GenerateMethod("Distance", 's', "Calculate", "uvt"));

            FileWriter.Write("Distance", code);
        }
    }
}
