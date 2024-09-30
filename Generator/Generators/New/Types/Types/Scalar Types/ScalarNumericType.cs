namespace Generators
{
    public class ScalarNumericType : ScalarType
    {
        public ScalarNumericType(string name) : this(name, name) { }
        public ScalarNumericType(string name, string structScope = "") : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            if (to is ScalarNumericType toN)
            {
                if (Numerics.MustCast(Name, toN.Name))
                    return $"({toN.Name}){value}";
                else
                    return value;
            }
            else if (to is StringType)
                return $"{value}.ToString()";
            else if (to is ScalarQuantityType toS)
            {
                if (Numerics.MustCast(Name, Numerics.Core))
                    return $"new {toS.Name}(({Numerics.Core}){value})";
                else
                    return $"new {toS.Name}({value})";
            }
            else if (to is VectorQuantityType toV)
                return $"new {toV.Name}({value}, {value}, {value})";
            throw new InvalidCastException();
        }

        public override Type Rescope(string scope)
        {
            return new ScalarNumericType(Name, scope);
        }
    }
}