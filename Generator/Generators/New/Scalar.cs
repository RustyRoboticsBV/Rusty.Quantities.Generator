namespace Generators.New
{
    /// <summary>
    /// A scalar struct generator.
    /// </summary>
    public abstract class Scalar : Struct
    {
        /* Constructors. */
        public Scalar(string name, string? summary) : base(name, summary) { }

        /* Protected methods. */
        protected override string FieldContents()
        {
            return "private double value;";
        }

        protected override string PropertyContents()
        {
            return Property.Generate(Name, "Zero", $"new {Name}(0.0)", $"A {Name} with the value 0.")
                + "\n" + Property.Generate(Name, "One", $"new {Name}(1.0)", $"A {Name} with the value 1.")
                + "\n" + Property.Generate(Name, "Pi", $"new {Name}(Mathd.Pi)", $"A {Name} with the value π.")
                + "\n" + Property.Generate(Name, "TwoPi", $"new {Name}(2.0 * Mathd.Pi)", $"A {Name} with the value 2π.");
        }

        protected override string ConstructorContents()
        {
            return Constructor.Generate(Name, new ParameterList(new Parameter("double", "value")), "this.value = value;");
        }

        protected override string CastOpContents()
        {
            return CastingOperatorBlock.Generate(Name);
        }

        protected override string MathOpContents()
        {
            return ArithmeticOperatorBlock.Generate(Name);
        }

        protected override string CompareOpContents()
        {
            return ComparisonOperatorBlock.Generate(Name);
        }

        protected override string MethodContents()
        {
            return SignMethod.Generate(false, Name)
                + "\n" + SignMethod.Generate(true, Name);
        }

        /* Private methods. */
        /*private string MathOperators()
        {
        }

        private string MathOperatorBlock(string @operator)
        {
            string str = ArithmeticOperator.Generate(Name, @operator,
                new(new Parameter(Name, "a"), new Parameter(Name, "b")), $"return a.value {@operator} b.value;");
        }*/
    }
}