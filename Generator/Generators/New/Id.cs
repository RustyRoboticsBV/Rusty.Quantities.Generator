namespace Generators.New
{
    /// <summary>
    /// A base class for all identifier generator, such as namespaces, classes, methods, operators, properties and fields.
    /// </summary>
    public abstract class Id : Generator
    {
        /* Public properties. */
        public string Name { get; set; }
        public Summary Summary { get; set; }

        /* Constructors. */
        public Id(string name, string? summary)
        {
            Name = name;
            Summary = new Summary(summary);
        }

        /* Protected methods. */
        protected sealed override string Generate()
        {
            if (Summary.Text != null)
                return Summary.Generate() + "\n" + IdContents();
            else
                return IdContents();
        }

        protected abstract string IdContents();
    }
}