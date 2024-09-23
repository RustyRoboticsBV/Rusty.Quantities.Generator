

namespace Generator
{
    /// <summary>
    /// A generator for the distance quantity class.
    /// </summary>
    public static class DistanceGenerator
    {
        /* Public methods. */
        public static void Generate()
        {
            string code = ClassGenerator.Generate("Distance", "Represents a distance quantity.");
            FileWriter.Write("Distance", code);
        }
    }
}
