

namespace Quantities
{
    public static class MethodGenerator
    {
        public static string GenerateSummary(string desc)
        {
            return Generator.Indent + $"/// <summary>"
                + "\n" + Generator.Indent + $"/// {desc}"
                + "\n" + Generator.Indent + "/// </summary>";
        }

        public static string GenerateAll(string className)
        {
            return SignMethodGenerator.GenerateBoth(className)
                + "\n" + Method1Generator.GenerateBoth(className, "Abs", GetAbsDesc(false, className), GetAbsDesc(true, className))
                + "\n" + Method1Generator.GenerateBoth(className, "Truncate", GetTruncateDesc(false, className), GetTruncateDesc(true, className))
                + "\n" + Method1Generator.GenerateBoth(className, "Frac", GetFracDesc(false, className), GetFracDesc(true, className))
                + "\n"
                + "\n" + Method2Generator.GenerateBoth(className, "Dist", GetDistDesc(false, className), GetDistDesc(true, className))
                + "\n" + Method1Generator.GenerateBoth(className, "Sqrt", GetSqrtDesc(false, className), GetSqrtDesc(true, className))
                + "\n" + Method1Generator.GenerateBoth(className, "Pow2", GetPow2Desc(false, className), GetPow2Desc(true, className))
                + "\n" + PowMethodGenerator.GenerateBoth(className)
                + "\n"
                + "\n" + Method2Generator.GenerateBoth(className, "Min", GetMinDesc(false, className), GetMinDesc(true, className))
                + "\n" + Method2Generator.GenerateBoth(className, "Max", GetMaxDesc(false, className), GetMaxDesc(true, className))
                + "\n" + Method3Generator.GenerateBoth(className, "Clamp", GetClampDesc(false, className), GetClampDesc(true, className))
                + "\n"
                + "\n" + Method1Generator.GenerateBoth(className, "Round", GetRoundDesc(false, className), GetRoundDesc(true, className))
                + "\n" + Method1Generator.GenerateBoth(className, "Floor", GetFloorDesc(false, className), GetFloorDesc(false, className))
                + "\n" + Method1Generator.GenerateBoth(className, "Ceil", GetCeilDesc(false, className), GetCeilDesc(false, className))
                + "\n"
                + "\n" + Method1Generator.GenerateBoth(className, "Sin", GetSinDesc(false, className), GetSinDesc(true, className))
                + "\n" + Method1Generator.GenerateBoth(className, "Cos", GetCosDesc(false, className), GetCosDesc(true, className))
                + "\n" + Method1Generator.GenerateBoth(className, "Tan", GetTanDesc(false, className), GetTanDesc(true, className))
                + "\n"
                + "\n" + LerpMethodGenerator.Generate(className, $"Linearly interpolate between two {className.ToLower()} values, using the specified interpolation factor.");
        }

        // Descriptions
        private static string GetAbsDesc(bool isStatic, string className)
        {
            return $"Return the absolute value of {(isStatic ? "a" : "this")} {className.ToLower()} value.";
        }
        private static string GetTruncateDesc(bool isStatic, string className)
        {
            return $"Return the integral part of {(isStatic ? "a" : "this")} {className.ToLower()} value.";
        }
        private static string GetFracDesc(bool isStatic, string className)
        {
            return $"Return the fractional part of {(isStatic ? "a" : "this")} {className.ToLower()} value.";
        }

        private static string GetDistDesc(bool isStatic, string className)
        {
            if (isStatic)
                return $"Return the absolute distance between two {className.ToLower()} values.";
            else
                return $"Return the absolute distance between this and another {className.ToLower()} value.";
        }
        private static string GetSqrtDesc(bool isStatic, string className)
        {
            return $"Return the square root of {(isStatic ? "a" : "this")} {className.ToLower()} value.";
        }
        private static string GetPow2Desc(bool isStatic, string className)
        {
            return $"Return the result of raising {(isStatic ? "a" : "this")} {className.ToLower()} value to the power of two.";
        }

        private static string GetMinDesc(bool isStatic, string className)
        {
            if (isStatic)
                return $"Return the smallest of two {className.ToLower()} values.";
            else
                return $"Return the smallest of this and another {className.ToLower()} value.";
        }
        private static string GetMaxDesc(bool isStatic, string className)
        {
            if (isStatic)
                return $"Return the largest of two {className.ToLower()} values.";
            else
                return $"Return the largest of this and another {className.ToLower()} value.";
        }
        private static string GetClampDesc(bool isStatic, string className)
        {
            return $"Return the result of clamping {(isStatic ? "a" : "this")} {className.ToLower()} value between a min and max value.";
        }

        private static string GetRoundingDesc(string funcName, bool isStatic, string className)
        {
            return $"Return {(isStatic ? "a" : "this")} {className.ToLower()} value rounded {funcName} to the nearest integer.";
        }
        private static string GetRoundDesc(bool isStatic, string className) => GetRoundingDesc("", isStatic, className);
        private static string GetFloorDesc(bool isStatic, string className) => GetRoundingDesc("down", isStatic, className);
        private static string GetCeilDesc(bool isStatic, string className) => GetRoundingDesc("up", isStatic, className);

        private static string GetTrigoDesc(string funcName, bool isStatic, string className)
        {
            return $"Return the {funcName} of {(isStatic ? "a" : "this")} {className.ToLower()} value.";
        }
        private static string GetSinDesc(bool isStatic, string className) => GetTrigoDesc("sine", isStatic, className);
        private static string GetCosDesc(bool isStatic, string className) => GetTrigoDesc("cosine", isStatic, className);
        private static string GetTanDesc(bool isStatic, string className) => GetTrigoDesc("tangent", isStatic, className);
    }
}
