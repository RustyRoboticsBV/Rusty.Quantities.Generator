namespace Generators
{
    /// <summary>
    /// A variable generator.
    /// </summary>
    public abstract class Variable : Generator
    {
        /* Public properties. */
        public Type Type { get; set; }
        public string Name { get; set; }

        /* Constructors. */
        public Variable(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        /* Public methods. */
        /// <summary>
        /// Generate code for converting this variable to some other type.
        /// Results in either a cast, a new statement or a ToString method call.
        /// </summary>
        public string CastTo(Type type)
        {
            return Type.CastTo(Name, type, GetScope());
        }

        /// <summary>
        /// Generate code for returning this variable.
        /// </summary>
        public string Return(Type returnType)
        {
            return $"return {CastTo(returnType)};"; 
        }

        /// <summary>
        /// Generate code for declaring this variable.
        /// </summary>
        public override string Generate()
        {
            return $"{Type.Name} {Name}";
        }
    }
}