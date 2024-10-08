namespace Generators
{
    /// <summary>
    /// Represents a C# type.
    /// </summary>
    public abstract class Type
    {
        /* Public properties. */
        /// <summary>
        /// The name of the C# type.
        /// </summary>
        public string Name { get; set; }

        /* Constructors. */
        public Type(string name)
        {
            Name = name;
        }

        /* Public methods. */
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Generate code for creating a new instance of some type from an instance of this type.
        /// This can result in either a cast, a new statement or a ToString method call, depending on the types.
        /// </summary>
        public abstract string CastTo(string instanceName, Type to, string scope);

        /// <summary>
        /// Generate code for returning a variable of this type.
        /// </summary>
        public string Return(string instanceName, Type to, string scope)
        {
            return $"return {CastTo(instanceName, to, scope)};";
        }
    }
}