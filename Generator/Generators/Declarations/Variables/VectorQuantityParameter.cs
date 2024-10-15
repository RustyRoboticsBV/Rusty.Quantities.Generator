namespace Generators
{
    public class VectorQuantityParameter : VectorParameter
    {
        /* Public properties. */
        public new VectorQuantityType Type => base.Type as VectorQuantityType;

        /* Constructors. */
        public VectorQuantityParameter(VectorQuantityType type, string name) : base(type, name) { }

        /* Public methods. */
        public override string CastXTo(Type to)
        {
            if (GetScope() == Type.Name)
                return Numerics.Core.CastTo(Name + ".x", to, GetScope());
            else
                return base.CastXTo(to);
        }

        public override string CastYTo(Type to)
        {
            if (GetScope() == Type.Name)
                return Numerics.Core.CastTo(Name + ".y", to, GetScope());
            else
                return base.CastXTo(to);
        }

        public override string CastZTo(Type to)
        {
            if (GetScope() == Type.Name)
                return Numerics.Core.CastTo(Name + ".z", to, GetScope());
            else
                return base.CastXTo(to);
        }

        public override string CastWTo(Type to)
        {
            if (GetScope() == Type.Name)
                return Numerics.Core.CastTo(Name + ".w", to, GetScope());
            else
                return base.CastXTo(to);
        }
    }
}