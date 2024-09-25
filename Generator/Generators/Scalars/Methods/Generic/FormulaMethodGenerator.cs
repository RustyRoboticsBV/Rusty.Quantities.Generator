

namespace Generators.Scalars
{
    public class FormulaMethodGenerator : Generator
    {
        public static string Generate(FormulaSet formulas, string className, char returnParameter, string methodName)
        {
            return GenerateMethod(formulas, className, returnParameter, methodName, null);
        }

        public static string GenerateMethod(FormulaSet formulas, string className, char returnParameter, string methodName, string methodDesc)
        {
            // Get return type parameter.
            Parameter returnType = formulas.FindParameter(returnParameter);

            // Get equation.
            string code = formulas.FindFormula(returnType);

            // Remove assignment.
            code = code.Replace(returnType.ShortName + "=", "");

            // Replace parameters.
            List<Parameter> usedParameters = new();
            for (int i = 0; i < code.Length; i++)
            {
                for (int j = 0; j < formulas.Parameters.Length; j++)
                {
                    Parameter parameter = formulas.Parameters[j];
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

            // Wrap code.
            code = "return " + code + ";";

            // Get ordered parameters.
            Parameter[] orderedParams = OrderParameters(formulas, usedParameters);

            // Get description.
            if (methodDesc == null)
                methodDesc = GenerateDesc(returnType, orderedParams);

            // Generate method.
            string _methodName = GenerateMethodName(methodName, orderedParams, formulas.IncludeParamsInName);
            return MethodGenerator.Generate("public static", returnType.Type, _methodName, GenerateParameterList(orderedParams), code, methodDesc);
        }

        /* Private methods. */
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
        private static Parameter[] OrderParameters(FormulaSet formulas, List<Parameter> parameters)
        {
            // Order parameters.
            List<Parameter> ordered = new();
            foreach (Parameter parameter in formulas.Parameters)
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
        /// Generate a method name from a prefix and a set of argument parameters.
        /// </summary>
        private static string GenerateMethodName(string methodName, Parameter[] args, bool includeParamsInName)
        {
            if (!includeParamsInName)
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
        private static string GenerateDesc(Parameter returnType, Parameter[] args)
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