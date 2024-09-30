namespace Generators.New
{
    public class FormulaMethod : Method
    {
        /* Constructors. */
        public FormulaMethod(FormulaSet formulas, char target)
            : base("public", "static",
                  null,
                  null,
                  null, "KAAS", null)
        {
            Formula formula = formulas.Find(target);
            ReturnType = formula.Target.Parameter.Type.Name;
            Name = formula.MethodName;
            Parameters = formula.ParameterList;
            Implementation = formula.Implementation;

            // Figure out summary.
            string summary = "";
            for (int i = 0; i < formula.Parameters.Length; i++)
            {
                FormulaParameter parameter = formula.Parameters[i];
                if (summary != "")
                {
                    if (i == formula.Parameters.Length - 1)
                        summary += " and ";
                    else
                        summary += ", ";
                }
                summary += parameter.LowercaseSpaced;
            }
            Summary = new Summary($"Calculate {formula.Target.LowercaseSpaced} from {summary}.");
        }

        /* Public methods. */
        public static string Generate(FormulaSet formulas, char target)
        {
            return new FormulaMethod(formulas, target).Generate();
        }
    }
}