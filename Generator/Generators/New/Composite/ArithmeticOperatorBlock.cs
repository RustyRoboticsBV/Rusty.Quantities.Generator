namespace Generators.New
{
    /// <summary>
    /// An arithmetic operator block generator.
    /// </summary>
    public class ArithmeticOperatorBlock : Generator
    {
        public string ClassName { get; set; }
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
        public ArithmeticOperatorBlock(string className)
        {
            ClassName = className;
        }

        /* Public methods. */
        public static string Generate(string className)
        {
            return new ArithmeticOperatorBlock(className).Generate();
        }

        public override string Generate()
        {
            return Operator("+")
                + "\n" + Operator("-")
                + "\n" + Operator("*")
                + "\n" + Operator("/")
                + "\n" + Operator("%")
                + "\n" + OpClass("+")
                + "\n" + OpClass("-")
                + "\n" + OpClass("++")
                + "\n" + OpClass("--");
        }

        /* Private methods. */
        private string Operator(string op)
        {
            string code = "";
            foreach (string numeric in NumericTypes)
            {
                if (code != "")
                    code += "\n";
                code += NumOpClass(numeric, op);
            }
            foreach (string numeric in NumericTypes)
            {
                if (code != "")
                    code += "\n";
                code += ClassOpNum(op, numeric);
            }
            if (code != "")
                code += "\n";
            code += ClassOpClass(op);
            return code;
        }

        private string NumOpClass(string type, string op)
        {
            if (type == "decimal")
                return BinaryArithmeticOperator.Generate(ClassName, op, new(type, "a"), new(ClassName, "b"), $"return new {ClassName}((double)(a {op} (decimal)b.value));");
            else
                return BinaryArithmeticOperator.Generate(ClassName, op, new(type, "a"), new(ClassName, "b"), $"return new {ClassName}(a {op} b.value);");
        }

        private string ClassOpNum(string op, string type)
        {
            if (type == "decimal")
                return BinaryArithmeticOperator.Generate(ClassName, op, new(ClassName, "a"), new(type, "b"), $"return new {ClassName}((double)((decimal)a.value {op} b));");
            else
                return BinaryArithmeticOperator.Generate(ClassName, op, new(ClassName, "a"), new(type, "b"), $"return new {ClassName}(a.value {op} b);");
        }

        private string ClassOpClass(string op)
        {
            return BinaryArithmeticOperator.Generate(ClassName, op, new(ClassName, "a"), new(ClassName, "b"), $"return new {ClassName}(a.value {op} b.value);");
        }

        private string OpClass(string op)
        {
            return UnaryArithmeticOperator.Generate(ClassName, op, new(ClassName, "value"), $"return new {ClassName}({op}value.value);");
        }
    }
}