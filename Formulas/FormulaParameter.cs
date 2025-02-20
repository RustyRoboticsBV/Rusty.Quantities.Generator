namespace Rusty.Quantities.Generator
{
    public class FormulaParameter
    {
        public char Symbol { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string PascalCase => Name.Replace(" s", "S");
        public string CamelCase => Lowercase.Substring(0, 1) + PascalCase.Substring(1);
        public string Lowercase => Name.ToLower();

        public FormulaParameter(char symbol, string name) : this(symbol, name, name) { }

        public FormulaParameter(char symbol, string name, string @type)
        {
            Symbol = symbol;
            Name = name;
            Type = @type;
        }
    }
}