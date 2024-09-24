﻿

namespace Generators
{
    /// <summary>
    /// A generator for math methods with two arguments in the static version.
    /// </summary>
    public class Method2Generator : Generator
    {
        /* Public methods. */
        public static string GenerateLocal(string className, string methodName, string desc)
        {
            return SummaryGenerator.Generate(desc)
                + "\n" + Indent + $"public readonly {className} {methodName}({className} other) => new {className}(Mathd.{methodName}(value, other.value));";
        }

        public static string GenerateStatic(string className, string methodName, string desc)
        {
            return SummaryGenerator.Generate(desc)
                + "\n" + Indent + $"public static {className} {methodName}({className} a, {className} b) => new {className}(Mathd.{methodName}(a.value, b.value));";
        }
    }
}
