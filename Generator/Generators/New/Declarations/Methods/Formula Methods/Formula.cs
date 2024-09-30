namespace Generators
{
    public class Formula
    {
        /* Public properties. */
        public string Equation { get; set; }
        public FormulaParameter Target { get; set; }
        public FormulaParameter[] Parameters { get; set; }

        public string MethodName
        {
            get
            {
                string name = "Calc";
                name += Target.CamelCase;
                name += "From";
                foreach (FormulaParameter parameter in Parameters)
                {
                    name += parameter.ShortName.ToString().ToUpper();
                }
                return name;
            }
        }
        public ParameterList ParameterList
        {
            get
            {
                List<Parameter> parameters = new();
                foreach (FormulaParameter parameter in Parameters)
                {
                    parameters.Add(parameter.Parameter);
                }
                return new(parameters.ToArray());
            }
        }
        public string Implementation
        {
            get
            {
                // Remove assignment.
                string code = Equation.Replace(Target.ShortName + "=", "");

                // Replace parameters.
                List<FormulaParameter> usedParameters = new();
                for (int i = 0; i < code.Length; i++)
                {
                    for (int j = 0; j < Parameters.Length; j++)
                    {
                        FormulaParameter parameter = Parameters[j];
                        if (code[i] == parameter.ShortName)
                        {
                            string expanded = parameter.Parameter.Type.Rescope(Target.Parameter.Type.StructScope).CastTo(parameter.Parameter.Name, Numerics.CoreType);
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
                code = code.Replace("1 / 2", "0.5");
                code = code.Replace("/ 2", "* 0.5");
                return ReturnScalarQuantity.Generate(Numerics.CoreType, code, Target.Parameter.Type as ScalarQuantityType);
            }
        }

        /* Constructors. */
        public Formula(string equation, params FormulaParameter[] parameters)
        {
            // Store equation.
            Equation = equation.Replace(" ", "");

            // Store target parameter.
            foreach (FormulaParameter parameter in parameters)
            {
                if (parameter.ShortName == equation[0])
                    Target = parameter;
            }

            // Store non-target parameters.
            List<FormulaParameter> parameterList = new(parameters);
            parameterList.Remove(Target);
            Parameters = parameterList.ToArray();
        }
    }
}