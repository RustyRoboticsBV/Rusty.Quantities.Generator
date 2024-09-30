namespace Generators
{
    /// <summary>
    /// An arithmetic operator block generator.
    /// </summary>
    public class ArithmeticOperatorBlock : Generator
    {
        public string ClassName { get; set; }
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
            string code = "";
            foreach (string numeric in Numerics.Scalars)
            {
                if (code != "")
                    code += "\n";
                code += BinaryArithmeticOperator.Generate(new ReturnScalarQuantity(ClassName), op,
                    new ScalarNumericParameter(numeric, "a"),
                    new ScalarQuantityParameter(ClassName, "b"));
            }
            foreach (string numeric in Numerics.Scalars)
            {
                if (code != "")
                    code += "\n";
                code += BinaryArithmeticOperator.Generate(new ReturnScalarQuantity(ClassName), op,
                    new ScalarQuantityParameter(ClassName, "a"),
                    new ScalarNumericParameter(numeric, "b"));
            }
            if (code != "")
                code += "\n";
            code += BinaryArithmeticOperator.Generate(new ReturnScalarQuantity(ClassName), op,
                new ScalarQuantityParameter(ClassName, "a"),
                new ScalarQuantityParameter(ClassName, "b"));
            return code;
        }

        private string UnaryOperator(string op)
        {
            return UnaryArithmeticOperator.Generate(new ReturnScalarQuantity(ClassName), op,
                new ScalarQuantityParameter(ClassName, "value"));
        }
    }
}