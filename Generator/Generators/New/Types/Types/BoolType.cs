namespace Generators
{
    /// <summary>
    /// Represents the System.Boolean type.
    /// </summary>
    public class BoolType : Type
    {
        /* Constructors. */
        public BoolType() : base("bool") { }

        /* Public methods. */
        public override string CastTo(string instanceName, Type to, string scope)
        {

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{instanceName} from {Name} to {to.Name}");
        }
    }
}