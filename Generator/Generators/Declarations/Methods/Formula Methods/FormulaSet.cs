using System;

namespace Generators
{
    /// <summary>
    /// A set of physics formulas that use the same parameters. Each individual formula should use a different target parameter,
    /// and all should be derivable from each other.
    /// </summary>
    public readonly struct FormulaSet
    {
        /* Public properties. */
        public readonly Formula[] Formulas { get; private init; }

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
        public readonly bool HasFormula(char shortName)
        {
            foreach (Formula formula in Formulas)
            {
                if (formula.Target.ShortName == shortName)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Return a formula, using its target parameter's short name.
        /// </summary>
        public readonly Formula Find(char shortName)
        {
            foreach (Formula formula in Formulas)
            {
                if (formula.Target.ShortName == shortName)
                    return formula;
            }
            throw new ArgumentOutOfRangeException(shortName.ToString(), "No formula with target parameter exists.");
        }
    }
}