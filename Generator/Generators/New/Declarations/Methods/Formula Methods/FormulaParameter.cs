namespace Generators.New
{
    public struct FormulaParameter
    {
        /* Public properties. */
        public char ShortName { get; set; }
        public Parameter Parameter { get; set; }

        public string FullName => Parameter.Name;
        public string CamelCase
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
        public string LowercaseSpaced
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
        public FormulaParameter(char shortName, Parameter parameter)
        {
            ShortName = shortName;
            Parameter = parameter;
        }

        public FormulaParameter(char shortName, string parameterType, string parameterName)
            : this(shortName, new ScalarQuantityParameter(parameterType, parameterName)) { }
    }
}