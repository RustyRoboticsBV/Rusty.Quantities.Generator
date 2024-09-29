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
            return BinaryOperator("+")
                + "\n" + BinaryOperator("-")
                + "\n" + BinaryOperator("*")
                + "\n" + BinaryOperator("/")
                + "\n" + BinaryOperator("%")
                + "\n" + UnaryOperator("+")
                + "\n" + UnaryOperator("-")
                + "\n" + UnaryOperator("++")
                + "\n" + UnaryOperator("--");
        }

        /* Private methods. */
        private string BinaryOperator(string op)
        {
            /*string code = "";
            foreach (string numeric in NumericTypes)
            {
                if (code != "")
                    code += "\n";
                code += BinaryArithmeticOperator.Generate(ClassName, op, new NumericParameter(numeric, "b"), new ThisParameter(ClassName, "a"));
            }
            foreach (string numeric in NumericTypes)
            {
                if (code != "")
                    code += "\n";
                code += BinaryArithmeticOperator.Generate(ClassName, op, new ThisParameter(ClassName, "a"), new NumericParameter(numeric, "b"));
            }
            if (code != "")
                code += "\n";
            code += BinaryArithmeticOperator.Generate(ClassName, op, new ThisParameter(ClassName, "a"), new ThisParameter(ClassName, "b"));
            return code;*/
            return "";
        }

        private string UnaryOperator(string op)
        {
            return "";
            //return UnaryArithmeticOperator.Generate(ClassName, op, new ThisParameter(ClassName, "value"));
        }
    }
}