namespace Generators
{
    /// <summary>
    /// A constructor block generator.
    /// </summary>
    public class ConstructorBlock : Generator
    {
        /* Public methods. */
        public string StructName { get; set; }

        /* Constructors. */
        public ConstructorBlock(string className)
        {
            StructName = className;
        }

        /* Public methods. */
        public static string Generate(string className)
        {
            return new ConstructorBlock(className).Generate();
        }

        public override string Generate()
        {
            string code = "";
            foreach (string type in Numerics.Scalars)
            {
                if (code != "")
                    code += "\n";
                code += Constructor.Generate(StructName, new ScalarNumericParameter(type, "value"),
                    $"this.value = {new ScalarNumericType(type).CastTo("value", Numerics.CoreType)};");
            }
            if (code != "")
                code += "\n";
            code += Constructor.Generate(StructName, new ScalarQuantityParameter(StructName, "value"),
                $"this.value = {new ScalarQuantityType(StructName).CastTo("value", Numerics.CoreType)};");
            return code;
        }
    }
}