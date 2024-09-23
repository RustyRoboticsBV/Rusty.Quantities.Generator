

namespace Generator
{
    /// <summary>
    /// A generator for the acceleration quantity class.
    /// </summary>
    public static class AccelerationGenerator
    {
        /* Public methods. */
        public static void Generate(FormulaSet tuva)
        {
            string code = ClassGenerator.Generate("Acceleration", "Represents a acceleration quantity.");

            code = code.Replace("//FORMULAS", tuva.GenerateMethod("Acceleration", 'a', "Calculate", "uvt"));

            FileWriter.Write("Acceleration", code);
        }
    }
}
