

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for math method blocks.
    /// </summary>
    public class MethodGenerator : Generator
    {
        /* Public methods. */
        public static string GenerateAll(string className)
        {
            return GenerateLocal(className) + "\n\n" + GenerateStatic(className);
        }

        public static string Generate(string prefixes, string returnType, string name, string parameters, string implementation, string summary = null)
        {
            string code = "";
            if (summary != null)
                code += SummaryGenerator.Generate(summary) + "\n";
            code += Indent + $"{prefixes} {returnType} {name}({parameters})"
                + "\n" + Indent + "{"
                + "\n" + Indent + $"    {implementation}"
                + "\n" + Indent + "}";
            return code;
        }

        /* Private methods. */
        private static string GenerateLocal(string className)
        {
            return SignMethodGenerator.GenerateLocal(className)
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Abs", GetAbsDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Truncate", GetTruncateDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Frac", GetFracDesc(false, className))
                + "\n" + MathMethod1Generator.GenerateLocal(className, "Dist", GetDistDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Sqrt", GetSqrtDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Pow2", GetPow2Desc(false, className))
                + "\n" + PowMethodGenerator.GenerateLocal(className)
                + "\n" + MathMethod1Generator.GenerateLocal(className, "Min", GetMinDesc(false, className))
                + "\n" + MathMethod1Generator.GenerateLocal(className, "Max", GetMaxDesc(false, className))
                + "\n" + ClampMethodGenerator.GenerateLocal(className)
                + "\n" + LoopMethodGenerator.GenerateLocal(className)
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Round", GetRoundDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Floor", GetFloorDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Ceil", GetCeilDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Sin", GetSinDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Cos", GetCosDesc(false, className))
                + "\n" + MathMethod0Generator.GenerateLocal(className, "Tan", GetTanDesc(false, className));
        }

        private static string GenerateStatic(string className)
        {
            return SignMethodGenerator.GenerateStatic(className)
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Abs", GetAbsDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Truncate", GetTruncateDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Frac", GetFracDesc(true, className))
                + "\n" + MathMethod1Generator.GenerateStatic(className, "Dist", GetDistDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Sqrt", GetSqrtDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Pow2", GetPow2Desc(true, className))
                + "\n" + PowMethodGenerator.GenerateStatic(className)
                + "\n" + MathMethod1Generator.GenerateStatic(className, "Min", GetMinDesc(true, className))
                + "\n" + MathMethod1Generator.GenerateStatic(className, "Max", GetMaxDesc(true, className))
                + "\n" + ClampMethodGenerator.GenerateStatic(className)
                + "\n" + LoopMethodGenerator.GenerateStatic(className)
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Round", GetRoundDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Floor", GetFloorDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Ceil", GetCeilDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Sin", GetSinDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Cos", GetCosDesc(true, className))
                + "\n" + MathMethod0Generator.GenerateStatic(className, "Tan", GetTanDesc(true, className))
                + "\n" + LerpMethodGenerator.Generate(className);
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
