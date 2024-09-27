using System;

namespace Generators.New
{
    /// <summary>
    /// A comparison operator block generator.
    /// </summary>
    public class ComparisonOperatorBlock : Generator
    {
        public string StructName { get; set; }

        public static string[] Operators => new string[] { "==", "!=", ">=", "<=", ">", "<" };
        public static string[] NumericTypes => new string[]
        {   
            "byte",
            "ushort",
            "uint",
            "ulong",
            "sbyte",
            "short",
            "int",
            "long",
            "float",
            "double",
            "decimal"
        };

        /* Constructors. */
        public ComparisonOperatorBlock(string structName)
        {
            StructName = structName;
        }

        /* Public methods. */
        public static string Generate(string structName)
        {
            return new ComparisonOperatorBlock(structName).Generate();
        }

        public override string Generate()
        {
            string code = "";
            foreach (string op in Operators)
            {
                if (code != "")
                    code += "\n";
                code += Operator(op);
            }
            return code;
        }

        /* Private methods. */
        public string Operator(string op)
        {
            string code = "";
            foreach (string type in NumericTypes)
            {
                if (code != "")
                    code += "\n";
                code += NumOpClass(type, op);
            }
            foreach (string type in NumericTypes)
            {
                if (code != "")
                    code += "\n";
                code += ClassOpNum(op, type);
            }
            if (code != "")
                code += "\n";
            code += ClassOpClass(op);
            return code;
        }

        private string NumOpClass(string type, string op)
        {
            if (type == "decimal")
                return ComparisonOperator.Generate(op, new Parameter(type, "a"), new Parameter(StructName, "b"), $"return a {op} (decimal)b.value;");
            else
                return ComparisonOperator.Generate(op, new Parameter(type, "a"), new Parameter(StructName, "b"), $"return a {op} b.value;");
        }

        private string ClassOpNum(string op, string type)
        {
            if (type == "decimal")
                return ComparisonOperator.Generate(op, new Parameter(StructName, "a"), new Parameter(type, "b"), $"return (decimal)a.value {op} b;");
            else
                return ComparisonOperator.Generate(op, new Parameter(StructName, "a"), new Parameter(type, "b"), $"return a.value {op} b;");
        }

        private string ClassOpClass(string op)
        {
            return ComparisonOperator.Generate(op, new Parameter(StructName, "a"), new Parameter(StructName, "b"), $"return a.value {op} b.value;");
        }
    }
}