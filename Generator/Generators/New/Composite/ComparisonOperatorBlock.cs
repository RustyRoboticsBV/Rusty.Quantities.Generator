namespace Generators
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
            return ComparisonOperator.Generate(op,
                new ScalarNumericParameter(type, "a"),
                new ScalarQuantityParameter(StructName, "b"));
        }

        private string ClassOpNum(string op, string type)
        {
            return ComparisonOperator.Generate(op,
                new ScalarQuantityParameter(StructName, "a"),
                new ScalarNumericParameter(type, "b"));
        }

        private string ClassOpClass(string op)
        {
            return ComparisonOperator.Generate(op,
                new ScalarQuantityParameter(StructName, "a"),
                new ScalarQuantityParameter(StructName, "b"));
        }
    }
}