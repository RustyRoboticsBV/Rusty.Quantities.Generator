namespace Generators
{
    /// <summary>
    /// A set of physics formulas.
    /// </summary>
    public class FormulaSet
    {
        /* Public properties. */
        public Formula[] Formulas { get; private set; }

        /* Constructors. */
        /// <summary>
        /// Create a formula set where each equation has three parameters (one of which is the target parameter).
        /// </summary>
        public FormulaSet(string equation1, string equation2, string equation3,
            FormulaParameter parameter1, FormulaParameter parameter2, FormulaParameter parameter3)
        {
            Formulas = new Formula[]
            {
                new(equation1, parameter1, parameter2, parameter3),
                new(equation2, parameter1, parameter2, parameter3),
                new(equation3, parameter1, parameter2, parameter3)
            };
        }

        /// <summary>
        /// Create a formula set where each equation has four parameters (one of which is the target parameter).
        /// </summary>
        public FormulaSet(string equation1, string equation2, string equation3, string equation4,
            FormulaParameter parameter1, FormulaParameter parameter2, FormulaParameter parameter3, FormulaParameter parameter4)
        {
            Formulas = new Formula[]
            {
                new(equation1, parameter1, parameter2, parameter3, parameter4),
                new(equation2, parameter1, parameter2, parameter3, parameter4),
                new(equation3, parameter1, parameter2, parameter3, parameter4),
                new(equation4, parameter1, parameter2, parameter3, parameter4)
            };
        }

        /* Public methods. */
        /// <summary>
        /// Return whether or not this formula set has some parameter.
        /// </summary>
        public bool HasFormula(char shortName)
        {
            return Find(shortName) != null;
        }

        /// <summary>
        /// Return a formula, using its target parameter's short name.
        /// </summary>
        public Formula Find(char shortName)
        {
            foreach (Formula formula in Formulas)
            {
                if (formula.Target.ShortName == shortName)
                    return formula;
            }
            return null;
        }
    }
}
