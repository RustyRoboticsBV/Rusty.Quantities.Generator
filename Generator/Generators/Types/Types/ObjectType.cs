using System;

namespace Generators
{
    /// <summary>
    /// Represents the System.Object type.
    /// </summary>
    public class ObjectType : Type
    {
        /* Constructors. */
        public ObjectType() : base("object") { }

        /* Public methods. */
        public override string CastTo(string instanceName, Type to, string scope)
        {
            throw new NotImplementedException();
        }
    }
}