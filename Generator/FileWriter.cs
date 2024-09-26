//#define PRINT_OUTPUT

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
#if PRINT_OUTPUT
            Console.WriteLine("Creating file: " + path);
#endif
            string program = code;
#if PRINT_OUTPUT
            Console.WriteLine(program);
#endif
            File.WriteAllText(path, program);
        }
    }
}
