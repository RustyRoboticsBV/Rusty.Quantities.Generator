namespace Generators.New
{
    /// <summary>
    /// A base class for all identifier generator, such as namespaces, classes, methods, operators, properties and fields.
    /// </summary>
    public abstract class Id : Generator
    {
        /* Public properties. */
        public string Name { get; set; }
        public Summary? Summary { get; set; }

        /* Constructors. */
        public Id(string name, Summary? summary)
        {
            Name = name;
            Summary = summary;
        }

        public Id(string name) : this(name, null) { }

        /* Public methods. */
        public sealed override string Generate()
        {
            if (Summary != null && Summary.Text != null)
                return Summary.Generate() + "\n" + IdContents();
            else
                return IdContents();
        }

        /* Protected methods. */
        protected abstract string IdContents();
    }
}