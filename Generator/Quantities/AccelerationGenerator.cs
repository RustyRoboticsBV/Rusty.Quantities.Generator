

namespace Generator
{
    /// <summary>
    /// A generator for the acceleration quantity class.
    /// </summary>
    public static class AccelerationGenerator
    {
        /* Public methods. */
        public static void Generate()
        {
            string code = ClassGenerator.Generate("Acceleration", "Represents a acceleration quantity.");
            FileWriter.Write("Acceleration", code);
        }
    }
}
