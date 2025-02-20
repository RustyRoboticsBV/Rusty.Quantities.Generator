using System.Collections.Generic;

namespace Rusty.Quantities.Generator
{
    public class Equation
    {
        public string Body { get; set; } = "";
        public FormulaParameter Result { get; set; }
        public FormulaParameter[] Arguments { get; set; } = { };

        public Equation(string equation)
        {
            string[] substrs = equation.Split('=');
            Result = FormulaParameters.Parameters[substrs[0][0]];

            Body = substrs[1];
            List<FormulaParameter> arguments = new();
            string found = "";
            for (int i = 0; i < Body.Length; i++)
            {
                char symbol = Body[i];
                if (FormulaParameters.Parameters.ContainsKey(symbol))
                {
                    if (!found.Contains(symbol))
                    {
                        arguments.Add(FormulaParameters.Parameters[Body[i]]);
                        found = found + symbol;
                    }
                }
            }
            Arguments = arguments.ToArray();
        }
    }
}