

namespace Generators.Scalars
{
    /// <summary>
    /// A generator for a quantity class.
    /// </summary>
    public class ClassGenerator : Generic.ClassGenerator
    {
        /* Public methods. */
        public static string Generate(string className, string desc)
        {
            ClassGenerator generator = new ClassGenerator();
            return generator.GenerateClass(className, desc);
        }

        /* Protected methods. */
        protected override string GenerateField()
        {
            return Indent + "private double value;";
        }

        protected override string GenerateProperties()
        {
            return QuantityPropertyGenerator.Generate(ClassName, "Zero", "0.0", "0")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "One", "1.0", "1")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "Pi", "Mathd.Pi", "pi")
            + "\n" + QuantityPropertyGenerator.Generate(ClassName, "TwoPi", "2.0 * Mathd.Pi", "2 * pi")
            + "\n";
        }

        protected override sealed string GenerateConstructor()
        {
            return Indent + $"public {ClassName}(double value)"
            + "\n" + Indent + "{"
            + "\n" + MethodIndent + "this.value = value;"
            + "\n" + Indent + "}"
            + "\n";
        }

        protected override sealed string GenerateCasting()
        {
            return CastOperatorGenerator.Generate(ClassName) + "\n";
        }

        protected override string GenerateArithmetic()
        {
            return MathOperatorGenerator.Generate(ClassName) + "\n";
        }

        protected override sealed string GenerateComparison()
        {
            return ComparisonOperatorBlockGenerator.Generate(ClassName) + "\n";
        }

        protected override string GenerateLocalMethods()
        {
            return MethodGenerator.Generate("public override readonly", "bool", "Equals", "object? obj", $"return obj is {ClassName} {ClassName.ToLower()} && this == {ClassName.ToLower()};")
                + "\n" + MethodGenerator.Generate("public override readonly", "int", "GetHashCode", "", "return value.GetHashCode();")
                + "\n" + MethodGenerator.Generate("public override readonly", "string", "ToString", "", "return value.ToString();")
                + "\n"
                + "\n" + SignMethodGenerator.GenerateLocal(ClassName)
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Abs", GetAbsDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Truncate", GetTruncateDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Frac", GetFracDesc(false, ClassName))
                + "\n" + MathMethod1Generator.GenerateLocal(ClassName, "Dist", GetDistDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Sqrt", GetSqrtDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Pow2", GetPow2Desc(false, ClassName))
                + "\n" + PowMethodGenerator.GenerateLocal(ClassName)
                + "\n" + MathMethod1Generator.GenerateLocal(ClassName, "Min", GetMinDesc(false, ClassName))
                + "\n" + MathMethod1Generator.GenerateLocal(ClassName, "Max", GetMaxDesc(false, ClassName))
                + "\n" + ClampMethodGenerator.GenerateLocal(ClassName)
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Round", GetRoundDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Floor", GetFloorDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Ceil", GetCeilDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Sin", GetSinDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Cos", GetCosDesc(false, ClassName))
                + "\n" + MathMethod0Generator.GenerateLocal(ClassName, "Tan", GetTanDesc(false, ClassName))
                + "\n" + WrapMethodGenerator.GenerateLocal(ClassName)
                + "\n" + MathMethod2Generator.GenerateLocal(ClassName, "PingPong", GetPingPongDesc(false, ClassName))
                + "\n" + MathMethod2Generator.GenerateLocal(ClassName, "Snap", "offset", "size", GetSnapDesc(false, ClassName))
                + "\n" + MathMethod4Generator.GenerateLocal(ClassName, "Map", GetMapDesc(false, ClassName));
        }

        protected override string GenerateStaticMethods()
        {
            return SignMethodGenerator.GenerateStatic(ClassName)
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Abs", GetAbsDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Truncate", GetTruncateDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Frac", GetFracDesc(true, ClassName))
                + "\n" + MathMethod1Generator.GenerateStatic(ClassName, "Dist", GetDistDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Sqrt", GetSqrtDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Pow2", GetPow2Desc(true, ClassName))
                + "\n" + PowMethodGenerator.GenerateStatic(ClassName)
                + "\n" + MathMethod1Generator.GenerateStatic(ClassName, "Min", GetMinDesc(true, ClassName))
                + "\n" + MathMethod1Generator.GenerateStatic(ClassName, "Max", GetMaxDesc(true, ClassName))
                + "\n" + ClampMethodGenerator.GenerateStatic(ClassName)
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Round", GetRoundDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Floor", GetFloorDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Ceil", GetCeilDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Sin", GetSinDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Cos", GetCosDesc(true, ClassName))
                + "\n" + MathMethod0Generator.GenerateStatic(ClassName, "Tan", GetTanDesc(true, ClassName))
                + "\n" + WrapMethodGenerator.GenerateStatic(ClassName)
                + "\n" + MathMethod2Generator.GenerateStatic(ClassName, "PingPong", GetPingPongDesc(true, ClassName))
                + "\n" + MathMethod2Generator.GenerateStatic(ClassName, "Snap", GetSnapDesc(true, ClassName))
                + "\n" + MathMethod4Generator.GenerateStatic(ClassName, "Map", GetMapDesc(true, ClassName))
                + "\n" + LerpMethodGenerator.Generate(ClassName);
        }

        /* Private methods. */
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

        private static string GetPingPongDesc(bool isStatic, string className)
        {
            return $"Return the result of mapping {(isStatic ? "a" : "this")} {className.ToLower()} value to the specified, ping-ponging range.";
        }
        private static string GetSnapDesc(bool isStatic, string className)
        {
            return $"Return the result of snapping {(isStatic ? "a" : "this")} {className.ToLower()} value to the specified interval.";
        }
        private static string GetMapDesc(bool isStatic, string className)
        {
            return $"Return the result of mapping {(isStatic ? "a" : "this")} {className.ToLower()} value from the specified source range to the specified target range.";
        }

        private static string GetTrigoDesc(string funcName, bool isStatic, string className)
        {
            return $"Return the {funcName} of {(isStatic ? "a" : "this")} {className.ToLower()} value.";
        }
        private static string GetSinDesc(bool isStatic, string className) => GetTrigoDesc("sine", isStatic, className);
        private static string GetCosDesc(bool isStatic, string className) => GetTrigoDesc("cosine", isStatic, className);
        private static string GetTanDesc(bool isStatic, string className) => GetTrigoDesc("tangent", isStatic, className);
    }
}
