using Generators.Generic;

namespace Generators.Vectors
{
    /// <summary>
    /// A generator for a quantity class.
    /// </summary>
    public class ClassGenerator : Generic.ClassGenerator
    {
        protected string ScalarName { get; set; }

        /* Constructors. */
        public ClassGenerator(string className, string scalarName, string summary) : base(className, summary)
        {
            ScalarName = scalarName;
        }

        /* Public methods. */
        public static string Generate(string className, string scalarName, string summary)
        {
            ClassGenerator generator = new(className, scalarName, summary);
            return generator.GenerateClass();
        }

        /* Protected methods. */
        protected override string GenerateField()
        {
            return Indent + $"private {ScalarName} x;"
                + "\n" + Indent + $"private {ScalarName} y;"
                + "\n" + Indent + $"private {ScalarName} z;";
        }

        protected override string GenerateProperties()
        {
            return QuantityPropertyGenerator.Generate(ClassName, "Zero", "0.0, 0.0, 0.0", "(0, 0, 0)")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "One", "1.0, 1.0, 1.0", "(1, 1, 1)")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "Left", "-1.0, 0.0, 0.0", "(-1, 0, 0)")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "Right", "1.0, 0.0, 0.0", "(1, 0, 0)")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "Down", "0.0, -1.0, 0.0", "(0, -1, 0)")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "Up", "0.0, 1.0, 0.0", "(0, 1, 0)")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "Back", "0.0, 0.0, -1.0", "(0, 0, -1)")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "Forward", "0.0, 0.0, 1.0", "(0, 0, 1)")
            + "\n";
        }

        protected override sealed string GenerateConstructor()
        {
            return Indent + $"public {ClassName}({ScalarName} x, {ScalarName} y, {ScalarName} z)"
            + "\n" + Indent + "{"
            + "\n" + MethodIndent + "this.x = x;"
            + "\n" + MethodIndent + "this.y = y;"
            + "\n" + MethodIndent + "this.z = z;"
            + "\n" + Indent + "}"
            + "\n";
        }

        protected override sealed string GenerateCasting()
        {
            return "\n";
        }

        protected override string GenerateArithmetic()
        {
            string code = MathOperatorGenerator.Generate(ClassName);
            if (ScalarName != "double")
            {
                code += "\n\n" + MathOperatorGenerator.Generate(ClassName, "*", $"{ClassName} a, {ScalarName} b", $"return new {ClassName}(a.x * b, a.y * b, a.z * b);");
                code += "\n" + MathOperatorGenerator.Generate(ClassName, "*", $"{ScalarName} a, {ClassName} b", $"return new {ClassName}(a * b.x, a * b.y, a * b.z);");
                code += "\n" + MathOperatorGenerator.Generate(ClassName, "/", $"{ClassName} a, {ScalarName} b", $"return new {ClassName}(a.x / b, a.y / b, a.z / b);");
            }
            return code + "\n";
        }

        protected override sealed string GenerateComparison()
        {
            return ComparisonOperatorGenerator.Generate(ClassName, ClassName, "==", "a", "b")
                + "\n" + ComparisonOperatorGenerator.Generate(ClassName, ClassName, "!=", "a", "b")
                + "\n"
                + "\n" + MethodGenerator.Generate("public readonly", ClassName, "Step", $"{ClassName} to, {ClassName} delta", $"return new {ClassName}(\n    {ScalarName}.Step(x, to.x, delta.x),\n    {ScalarName}.Step(y, to.y, delta.y),\n    {ScalarName}.Step(z, to.z, delta.z)\n);"); ;
        }

        protected override string GenerateLocalMethods()
        {
            return MethodGenerator.Generate("public override readonly", "bool", "Equals", "object? obj", $"return obj is {ClassName} {ClassName.ToLower()} && this == {ClassName.ToLower()};")
                + "\n" + MethodGenerator.Generate("public override readonly", "int", "GetHashCode", "", "return (x.GetHashCode() * 17 + y.GetHashCode()) * 17 + z.GetHashCode();")
                + "\n" + MethodGenerator.Generate("public override readonly", "string", "ToString", "", "return \"(\" + x.ToString() + \", \" + y.ToString() + \", \" + z.ToString() + \")\";")
                + "\n"
                + "\n" + MethodGenerator.Generate("public static", ClassName, "Step", $"{ClassName} from, {ClassName} to, {ClassName} delta", $"return new {ClassName}(\n    {ScalarName}.Step(from.x, to.x, delta.x),\n    {ScalarName}.Step(from.y, to.y, delta.y),\n    {ScalarName}.Step(from.z, to.z, delta.z)\n);");
        }

        protected override string GenerateStaticMethods()
        {
            return "";
        }
    }
}
