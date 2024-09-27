namespace Generators.New
{
    /// <summary>
    /// A casting operator block generator.
    /// </summary>
    public class CastingOperatorBlock : Generator
    {
        public string StructName { get; set; }

        public static (string, bool, bool)[] NumericTypes => new (string, bool, bool)[]
        {   // type,        // to num,  // to struct
            new("byte",     false,      true ),
            new("ushort",   false,      true),
            new("uint",     false,      true),
            new("ulong",    false,      true),
            new("sbyte",    false,      true),
            new("short",    false,      true),
            new("int",      false,      true),
            new("long",     false,      true),
            new("float",    true,       true),
            new("double",   true,       true),
            new("decimal",  true,       false)
        };

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
            string code = "";
            foreach (var type in NumericTypes)
            {
                if (code != "")
                    code += "\n";
                code += ToNumeric(type.Item1, type.Item2);
            }
            if (code != "")
                code += "\n";
            code += CastingOperator.Generate(true, "string", new(StructName, "value"), "return value.ToString();");
            foreach (var type in NumericTypes)
            {
                if (code != "")
                    code += "\n";
                code += ToClass(type.Item1, type.Item3);
            }
            if (code != "")
                code += "\n";
            code += CastingOperator.Generate(false, StructName, new("string", "value"),
                $"try"
                + "\n{"
                + "\n" + Indent($"return new {StructName}(double.Parse(value));")
                + "\n}"
                + "\ncatch"
                + "\n{"
                + "\n" + Indent("return Zero;")
               + "\n}");
            return code;
        }

        /* Private methods. */
        private string ToClass(string from, bool @implicit)
        {
            if (from == "decimal")
                return CastingOperator.Generate(@implicit, StructName, new Parameter(from, "value"), $"return new {StructName}((double)value);");
            else
                return CastingOperator.Generate(@implicit, StructName, new Parameter(from, "value"), $"return new {StructName}(value);");
        }

        private string ToNumeric(string to, bool @implicit)
        {
            if (to == "double")
                return CastingOperator.Generate(@implicit, to, new Parameter(StructName, "value"), $"return value.value;");
            else
                return CastingOperator.Generate(@implicit, to, new Parameter(StructName, "value"), $"return ({to})value.value;");
        }
    }
}