namespace Generators
{
    public class ScalarNumericParameter : ScalarParameter
    {
        /* Constructors. */
        public ScalarNumericParameter(ScalarNumericType type, string name)
            : base(type, name) { }

        public ScalarNumericParameter(string type, string name)
            : this(new ScalarNumericType(type), name) { }

        /* Public methods. */
        public static string Generate(ScalarNumericType type, string name)
        {
            return new ScalarNumericParameter(type, name).Generate();
        }

        public override string Generate()
        {
            return $"{Type.Name} {Name}";
        }

        public override string ToNumeric()
        {
            return Type.CastTo($"{Name}", new ScalarNumericType(Numerics.Core, Type.StructScope));
        }
    }
}