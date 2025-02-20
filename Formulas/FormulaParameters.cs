using System.Collections.Generic;

namespace Rusty.Quantities.Generator
{
    public static class FormulaParameters
    {
        public static Dictionary<char, FormulaParameter> Parameters => new Dictionary<char, FormulaParameter>()
        {
            { 't', new('t', "Time") },
            { 's', new('s', "Distance") },
            { 'V', new('V', "Speed") },
            { 'u', new('u', "Start speed", "Speed") },
            { 'v', new('v', "End speed", "Speed") },
            { 'a', new('a', "Acceleration") }
        };

        public static Dictionary<char, int> Indices => new Dictionary<char, int>()
        {
            { 't', 0 },
            { 's', 1 },
            { 'V', 2 },
            { 'u', 3 },
            { 'v', 4 },
            { 'a', 5 }
        };
    }
}