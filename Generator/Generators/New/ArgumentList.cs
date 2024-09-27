namespace Generators.New
{
    /// <summary>
    /// An argument list generator.
    /// </summary>
    public sealed class ArgumentList : Generator
    {
        /* Public properties. */
        public ParameterList Parameters { get; set; }

        /* Constructors. */
        public ArgumentList(ParameterList parameters)
        {
            Parameters = parameters;
        }

        /* Public methods. */
        public static string Generate(ParameterList parameters)
        {
            return new ArgumentList(parameters).Generate();
        }

        public sealed override string Generate()
        {
            string code = "";
            foreach (Parameter parameter in Parameters.Parameters)
            {
                string parameterCode = parameter.Generate();
                if (parameter.Name != "")
                {
                    if (code != "")
                        code += ", ";
                    code += parameter.Name;
                }
            }
            return code;
        }
    }
}