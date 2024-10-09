using System.Reflection;

namespace Generators
{
    /// <summary>
    /// A math method that uses the mathd library.
    /// </summary>
    public class MathdMethod : Method
    {
        /* Public properties. */
        public bool IsStatic { get; private set; }

        /* Constructors. */
        public MathdMethod(bool isStatic, Type returnType, string methodName, ScalarParameterList parameters,
            Summary summary) : base("public", isStatic ? "static" : "readonly", returnType, methodName,
                parameters, "", summary)
        {
            IsStatic = isStatic;
        }

        /* Protected methods. */
        protected override string IdContents()
        {
            Implementation = GetImplementation(IsStatic, ReturnType, Name, Parameters);
            return base.IdContents();
        }

        /* Private methods. */
        private string GetImplementation(bool isStatic, Type returnType, string methodName, ParameterList parameters)
        {
            string arguments = isStatic ? "" : "value";
            foreach (Variable parameter in parameters.Parameters)
            {
                if (arguments != "")
                    arguments += ", ";
                arguments += parameter.CastTo(Numerics.Core);
            }

            if (returnType is ScalarNumericType)
                return $"return {$"Mathd.{methodName}({arguments})"};";
            else
                return $"return {Numerics.Core.CastTo($"Mathd.{methodName}({arguments})", returnType, GetScope())};";
        }
    }
}