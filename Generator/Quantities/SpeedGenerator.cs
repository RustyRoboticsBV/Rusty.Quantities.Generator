

namespace Generator
{
    /// <summary>
    /// A generator for the speed quantity class.
    /// </summary>
    public static class SpeedGenerator
    {
        /* Public methods. */
        public static void Generate(FormulaSet tsuv)
        {
            string code = ClassGenerator.Generate("Speed", "Represents a speed quantity.");

            code = code.Replace("//FORMULAS", tsuv.GenerateMethod("Speed", 'v', "Calculate", "ust"));

            FileWriter.Write("Speed", code);
        }
    }
}
