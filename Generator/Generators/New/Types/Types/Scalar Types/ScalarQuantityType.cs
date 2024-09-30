namespace Generators.New
{
    public class ScalarQuantityType : ScalarType
    {
        public ScalarQuantityType(string name) : this(name, name) { }
        public ScalarQuantityType(string name, string structScope) : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            if (to is ScalarNumericType n)
            {
                if (StructScope == Name)
                {
                    if (to.Name == Numerics.Core)
                        return $"{value}.value";
                    else
                        return $"({n.Name}){value}.value";
                }
                else
                    return $"({n.Name}){value}";
            }
            else if (to is StringType s)
                return $"{value}.ToString()";
            else if (to is ScalarQuantityType scalar)
            {
                if (Name == scalar.Name)
                    return value;
                else if (StructScope == Name)
                    return $"new {scalar.Name}({value}.value)";
                else
                    return $"new {scalar.Name}(({Numerics.Core}){value})";
            }
            else
                throw new ArgumentOutOfRangeException(value + " from " + Name + " to " + to.Name);
        }

        public override Type Rescope(string scope)
        {
            return new ScalarQuantityType(Name, scope);
        }
    }
}