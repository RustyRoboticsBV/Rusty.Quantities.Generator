

namespace Generators
{
    /// <summary>
    /// A generator for summary comments.
    /// </summary>
    public class SummaryGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string text)
        {
            return Indent + $"/// <summary>"
                + "\n" + Indent + $"/// {An(text)}"
                + "\n" + Indent + "/// </summary>";
        }

        /* Private methods. */
        private static string An(string str)
        {
            return str.Replace("A a", "An a")
                .Replace("A e", "An e")
                .Replace("A i", "An i")
                .Replace("A o", "An o")
                .Replace("A u", "An u")
                .Replace("A y", "An y")
                .Replace(" a a", " an a")
                .Replace(" a e", " an e")
                .Replace(" a i", " an i")
                .Replace(" a o", " an o")
                .Replace(" a u", " an u")
                .Replace(" a y", " an y");
        }
    }
}
