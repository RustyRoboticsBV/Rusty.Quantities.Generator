using Generators.Generic;

namespace Generators.Vectors
{
    /// <summary>
    /// A generator for comparison operators.
    /// </summary>
    public class ComparisonOperatorGenerator : Generator
    {
        /* Public methods. */
        public static string Generate(string type1, string type2, string opName, string term1, string term2, string summary = null)
        {
            return OperatorGenerator.Generate(
                null,
                "bool",
                opName,
                $"{type1} a, {type2} b",
                $"return {term1}.x {opName} {term2}.x && {term1}.y {opName} {term2}.y && {term1}.z {opName} {term2}.z;",
                summary);
        }
    }
}
