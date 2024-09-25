

namespace Generators
{
    public abstract class Generator
    {
        protected static string Indent => new(' ', 8);
        protected static string MethodIndent => new(' ', 12);
    }
}
