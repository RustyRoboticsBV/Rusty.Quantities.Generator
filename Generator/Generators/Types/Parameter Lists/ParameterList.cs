using System;

namespace Generators
{
    /// <summary>
    /// A parameter list generator.
    /// </summary>
    public class ParameterList : Generator
    {
        /* Public properties. */
        public Variable[] Parameters { get; set; }

        public int Count => Parameters.Length;
        public Variable this[int index] => Parameters[index];

        /* Constructors. */
        public ParameterList(params Variable[] parameters)
        {
            Parameters = parameters;

            foreach (Variable parameter in Parameters)
            {
                parameter.Parent = this;
            }
        }

        /* Casting operators. */
        public static implicit operator ParameterList(Variable value)
        {
            return new ParameterList(value);
        }

        /* Arithmatic operators. */
        public static ParameterList operator +(Variable a, ParameterList b)
        {
            Variable[] parameters = new Variable[b.Parameters.Length + 1];
            parameters[0] = a;
            Array.Copy(b.Parameters, 0, parameters, 1, b.Parameters.Length);
            return new ParameterList(parameters);
        }

        public static ParameterList operator +(ParameterList a, Variable b)
        {
            Variable[] parameters = new Variable[a.Parameters.Length + 1];
            Array.Copy(a.Parameters, parameters, a.Parameters.Length);
            parameters[^1] = b;
            return new ParameterList(parameters);
        }

        /* Public methods. */
        public sealed override string Generate()
        {
            string code = "";
            foreach (Variable parameter in Parameters)
            {
                string parameterCode = parameter.Generate();
                if (parameterCode != "")
                {
                    if (code != "")
                        code += ", ";
                    code += parameterCode;
                }
            }
            return code;
        }
    }
}