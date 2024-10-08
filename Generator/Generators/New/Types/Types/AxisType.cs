namespace Generators
{
    /// <summary>
    /// Represents the Axis enum type.
    /// </summary>
    public class AxisType : Type
    {
        /* Constructors. */
        public AxisType() : base("Axis") { }

        /* Public methods. */
        public override string CastTo(string instanceName, Type to, string scope)
        {

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{instanceName} from {Name} to {to.Name}");
        }
    }
}