namespace Generators
{
    /// <summary>
    /// A function parameter generator.
    /// </summary>
    public abstract class Parameter : Generator
    {
        /* Public properties. */
        public Type Type { get; set; }
        public string Name { get; set; }

        /* Constructors. */
        public Parameter(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        /* Public methods. */
        public abstract string UnaryOperator(string op);
        public abstract string BinaryOperator(string op, Parameter other);
    }
}