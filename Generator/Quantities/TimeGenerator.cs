

namespace Generator
{
    /// <summary>
    /// A generator for the time quantity class.
    /// </summary>
    public static class TimeGenerator
    {
        /* Public methods. */
        public static void Generate()
        {
            string code = ClassGenerator.Generate("Time", "Represents a time quantity.");
            FileWriter.Write("Time", code);
        }
    }
}
