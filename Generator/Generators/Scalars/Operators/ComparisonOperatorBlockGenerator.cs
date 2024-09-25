

namespace Generators.Scalars
{
    public class ComparisonOperatorBlockGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string className)
        {
            return GenerateAllOps(className,
                new string[6] { "==", "!=", ">", "<", ">=", "<=" },
                new string[10] { "byte", "ushort", "uint", "ulong", "sbyte", "short", "int", "long", "float", "double" }
            );
        }

        /* Private methods. */
        private static string GenerateAllOps(string className, string[] operators, string[] types)
        {
            string code = "";
            foreach (string op in operators)
            {
                if (code != "")
                    code += "\n";
                code += GenerateOp(className, op, types);
            }
            return code;
        }

        private static string GenerateOp(string className, string opName, string[] types)
        {
            string code = "";
            foreach (string type in types)
            {
                if (code != "")
                    code += "\n";
                code += GenerateTC(type, opName, className);
            }
            foreach (string type in types)
            {
                if (code != "")
                    code += "\n";
                code += GenerateCT(className, opName, type);
            }
            if (code != "")
                code += "\n";
            code += GenerateCC(className, opName);

            return code;
        }

        private static string GenerateCC(string className, string opName)
        {
            return ComparisonOperatorGenerator.Generate(className, className, opName, "a.value", "b.value");
        }

        private static string GenerateTC(string typeName, string opName, string className)
        {
            return ComparisonOperatorGenerator.Generate(typeName, className, opName, "a", "b.value");
        }

        private static string GenerateCT(string typeName, string opName, string className)
        {
            return ComparisonOperatorGenerator.Generate(typeName, className, opName, "a.value", "b");
        }
    }
}
