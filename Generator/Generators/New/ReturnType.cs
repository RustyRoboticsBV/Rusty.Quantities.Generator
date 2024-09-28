namespace Generators.New
{
    /// <summary>
    /// A return statement generator.
    /// </summary>
    public class ReturnType : Generator
    {
        /* Public properties. */
        public string Name { get; set; }
        public bool HasConstructor { get; set; }
        public string Value { get; set; }

        /* Constructors. */
        public ReturnType(string name, bool hasConstructor = true)
        {
            Name = name;
            HasConstructor = hasConstructor;
            Value = "";
        }

        /* Casting operators. */
        public static implicit operator ReturnType(string name)
        {
            return new ReturnType(name);
        }

        /* Public methods. */
        public override string Generate()
        {
            if (HasConstructor)
                return $"return new {Name}({Value});";
            return $"return {Value};";
        }

        public string Generate(string value)
        {
            Value = value;
            return Generate();
        }
    }
}