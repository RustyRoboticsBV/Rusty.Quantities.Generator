namespace Generators
{
    public class ScalarQuantityType : ScalarType
    {
        public ScalarQuantityType(string name) : this(name, name) { }
        public ScalarQuantityType(string name, string structScope) : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            // Scalar numerics.
            if (to is ScalarNumericType sn)
            {
                if (Scope == Name)
                {
                    if (to.Name == Numerics.Core)
                        return $"{value}.value";
                    else
                        return $"({sn.Name}){value}.value";
                }
                else
                    return $"({sn.Name}){value}";
            }

            // Scalar quantities.
            else if (to is ScalarQuantityType sq)
            {
                if (Name == sq.Name)
                    return value;
                else if (Scope == Name)
                    return $"new {sq.Name}({value}.value)";
                else
                    return $"new {sq.Name}(({Numerics.Core}){value})";
            }

            // Vector numerics.
            else if (to is VectorNumericType vn)
            {
                string cast = CastTo(value, Numerics.CoreType);
                return $"new {vn.Name}({cast}, {cast}, {cast})";
            }

            // Vector quantities.
            else if (to is VectorQuantityType vq)
            {
                return $"new {vq.Name}({value}, {value}, {value})";
            }

            // Strings.
            else if (to is StringType)
                return $"{value}.ToString()";

            // Invalid types.
            else
                throw new ArgumentOutOfRangeException($"{value} from {Name} to {to.Name}");
        }

        public override Type Rescope(string scope)
        {
            return new ScalarQuantityType(Name, scope);
        }
    }
}