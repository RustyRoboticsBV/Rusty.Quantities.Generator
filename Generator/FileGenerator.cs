

namespace Generator
{
    /// <summary>
    /// A generator for class C# script files.
    /// </summary>
    public static class FileGenerator
    {
        /* Public methods. */
        public static void Generate(string className, string classDesc)
        {
            string path = $"../../../../Library/{className}.cs";
            Console.WriteLine("Creating file: " + path);
            string program = ClassGenerator.Generate(className, classDesc);
            Console.WriteLine(program);
            File.WriteAllText(path, program);
        }
    }
}
