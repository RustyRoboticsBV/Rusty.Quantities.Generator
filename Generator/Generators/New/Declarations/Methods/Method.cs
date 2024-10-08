namespace Generators
{
    /// <summary>
    /// A method generator.
    /// </summary>
    public class Method : Id
    {
        /* Public properties. */
        public string Accessor { get; set; }
        public string Modifiers { get; set; }
        public Type ReturnType { get; set; }
        public ParameterList Parameters { get; set; }
        public string Implementation { get; set; }

        public bool HideReturnType { get; protected set; }

        /* Constructors. */
        public Method(string accessor, string modifiers, Type returnType, string name, ParameterList parameters,
            string implementation, Summary summary = null) : base(name, summary)
        {
            Accessor = accessor;
            Modifiers = modifiers;
            ReturnType = returnType;
            Parameters = parameters;
            Implementation = implementation;

            if (Parameters != null)
                Parameters.Parent = this;
            if (Summary != null)
                Summary.Parent = this;
        }

        /* Protected methods. */
        protected override string IdContents()
        {
            string prefix = $"{Accessor} "
                + $"{(!string.IsNullOrEmpty(Modifiers) ? $"{Modifiers} " : "")}"
                + $"{((ReturnType != null && !HideReturnType) ? $"{ReturnType} " : "")}";

            return $"{prefix}{Name}({(Parameters != null ? Parameters.Generate() : "")})"
                + "\n" + Block.Generate(Implementation);
        }
    }
}