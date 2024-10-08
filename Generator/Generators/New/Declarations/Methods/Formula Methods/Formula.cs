namespace Generators
{
    /// <summary>
    /// Represents a single physics formula within a formula set.
    /// </summary>
    public readonly struct Formula
    {
        /* Public properties. */
        public readonly string Equation { get; private init; }
        public readonly FormulaParameter Target { get; private init; }
        public readonly FormulaParameter[] Parameters { get; private init; }

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