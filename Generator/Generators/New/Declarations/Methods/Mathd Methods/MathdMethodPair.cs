namespace Generators
{
    /// <summary>
    /// A mathd method pair.
    /// </summary>
    public abstract class MathdMethodPair : GeneratorPair<MathdMethod>
    {
        /* Constructors. */
        public MathdMethodPair(Type returnType, string methodName, ScalarParameterList localParameters,
            ScalarParameterList staticParameters, MathdSummary summary) : base(
                CreateMethod(false, returnType, methodName, localParameters, summary.Local),
                CreateMethod(true, returnType, methodName, staticParameters, summary.Static),
                false)
        {
            Local.Parent = this;
            Static.Parent = this;
        }

        /* Private methods. */
        private static MathdMethod CreateMethod(bool isStatic, Type returnType, string methodName,
            ScalarParameterList parameters, Summary summary)
        {
            return new MathdMethod(isStatic, returnType, methodName, parameters, summary);
        }
    }
}