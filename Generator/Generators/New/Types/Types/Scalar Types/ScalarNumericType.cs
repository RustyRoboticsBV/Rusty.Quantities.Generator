namespace Generators
{
    public class ScalarNumericType : ScalarType
    {
        public ScalarNumericType(string name) : this(name, name) { }
        public ScalarNumericType(string name, string structScope) : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            // Scalar numerics.
            if (to is ScalarNumericType sn)
            {
                if (Numerics.MustCast(Name, sn.Name))
                    return $"({sn.Name}){value}";
                else
                    return value;
            }

            // Scalar quantities.
            else if (to is ScalarQuantityType sq)
            {
                if (Numerics.MustCast(Name, Numerics.Core))
                    return $"new {sq.Name}(({Numerics.Core}){value})";
                else
                    return $"new {sq.Name}({value})";
            }

            // Vector numerics.
            else if (to is VectorNumericType vn)
                return $"new {vn.Name}({value}, {value}, {value})";

            // Vector quantities.
            else if (to is VectorQuantityType vq)
                return $"new {vq.Name}({value}, {value}, {value})";

            // Strings.
            else if (to is StringType)
                return $"{value}.ToString()";

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{value} from {Name} to {to.Name}");
        }

        public override Type Rescope(string scope)
        {
            return new ScalarNumericType(Name, scope);
        }
    }
}