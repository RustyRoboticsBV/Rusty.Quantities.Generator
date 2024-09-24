

namespace Generators
{
    public struct Parameter
    {
        public char ShortName { get; private set; }
        public string Type { get; private set; }
        public string FullName { get; private set; }

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

        public Parameter(char shortName, string type, string fullName) : this()
        {
            ShortName = shortName;
            Type = type;
            FullName = fullName;
        }
    }

    /// <summary>
    /// A physics formula.
    /// </summary>
    public class FormulaSet
    {
        /* Public properties. */
        public string[] Formulas { get; private set; }
        public bool IncludeParamsInName { get; private set; }
        public Parameter[] Parameters { get; private set; }

        /* Constructors. */
        public FormulaSet(string equation, bool includeParamsInName, params Parameter[] parameters)
        {
            Formulas = new string[] { equation };
            IncludeParamsInName = includeParamsInName;
            Parameters = parameters;
            Init();
        }

        public FormulaSet(string equation1, string equation2, bool includeParamsInName, params Parameter[] parameters)
        {
            Formulas = new string[] { equation1, equation2 };
            IncludeParamsInName = includeParamsInName;
            Parameters = parameters;
            Init();
        }

        public FormulaSet(string equation1, string equation2, string equation3, bool includeParamsInName, params Parameter[] parameters)
        {
            Formulas = new string[] { equation1, equation2, equation3 };
            IncludeParamsInName = includeParamsInName;
            Parameters = parameters;
            Init();
        }

        public FormulaSet(string equation1, string equation2, string equation3, string equation4, bool includeParamsInName, params Parameter[] parameters)
        {
            Formulas = new string[] { equation1, equation2, equation3, equation4 };
            IncludeParamsInName = includeParamsInName;
            Parameters = parameters;
            Init();
        }

        /* Public methods. */
        public bool ContainsParam(char shortName)
        {
            foreach (Parameter parameter in Parameters)
            {
                if (parameter.ShortName == shortName)
                    return true;
            }
            return false;
        }

        public bool ContainsFormula(char returnParameterShortName)
        {
            foreach (string formula in Formulas)
            {
                if (formula.StartsWith(returnParameterShortName + "="))
                    return true;
            }
            return false;
        }

        public Parameter FindParameter(char shortName)
        {
            foreach (Parameter parameter in Parameters)
            {
                if (parameter.ShortName == shortName)
                    return parameter;
            }
            throw new Exception($"Invalid parameter '{shortName}'");
        }

        public string FindFormula(char returnParameterShortName)
        {
            foreach (string formula in Formulas)
            {
                if (formula.StartsWith(returnParameterShortName + "="))
                    return formula;
            }
            throw new Exception(returnParameterShortName.ToString());
        }

        public string FindFormula(Parameter returnType)
        {
            return FindFormula(returnType.ShortName);
        }

        /* Private methods. */
        private void Init()
        {
            for (int i = 0; i < Formulas.Length; i++)
            {
                Formulas[i] = Formulas[i].Replace(" ", "");
            }
        }
    }
}
