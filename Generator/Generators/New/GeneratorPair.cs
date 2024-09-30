namespace Generators.New
{
    /// <summary>
    /// A generator that can expand to either a local or static variant.
    /// </summary>
    public class GeneratorPair<T> : Generator
        where T : Generator
    {
        /* Public properties. */
        public T Local { get; set; }
        public T Static { get; set; }
        public bool IsStatic { get; set; }

        /* Constructors. */
        public GeneratorPair(T local, T @static, bool isStatic = false)
        {
            Local = local;
            Static = @static;
            IsStatic = isStatic;
        }

        /* Public methods. */
        public override string Generate()
        {
            if (IsStatic)
                return Static.Generate();
            else
                return Local.Generate();
        }

        public string Generate(bool isStatic)
        {
            IsStatic = isStatic;
            return Generate();
        }
    }
}