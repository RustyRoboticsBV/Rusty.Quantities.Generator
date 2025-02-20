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

            // Store result parameter.
            Result = FormulaParameters.Parameters[substrs[0][0]];

            // Store body.
            Body = substrs[1];

            // Collect parameter symbols.
            string symbols = new string(' ', FormulaParameters.Order.Length);
            for (int i = 0; i < Body.Length; i++)
            {
                char symbol = Body[i];
                if (FormulaParameters.Parameters.ContainsKey(symbol))
                {
                    if (!symbols.Contains(symbol))
                    {
                        int index = FormulaParameters.Order.IndexOf(symbol);
                        symbols = symbols.Substring(0, index) + symbol + symbols.Substring(index + 1);
                    }
                }
            }
            symbols = symbols.Replace(" ", "");

            // Convert found symbols to argument list.
            Arguments = new FormulaParameter[symbols.Length];
            for (int i = 0; i < symbols.Length; i++)
            {
                Arguments[i] = FormulaParameters.Parameters[symbols[i]];
            }
        }
    }
}