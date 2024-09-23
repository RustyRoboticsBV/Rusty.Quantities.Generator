

namespace Generator
{
    /// <summary>
    /// A generator for the speed quantity class.
    /// </summary>
    public static class SpeedGenerator
    {
        /* Public methods. */
        public static void Generate()
        {
            string code = ClassGenerator.Generate("Speed", "Represents a speed quantity.");

            string formulas = GenerateFormula("Calculate", "Calculate speed from distance and time.",
                "v=s/t",
                "v", new string[] { "s", "t" },
                "Speed", new string[] { "Distance", "Time" }, new string[] { "distance", "time" });
            code = code.Replace("//FORMULAS", formulas);

            FileWriter.Write("Speed", code);
        }

        private static string GenerateFormula(string methodName, string desc, string formula, string targetParam, string[] parameters, string returnType, string[] parameterTypes, string[] parameterNames)
        {
            // Remove whitespace.
            formula = formula.Replace(" ", "");

            // Remove assignment.
            formula = formula.Replace(targetParam + "=", "");

            // Replace parameters.
            for (int i = 0; i < formula.Length; i++)
            {
                for (int j = 0; j < parameters.Length; j++)
                {
                    if (formula.Substring(i, parameters[j].Length) == parameters[j])
                    {
                        formula = formula.Substring(0, i) + "(double)" + parameterNames[j] + formula.Substring(i + parameters[j].Length);
                        i += parameterNames[j].Length + 8;
                        break;
                    }
                }
            }

            // Generate method.
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + ClassGenerator.Indent + $"public static {returnType} {methodName}({GetParameterList(parameterTypes, parameterNames)}) => {formula};";
        }

        private static string GetParameterList(string[] parameterTypes, string[] parameterNames)
        {
            string code = "";
            for (int i = 0; i < parameterTypes.Length && i < parameterNames.Length; i++)
            {
                if (i > 0)
                    code += ", ";
                code += parameterTypes[i] + " " + parameterNames[i];
            }
            return code;
        }
    }
}
