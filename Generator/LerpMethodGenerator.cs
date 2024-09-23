

namespace Quantities
{
    public static class LerpMethodGenerator
    {
        public static string Generate(string className, string desc)
        {
            return MethodGenerator.GenerateSummary(desc)
                + "\n" + Generator.Indent + $"public static {className} Lerp({className} min, {className} max, double factor) => new {className}(Mathd.Lerp(min.value, max.value, factor));";
        }
    }
}
