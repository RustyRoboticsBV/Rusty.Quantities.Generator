

namespace Generator
{
    public struct Parameter
    {
        public char ShortName { get; private set; }
        public string Type { get; private set; }
        public string FullName { get; private set; }

        public string CamelCase
        {
            get
            {
                string name = FullName;
                if (name[0] >= 'a' && name[0] <= 'z')
                    return name[0].ToString().ToUpper() + name.Substring(1);
                else
                    return name;
            }
        }
        public string LowercaseSpaced
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
        public bool IncludeParamsInName { get; private set; }
        public Parameter[] Parameters { get; private set; }

        /* Constructors. */
        public FormulaSet(string equation, bool includeParamsInName, params Parameter[] parameters)
        {
            Formulas = new string[] { equation };
            IncludeParamsInName = includeParamsInName;
            Parameters = parameters;
            Init();
        }

        public FormulaSet(string equation1, string equation2, bool includeParamsInName, params Parameter[] parameters)
        {
            Formulas = new string[] { equation1, equation2 };
            IncludeParamsInName = includeParamsInName;
            Parameters = parameters;
            Init();
        }

        public FormulaSet(string equation1, string equation2, string equation3, bool includeParamsInName, params Parameter[] parameters)
        {
            Formulas = new string[] { equation1, equation2, equation3 };
            IncludeParamsInName = includeParamsInName;
            Parameters = parameters;
            Init();
        }

        public FormulaSet(string equation1, string equation2, string equation3, string equation4, bool includeParamsInName, params Parameter[] parameters)
        {
            Formulas = new string[] { equation1, equation2, equation3, equation4 };
            IncludeParamsInName = includeParamsInName;
            Parameters = parameters;
            Init();
        }

        /* Public methods. */
        public bool ContainsParam(char shortName)
        {
            foreach (Parameter parameter in Parameters)
            {
                if (parameter.ShortName == shortName)
                    return true;
            }
            return false;
        }

        public bool ContainsFormula(char returnParameterShortName)
        {
            foreach (string formula in Formulas)
            {
                if (formula.StartsWith(returnParameterShortName + "="))
                    return true;
            }
            return false;
        }

        public Parameter FindParameter(char shortName)
        {
            foreach (Parameter parameter in Parameters)
            {
                if (parameter.ShortName == shortName)
                    return parameter;
            }
            throw new Exception($"Invalid parameter '{shortName}'");
        }

        public string GenerateMethod(string className, char returnParameter, string methodName)
        {
            return GenerateMethod(className, returnParameter, methodName, null);
        }

        public string GenerateMethod(string className, char returnParameter, string methodName, string methodDesc)
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
            code = code.Replace("UMIN", "-");

            // Get ordered parameters.
            Parameter[] orderedParams = OrderParameters(usedParameters);

            // Get description.
            if (methodDesc == null)
                methodDesc = GenerateDesc(returnType, orderedParams);

            // Generate method.
            return MethodGenerator.GenerateSummary(methodDesc)
                + "\n" + ClassGenerator.Indent + $"public static {returnType.Type} {GenerateMethodName(methodName, orderedParams)}({GenerateParameterList(orderedParams)}) => {code};";
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
        private Parameter[] OrderParameters(List<Parameter> parameters)
        {
            // Order parameters.
            List<Parameter> ordered = new();
            foreach (Parameter parameter in Parameters)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    if (parameters[i].ShortName == parameter.ShortName)
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
        /// Generate a method name from a prefox and a set of argument parameters.
        /// </summary>
        private string GenerateMethodName(string methodName, Parameter[] args)
        {
            if (!IncludeParamsInName)
                return methodName;

            string name = methodName;
            foreach (Parameter parameter in args)
            {
                name += parameter.ShortName.ToString().ToUpper();
            }
            return name;
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
                desc += args[i].LowercaseSpaced;
            }
            desc += ".";
            return desc;
        }
    }
}
