

namespace Generator
{
    public struct Parameter
    {
        public char ShortName { get; private set; }
        public string Type { get; private set; }
        public string FullName { get; private set; }

        public string FullNameFormatted
        {
            get
            {
                string name = FullName;
                for (int i = name.Length - 2; i >= 0; i--)
                {
                    if (name[i] >= 'a' && name[i] <= 'z' && name[i + 1] >= 'A' && name[i + 1] <= 'Z')
                        name = name.Substring(0, i + 1) + " " + name[i + 1].ToString().ToLower() + name.Substring(i + 2);
                }
                return name;
            }
        }

        public Parameter(char shortName, string type, string fullName) : this()
        {
            ShortName = shortName;
            Type = type;
            FullName = fullName;
        }
    }

    /// <summary>
    /// A physics formula.
    /// </summary>
    public class FormulaSet
    {
        /* Public properties. */
        public string[] Formulas { get; private set; }
        public Parameter[] Parameters { get; private set; }

        /* Constructors. */
        public FormulaSet(string formula, Parameter[] parameters)
        {
            Formulas = new string[] { formula };
            Parameters = parameters;
            Init();
        }

        public FormulaSet(string formula, Parameter[] parameters, string[] alternateWritings)
        {
            Formulas = new string[alternateWritings.Length + 1];
            Formulas[0] = formula;
            Array.Copy(alternateWritings, 0, Formulas, 1, alternateWritings.Length);
            Parameters = parameters;
            Init();
        }

        /* Public methods. */
        public string GenerateMethod(string className, char returnParameter, string methodName)
        {
            return GenerateMethod(className, returnParameter, methodName, "");
        }

        public string GenerateMethod(string className, char returnParameter, string methodName, string argOrder)
        {
            return GenerateMethod(className, returnParameter, methodName, argOrder, null);
        }

        public string GenerateMethod(string className, char returnParameter, string methodName, string argOrder, string methodDesc)
        {
            // Get return type parameter.
            Parameter returnType = FindParameter(returnParameter);

            // Get equation.
            string code = FindFormula(returnType);

            // Remove assignment.
            code = code.Replace(returnType.ShortName + "=", "");

            // Replace parameters.
            List<Parameter> usedParameters = new();
            for (int i = 0; i < code.Length; i++)
            {
                for (int j = 0; j < Parameters.Length; j++)
                {
                    Parameter parameter = Parameters[j];
                    if (code[i] == parameter.ShortName)
                    {
                        string expanded;
                        if (parameter.Type == className)
                            expanded = parameter.FullName + ".value";
                        else
                            expanded = "(double)" + parameter.FullName;

                        code = code.Substring(0, i) + expanded + code.Substring(i + 1);
                        i += expanded.Length - 1;

                        if (!usedParameters.Contains(parameter))
                            usedParameters.Add(parameter);

                        break;
                    }
                    else if (code[i] == '+' || code[i] == '-' || code[i] == '*' || code[i] == '/' || code[i] == '%')
                    {
                        code = code.Substring(0, i) + $" {code[i]} " + code.Substring(i + 1);
                        i += 2;
                    }
                }
            }

            // Expand square root and power-of-two operators.
            code = code.Replace("SQRT", "Mathd.Sqrt");
            code = code.Replace("POW2", "Mathd.Pow2");

            // Get ordered parameters.
            Parameter[] orderedParams = OrderParameters(usedParameters, argOrder);

            // Get description.
            if (methodDesc == null)
                methodDesc = GenerateDesc(returnType, orderedParams);

            // Generate method.
            return MethodGenerator.GenerateSummary(methodDesc)
                + "\n" + ClassGenerator.Indent + $"public static {returnType.Type} {methodName}({GenerateParameterList(orderedParams)}) => {code};";
        }

        /* Private methods. */
        private void Init()
        {
            for (int i = 0; i < Formulas.Length; i++)
            {
                Formulas[i] = Formulas[i].Replace(" ", "");
            }
        }

        private string FindFormula(char returnParameterShortName)
        {
            foreach (string formula in Formulas)
            {
                if (formula.StartsWith(returnParameterShortName + "="))
                    return formula;
            }
            throw new Exception(returnParameterShortName.ToString());
        }

        private string FindFormula(Parameter returnType)
        {
            return FindFormula(returnType.ShortName);
        }

        private Parameter FindParameter(char shortName)
        {
            foreach (Parameter parameter in Parameters)
            {
                if (parameter.ShortName == shortName)
                    return parameter;
            }
            throw new Exception(shortName.ToString());
        }

        /// <summary>
        /// Generate method header parameter list string.
        /// </summary>
        private static string GenerateParameterList(Parameter[] parameters)
        {
            string code = "";
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i > 0)
                    code += ", ";
                code += parameters[i].Type + " " + parameters[i].FullName;
            }
            return code;
        }

        /// <summary>
        /// Order a set of parameters.
        /// </summary>
        private static Parameter[] OrderParameters(List<Parameter> parameters, string argOrder)
        {
            // Order parameters.
            List<Parameter> ordered = new();
            foreach (char arg in argOrder)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    if (parameters[i].ShortName == arg)
                    {
                        ordered.Add(parameters[i]);
                        parameters.RemoveAt(i);
                        break;
                    }
                }
            }

            // Add parameters that weren't in the order.
            while (parameters.Count > 0)
            {
                ordered.Add(parameters[0]);
                parameters.RemoveAt(0);
            }

            return ordered.ToArray();
        }

        /// <summary>
        /// Generate a method description from a return parameter and a set of argument parameters.
        /// </summary>
        private string GenerateDesc(Parameter returnType, Parameter[] args)
        {
            string desc = "Calculate " + returnType.FullName + " from ";
            for (int i = 0; i < args.Length; i++)
            {
                if (i > 0 && i < args.Length - 1)
                    desc += ", ";
                else if (i > 0)
                    desc += " and ";
                desc += args[i].FullNameFormatted;
            }
            desc += ".";
            return desc;
        }
    }
}
