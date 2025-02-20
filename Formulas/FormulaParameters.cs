using System.Collections.Generic;

namespace Rusty.Quantities.Generator
{
    public static class FormulaParameters
    {
        /// <summary>
        /// The recognized formula parameters.
        /// </summary>
        public static Dictionary<char, FormulaParameter> Parameters => new Dictionary<char, FormulaParameter>()
        {
            { 't', new('t', "Time") },
            { 's', new('s', "Distance") },
            { 'V', new('V', "Constant speed", "Speed") },
            { 'u', new('u', "Start speed", "Speed") },
            { 'v', new('v', "End speed", "Speed") },
            { 'a', new('a', "Acceleration") }
        };

        /// <summary>
        /// The order that formula parameters will appear in formula functions.
        /// </summary>
        public static string Order => "sVuvat";
    }
}