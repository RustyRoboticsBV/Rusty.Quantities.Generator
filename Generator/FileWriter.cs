

namespace Generators
{
    /// <summary>
    /// A generator for class C# script files.
    /// </summary>
    public static class FileWriter
    {
        /* Public methods. */
        public static void Write(string className, string code)
        {
            string path = $"../../../../Library/{className}.cs";
            Console.WriteLine("Creating file: " + path);
            string program = code;
            Console.WriteLine(program);
            File.WriteAllText(path, program);
        }
    }
}
