

namespace Quantities
{
    public static class StaticPropertyGenerator
    {
        public static string Generate(string returnType, string propertyName, string args)
        {
            return Generator.Indent + $"public static {returnType} {propertyName} => new {returnType}({args});";
        }
    }
}
