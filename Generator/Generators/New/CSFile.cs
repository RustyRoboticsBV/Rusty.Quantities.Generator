//#define PRINT_OUTPUT
using System.IO;

namespace Generators.New
{
    /// <summary>
    /// A generator for class C# script files.
    /// </summary>
    public sealed class CSFile
    {
        /* Public properties. */
        public Struct Struct { get; set; }

        /* Constructors. */
        public CSFile(Struct @struct)
        {
            Struct = @struct;
        }

        /* Public methods. */
        public static void Generate(Struct @struct)
        {
            new CSFile(@struct).Generate();
        }

        public void Generate()
        {
            string path = $"../../../../Library/{Struct.Name}.cs";
#if PRINT_OUTPUT
            Console.WriteLine("Creating file: " + path);
#endif
            string program = Include.Generate("System")
                + "\n" +Include.Generate("Godot")
                + "\n\n" + Namespace.Generate("Rusty.Quantities", Struct);
#if PRINT_OUTPUT
            Console.WriteLine(program);
#endif
            File.WriteAllText(path, program);
        }
    }
}
