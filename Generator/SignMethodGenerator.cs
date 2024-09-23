

namespace Quantities
{
    public static class SignMethodGenerator
    {
        public static string GenerateLocal(string className)
        {
            return MethodGenerator.GenerateSummary(GenerateDesc(className, false))
                + "\n" + Generator.Indent + $"public readonly int Sign() => Mathd.Sign(value);";
        }

        public static string GenerateStatic(string className)
        {
            return MethodGenerator.GenerateSummary(GenerateDesc(className, true))
                + "\n" + Generator.Indent + $"public static int Sign({className} value) => Mathd.Sign(value.value);";
        }

        public static string GenerateBoth(string className)
        {
            return GenerateLocal(className)
                + "\n" + GenerateStatic(className);
        }

        private static string GenerateDesc(string className, bool isStatic)
        {
            return $"Return the sign of {(isStatic ? "a" : "this")} {className.ToLower()} value; -1 if negative, 1 if positive and 0 if equal to 0.";
        }
    }
}
