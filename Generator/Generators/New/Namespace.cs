namespace Generators.New
{
    /// <summary>
    /// The base class for all source generators.
    /// </summary>
    public sealed class Namespace : Id
    {
        /* Public methods. */
        public Generator Contents { get; set; }

        /* Constructors. */
        public Namespace(string name, Generator contents) : base(name, null as Summary)
        {
            Contents = contents;
        }

        /* Public methods. */
        public static string Generate(string name, Generator contents)
        {
            return new Namespace(name, contents).Generate();
        }

        /* Protected methods. */
        protected override string IdContents()
        {
            return $"namespace {Name}"
                + "\n{"
                + "\n" + Indent(Contents.Generate())
                + "\n}";
        }
    }
}