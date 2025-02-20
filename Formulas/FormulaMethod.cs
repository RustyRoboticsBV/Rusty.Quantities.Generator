using Rusty.CSharpGenerator;
using System.Collections.Generic;

namespace Rusty.Quantities.Generator
{
    public class FormulaMethod : Method
    {
        public FormulaMethod(Equation equation, string scope) : base()
        {
            string symbolArguments = "";
            string summaryArguments = "";
            List<Parameter> parameters = new List<Parameter>();
            for (int i = 0; i < equation.Arguments.Length; i++)
            {
                FormulaParameter parameter = equation.Arguments[i];

                symbolArguments += parameter.Symbol.ToString().ToUpper();

                if (i == equation.Arguments.Length - 1)
                    summaryArguments += " and ";
                else if (i > 0)
                    summaryArguments += ", ";
                summaryArguments += parameter.Lowercase;

                parameters.Add(new Parameter(parameter.Type, parameter.CamelCase));
            }

            string implementation = "";
            for (int i = 0; i < equation.Body.Length; i++)
            {
                if (FormulaParameters.Parameters.ContainsKey(equation.Body[i]))
                {
                    FormulaParameter parameter = FormulaParameters.Parameters[equation.Body[i]];
                    implementation += Types.Convert(parameter.CamelCase, parameter.Type, "double", scope);
                }

                else if (equation.Body.Substring(i).StartsWith("1/2"))
                    implementation += "0.5";
                else if (equation.Body.Substring(i).StartsWith('+'))
                    implementation += " + ";
                else if (equation.Body.Substring(i).StartsWith('-'))
                    implementation += " - ";
                else if (equation.Body.Substring(i).StartsWith('*'))
                    implementation += " * ";
                else if (equation.Body.Substring(i).StartsWith('/'))
                    implementation += " / ";
                else if (equation.Body.Substring(i).StartsWith("SQRT"))
                {
                    implementation += "Sqrt";
                    i += 3;
                }
                else if (equation.Body.Substring(i).StartsWith("POW2"))
                {
                    implementation += "Pow2";
                    i += 3;
                }
                else if (equation.Body.Substring(i).StartsWith("UMIN"))
                {
                    implementation += '-';
                    i += 3;
                }
                else
                    implementation += equation.Body[i];
            }

            string name = equation.Result.PascalCase.Replace("Constant", "Const");
            if (name == scope)
                name = "";

            Summary = $"Calculate {equation.Result.Lowercase} from {summaryArguments}.";
            Modifiers = MethodModifierID.Static;
            ReturnType = equation.Result.Type;
            Name = $"{name}From{symbolArguments}";
            Parameters = parameters.ToArray();
            Implementation = $"return {implementation};";
        }
    }
}
