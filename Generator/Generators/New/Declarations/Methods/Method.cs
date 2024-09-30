namespace Generators
{
    /// <summary>
    /// A method generator.
    /// </summary>
    public class Method : Id
    {
        /* Public properties. */
        public string Accessor { get; set; }
        public string? Modifiers { get; set; }
        public string? ReturnType { get; set; }
        public ParameterList Parameters { get; set; }
        public string Implementation { get; set; }

        /* Constructors. */
        public Method(string accessor, string? modifiers, string? returnType, string name, ParameterList parameters,
            string implementation, Summary summary = null) : base(name, summary)
        {
            Accessor = accessor;
            Modifiers = modifiers;
            ReturnType = returnType;
            Parameters = parameters;
            Implementation = implementation;
        }

        /* Public methods. */
        public static string Generate(string accessor, string? modifiers, string? returnType, string name,
            ParameterList parameters, string implementation, Summary summary = null)
        {
            return new Method(accessor, modifiers, returnType, name, parameters, implementation, summary).Generate();
        }

        /* Protected methods. */
        protected override sealed string IdContents()
        {
            string prefix = $"{Accessor} "
                + $"{(Modifiers != null ? $"{Modifiers} " : "")}"
                + $"{(ReturnType != null ? $"{ReturnType} " : "")}";

            return $"{prefix}{Name}({(Parameters != null ? Parameters.Generate() : "")})"
                + "\n" + Block.Generate(Implementation);
        }
    }
}