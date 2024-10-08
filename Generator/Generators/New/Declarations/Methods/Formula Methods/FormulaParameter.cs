namespace Generators
{
    /// <summary>
    /// A parameter of a physics formula.
    /// </summary>
    public readonly struct FormulaParameter
    {
        /* Public properties. */
        /// <summary>
        /// The single-character name as used in formula equations.
        /// </summary>
        public readonly char ShortName { get; private init; }
        /// <summary>
        /// The full name of this formula parameter, in pascalCase format.
        /// </summary>
        public readonly string FullName { get; private init; }
        /// <summary>
        /// The quantity type of this formula parameter.
        /// </summary>
        public readonly ScalarQuantityType Type { get; private init; }

        /// <summary>
        /// The full name in CamelCase format.
        /// </summary>
        public readonly string CamelCase
        {
            get
            {
                string name = FullName;
                if (name[0] >= 'a' && name[0] <= 'z')
                    return name[0].ToString().ToUpper() + name.Substring(1);
                else
                    return name;
            }
        }
        /// <summary>
        /// The full name in lowercase spaced format.
        /// </summary>
        public readonly string LowercaseSpaced
        {
            get
            {
                string name = FullName;
                for (int i = name.Length - 2; i >= 0; i--)
                {
                    if (name[i] >= 'a' && name[i] <= 'z' && name[i + 1] >= 'A' && name[i + 1] <= 'Z')
                        name = name.Substring(0, i + 1) + " " + name[i + 1].ToString().ToLower() + name.Substring(i + 2);
                }
                return name;
            }
        }

        /* Constructors. */
        public FormulaParameter(char shortName, string fullName, ScalarQuantityType type)
        {
            ShortName = shortName;
            FullName = fullName;
            Type = type;
        }
    }
}