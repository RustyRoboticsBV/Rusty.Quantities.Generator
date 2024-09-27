namespace Generators.New
{
    public class MathdSummary : GeneratorPair<ContextualSummary>
    {
        /* Constructors. */
        public MathdSummary(string text, string quantityName)
            : this(text, new string[] { "PRONOUN", "QUANTITY_NAME" },
                  new string[] { "this", quantityName.ToLower() },
                  new string[] { GetPronoun(quantityName.ToLower()), quantityName.ToLower() })
        { }

        private MathdSummary(string text, string[] keywords, string[] localValues, string[] staticValues)
            : base(new(text, keywords, localValues), new(text, keywords, staticValues)) { }

        /* Private methods. */
        private static string GetPronoun(string quantityName)
        {
            if (quantityName == null || quantityName.Length == 0)
                return "a";
            switch (quantityName[0])
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                case 'y':
                    return "an";
                default:
                    return "a";
            }
        }
    }

    public abstract class MathdMethodPair : GeneratorPair<Method>
    {
        /* Constructors. */
        public MathdMethodPair(string returnType, string methodName, string quantityName, string staticParameterName,
            ParameterList commonParameters, MathdSummary summary) : base(
                GetLocal(returnType, methodName, quantityName, commonParameters, summary.Local),
                GetStatic(returnType, methodName, new(quantityName, staticParameterName), commonParameters, summary.Static),
                false)
        { }

        public MathdMethodPair(string returnType, string methodName, string quantityName, string staticParameterName,
            MathdSummary summary)
        : this(returnType, methodName, quantityName, staticParameterName, new(), summary) { }

        /* Private methods. */
        private static Method GetLocal(string returnType, string methodName, string structName, ParameterList parameters,
            Summary summary)
        {
            string arguments = "value";
            foreach (Parameter parameter in parameters.Parameters)
            {
                arguments += ", ";
                if (parameter.Name == structName)
                    arguments += $"{parameter.Name}.value";
                else
                    arguments += parameter.Name;
            }
            return new Method("public", "readonly", returnType, methodName, parameters,
                $"return Mathd.{methodName}({arguments});", summary);
        }

        private static Method GetStatic(string returnType, string methodName, Parameter structParameter,
            ParameterList parameters, Summary summary)
        {
            string arguments = $"{structParameter.Name}.value";
            foreach (Parameter parameter in parameters.Parameters)
            {
                arguments += ", ";
                if (parameter.Name == structParameter.Type)
                    arguments += $"{parameter.Name}.value";
                else
                    arguments += parameter.Name;
            }
            return new Method("public", "static", returnType, methodName, structParameter + parameters,
                $"return Mathd.{methodName}({arguments});", summary);
        }
    }
}