namespace Generators
{
    public class MathdMethod : Method
    {
        public MathdMethod(bool isStatic, ReturnType returnType, string methodName, ScalarParameterList parameters,
            Summary summary) : base("public", isStatic ? "static" : "readonly", returnType.Type.Name, methodName,
                parameters, GetImplementation(isStatic, returnType.Type, methodName, parameters), summary) { }

        /* Private methods. */
        private static string GetImplementation(bool isStatic, Type returnType, string methodName, ScalarParameterList parameters)
        {
            string arguments = isStatic ? "" : "value";
            foreach (ScalarParameter parameter in parameters.Parameters)
            {
                if (arguments != "")
                    arguments += ", ";
                arguments += parameter.CastToCore();
            }

            return $"return {Numerics.CoreType.CastTo($"Mathd.{methodName}({arguments})", returnType)};";
        }
    }
}