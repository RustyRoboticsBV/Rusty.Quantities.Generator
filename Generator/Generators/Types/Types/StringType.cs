using System;

namespace Generators
{
    /// <summary>
    /// Represents the System.String type.
    /// </summary>
    public class StringType : Type
    {
        /* Constructors. */
        public StringType() : base("string") { }

        /* Public methods. */
        public override string CastTo(string instanceName, Type to, string scope)
        {

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{instanceName} from {Name} to {to.Name}");
        }
    }
}