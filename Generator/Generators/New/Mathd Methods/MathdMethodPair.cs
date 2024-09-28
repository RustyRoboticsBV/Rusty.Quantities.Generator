namespace Generators.New
{
    public abstract class MathdMethodPair : GeneratorPair<Method>
    {
        /* Constructors. */
        public MathdMethodPair(ReturnType returnType, string methodName, ScalarParameterList localParameters,
            ScalarParameterList staticParameters, MathdSummary summary) : base(
                CreateMethod(false, returnType, methodName, localParameters, summary.Local),
                CreateMethod(true, returnType, methodName, staticParameters, summary.Static),
                false)
        { }

        /* Private methods. */
        private static Method CreateMethod(bool isStatic, ReturnType returnType, string methodName, ScalarParameterList parameters,
            Summary summary)
        {
            string arguments = "";
            if (!isStatic)
                arguments += "value";
            foreach (ScalarParameter parameter in parameters.Parameters)
            {
                if (arguments != "")
                    arguments += ", ";
                arguments += parameter.ToNumeric();
            }

            return new Method("public", isStatic ? "static" : "readonly", returnType.Name, methodName, parameters,
                returnType.Generate($"Mathd.{methodName}({arguments})"), summary);
        }
    }
}