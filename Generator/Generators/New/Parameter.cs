namespace Generators.New
{
    /// <summary>
    /// A function parameter generator.
    /// </summary>
    public class Parameter : Generator
    {
        /* Public properties. */
        public string Type { get; set; }
        public string Name { get; set; }

        /* Constructors. */
        public Parameter(string type, string name)
        {
            Type = type;
            Name = name;
        }

        /* Public methods. */
        public static string Generate(string type, string text)
        {
            return new Parameter(type, text).Generate();
        }

        public override string Generate()
        {
            return $"{Type} {Name}";
        }
    }

    public abstract class ScalarParameter : Parameter
    {
        /* Constructors. */
        public ScalarParameter(string type, string name) : base(type, name) { }

        /* Public methods. */
        public abstract string ToNumeric();
    }

    public class NumericParameter : ScalarParameter
    {
        /* Constructors. */
        public NumericParameter(string type, string name) : base(type, name) { }

        /* Public methods. */
        public override string ToNumeric()
        {
            if (Type == "decimal")
                return $"(double){Name}";
            return Name;
        }
    }

    public class QuantityParameter : ScalarParameter
    {
        /* Public properties. */
        public bool This { get; set; }

        /* Constructors. */
        public QuantityParameter(string type, string name, bool @this = false) : base(type, name)
        {
            This = @this;
        }

        /* Public methods. */
        public override string ToNumeric()
        {
            if (This)
                return $"{Name}.value";
            else
                return $"(double){Name}";
        }
    }

    public class ThisParameter : QuantityParameter
    {
        /* Constructors. */
        public ThisParameter(string type, string name) : base(type, name, true) { }
    }
}