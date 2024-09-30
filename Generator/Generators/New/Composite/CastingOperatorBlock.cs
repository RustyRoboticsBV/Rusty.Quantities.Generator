namespace Generators
{
    /// <summary>
    /// A casting operator block generator.
    /// </summary>
    public class CastingOperatorBlock : Generator
    {
        public string StructName { get; set; }

        /* Constructors. */
        public CastingOperatorBlock(string structName)
        {
            StructName = structName;
        }

        /* Public methods. */
        public static string Generate(string structName)
        {
            return new CastingOperatorBlock(structName).Generate();
        }

        public override string Generate()
        {
            ScalarQuantityParameter thisParameter = new ScalarQuantityParameter(StructName, "value");
            string code = "";

            // To numeric.
            foreach (string type in Numerics.Scalars)
            {
                if (code != "")
                    code += "\n";
                code += CastingOperator.Generate(
                    !Numerics.MustCast(Numerics.Core, type),
                    new ReturnScalarNumeric(type),
                    new ScalarQuantityParameter(StructName, "value"));
            }

            // To string.
            if (code != "")
                code += "\n";
            code += CastingOperator.Generate(true, new ReturnString(), thisParameter);

            // From numeric.
            foreach (string type in Numerics.Scalars)
            {
                if (code != "")
                    code += "\n";
                code += CastingOperator.Generate(
                    !Numerics.MustCast(type, Numerics.Core),
                    new ReturnScalarQuantity(thisParameter.Type),
                    new ScalarNumericParameter(type, "value"));
            }

            return code;
        }
    }
}