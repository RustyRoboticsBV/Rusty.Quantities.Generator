using System.Collections.Generic;

namespace Generators
{
    public class FormulaMethod : Method
    {
        /* Constructors. */
        public FormulaMethod(FormulaSet formulas, char target)
            : base("public", "static", null, null, null, null, null)
        {
            Formula formula = formulas.Find(target);
            ReturnType = formula.Target.Type;
            Name = GetMethodName(formula);
            Parameters = GetParameters(formula);
            Implementation = GetImplementation(formula);
            Summary = GetSummary(formula);

            Summary.Parent = this;
        }

        /* Private methods. */
        public string GetMethodName(Formula formula)
        {
            string name = "Calc";
            name += formula.Target.CamelCase;
            name += "From";
            foreach (FormulaParameter parameter in formula.Parameters)
            {
                name += parameter.ShortName.ToString().ToUpper();
            }
            return name;
        }

        public ParameterList GetParameters(Formula formula)
        {
            List<ScalarQuantityParameter> parameters = new();
            foreach (FormulaParameter parameter in formula.Parameters)
            {
                parameters.Add(new(parameter.Type, parameter.FullName));
            }
            return new(parameters.ToArray());
        }

        private string GetImplementation(Formula formula)
        {
            // Remove assignment.
            string code = formula.Equation.Replace(formula.Target.ShortName + "=", "");

            // Replace parameters.
            List<FormulaParameter> usedParameters = new();
            for (int i = 0; i < code.Length; i++)
            {
                for (int j = 0; j < formula.Parameters.Length; j++)
                {
                    FormulaParameter parameter = formula.Parameters[j];
                    if (code[i] == parameter.ShortName)
                    {
                        string expanded = Parameters[j].CastTo(Numerics.Core);
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
            return Numerics.Core.Return(code, formula.Target.Type, GetScope());
        }

        private Summary GetSummary(Formula formula)
        {
            // Summarize arguments.
            string args = "";
            for (int i = 0; i < formula.Parameters.Length; i++)
            {
                FormulaParameter parameter = formula.Parameters[i];
                if (args != "")
                {
                    if (i == formula.Parameters.Length - 1)
                        args += " and ";
                    else
                        args += ", ";
                }
                args += parameter.LowercaseSpaced;
            }

            // Return summary.
            return new($"Calculate {formula.Target.LowercaseSpaced} from {args}.");
        }
    }
}