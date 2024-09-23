

namespace Generator
{
    /// <summary>
    /// A generator for the time quantity class.
    /// </summary>
    public static class TimeGenerator
    {
        /* Public methods. */
        public static void Generate(FormulaSet tsuv)
        {
            string code = ClassGenerator.Generate("Time", "Represents a time quantity.");

            code = code.Replace("//FORMULAS", tsuv.GenerateMethod("Time", 't', "Calculate", "uvs"));

            FileWriter.Write("Time", code);
        }
    }
}
