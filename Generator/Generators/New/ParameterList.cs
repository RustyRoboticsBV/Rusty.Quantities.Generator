namespace Generators.New
{
    /// <summary>
    /// A parameter list generator.
    /// </summary>
    public sealed class ParameterList : Generator
    {
        /* Public properties. */
        public Parameter[] Parameters { get; set; }

        /* Constructors. */
        public ParameterList(params Parameter[] parameters)
        {
            Parameters = parameters;
        }

        /* Arithmatic operators. */
        public static ParameterList operator +(Parameter a, ParameterList b)
        {
            Parameter[] parameters = new Parameter[b.Parameters.Length + 1];
            parameters[0] = a;
            Array.Copy(b.Parameters, 0, parameters, 1, b.Parameters.Length);
            return new ParameterList(parameters);
        }

        public static ParameterList operator +(ParameterList a, Parameter b)
        {
            Parameter[] parameters = new Parameter[a.Parameters.Length + 1];
            Array.Copy(a.Parameters, parameters, a.Parameters.Length);
            parameters[^1] = b;
            return new ParameterList(parameters);
        }

        /* Public methods. */
        public static string Generate(Parameter[] contents)
        {
            return new ParameterList(contents).Generate();
        }

        public sealed override string Generate()
        {
            string code = "";
            foreach (Parameter parameter in Parameters)
            {
                string parameterCode = parameter.Generate();
                if (parameterCode != "")
                {
                    if (code != "")
                        code += ", ";
                    code += parameterCode;
                }
            }
            return "(" + code + ")";
        }
    }
}