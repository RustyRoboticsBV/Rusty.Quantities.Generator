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
            return ToStringMethod()
                + "\n" + EqualsMethod()
                + "\n" + GetHashCodeMethod()
                + "\n"
                + "\n" + SignMethod.Generate(false, Name)
                + "\n" + AbsMethod.Generate(false, Name)
                + "\n" + TruncateMethod.Generate(false, Name)
                + "\n" + FracMethod.Generate(false, Name)
                + "\n" + DistMethod.Generate(false, Name)
                + "\n"
                + "\n" + SignMethod.Generate(true, Name)
                + "\n" + AbsMethod.Generate(true, Name)
                + "\n" + TruncateMethod.Generate(true, Name)
                + "\n" + FracMethod.Generate(true, Name)
                + "\n" + DistMethod.Generate(true, Name);
        }

        /* Private methods. */
        private string ToStringMethod()
        {
            return Method.Generate("public", "override readonly", "string", "ToString", null, "return value.ToString();");
        }

        private string EqualsMethod()
        {
            return Method.Generate("public", "override readonly", "bool", "Equals", new Parameter("object", "obj"), $"return obj is {Name} {Name.ToLower()} && this == {Name.ToLower()};");
        }

        private string GetHashCodeMethod()
        {
            return Method.Generate("public", "override readonly", "int", "GetHashCode", null, "return value.GetHashCode();");
        }
    }
}