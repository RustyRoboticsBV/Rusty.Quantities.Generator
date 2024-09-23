

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

            // Generate method.
            return MethodGenerator.GenerateSummary(GenerateDesc(FindParameter(returnParameter), usedParameters))
                + "\n" + ClassGenerator.Indent + $"public static {returnType.Type} {methodName}({GenerateParameterList(usedParameters)}) => {code};";
        }

        public string GenerateMethod(string className, char returnParameter, string methodName, string args)
        {
            return GenerateMethod(className, returnParameter, methodName, args, GenerateDesc(returnParameter, args));
        }

        public string GenerateMethod(string className, char returnParameter, string methodName, string args, string methodDesc)
        {
            // Get return type parameter.
            Parameter returnType = FindParameter(returnParameter);

            // Get equation.
            string code = FindFormula(returnType);

            // Remove assignment.
            code = code.Replace(returnType.ShortName + "=", "");

            // Replace parameters.
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
                        break;
                    }
                    else if (code[i] == '+' || code[i] == '-' || code[i] == '*' || code[i] == '/' || code[i] == '%')
                    {
                        code = code.Substring(0, i) + $" {code[i]} " + code.Substring(i + 1);
                        i += 2;
                    }
                }
            }

            // Generate method.
            return MethodGenerator.GenerateSummary(methodDesc)
                + "\n" + ClassGenerator.Indent + $"public static {returnType.Type} {methodName}({GenerateParameterList(args)}) => {code};";
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
            throw new Exception();
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
            throw new Exception();
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
        /// Generate method header parameter list string.
        /// </summary>
        private static string GenerateParameterList(List<Parameter> parameters)
        {
            return GenerateParameterList(parameters.ToArray());
        }

        /// <summary>
        /// Generate method header parameter list string.
        /// </summary>
        public string GenerateParameterList(string args)
        {
            Parameter[] parameters = new Parameter[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                parameters[i] = FindParameter(args[i]);
            }
            return GenerateParameterList(parameters);
        }

        /// <summary>
        /// Generate a method description from a return parameter and a set of argument parameters.
        /// </summary>
        private string GenerateDesc(Parameter returnType, List<Parameter> args)
        {
            string desc = "Calculate " + returnType.FullName + " from ";
            for (int i = 0; i < args.Count; i++)
            {
                if (i > 0 && i < args.Count - 1)
                    desc += ", ";
                else if (i > 0)
                    desc += " and ";
                desc += args[i].FullNameFormatted;
            }
            desc += ".";
            return desc;
        }

        /// <summary>
        /// Generate a method description from a return parameter and a set of argument parameters.
        /// </summary>
        private string GenerateDesc(char returnParameter, string args)
        {
            List<Parameter> parameters = new();
            foreach (char arg in args)
            {
                parameters.Add(FindParameter(arg));
            }
            return GenerateDesc(FindParameter(returnParameter), parameters);
        }
    }
}
