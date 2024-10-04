namespace Generators
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
        private static MathdMethod CreateMethod(bool isStatic, ReturnType returnType, string methodName,
            ScalarParameterList parameters, Summary summary)
        {
            return new MathdMethod(isStatic, returnType, methodName, parameters, summary);
        }
    }
}