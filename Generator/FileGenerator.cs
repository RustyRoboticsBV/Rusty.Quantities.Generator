

namespace Quantities
{
    public static class FileGenerator
    {
        public static string GetAbsPath(string filePath)
        {
            if (filePath.StartsWith("."))
                filePath = Path.GetFullPath(filePath);
            return filePath;
        }

        public static void Generate(string className, string classDesc)
        {
            string path = $"../../../../Library/{className}.cs";
            Console.WriteLine("Creating file: " + path);
            string program = Generator.Generate(className, classDesc);
            Console.WriteLine(program);
            File.WriteAllText(path, program);
        }
    }
}
