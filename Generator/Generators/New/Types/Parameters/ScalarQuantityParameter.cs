namespace Generators
{
    public class ScalarQuantityParameter : ScalarParameter
    {
        /* Public properties. */
        public new ScalarQuantityType Type => base.Type as ScalarQuantityType;

        /* Constructors. */
        public ScalarQuantityParameter(ScalarQuantityType type, string name) : base(type, name) { }
        public ScalarQuantityParameter(string type, string name) : this(new ScalarQuantityType(type), name) { }

        /* Public methods. */
        public static string Generate(ScalarQuantityType type, string text)
        {
            return new ScalarQuantityParameter(type, text).Generate();
        }

        public override string Generate()
        {
            return $"{Type.Name} {Name}";
        }

        public override string CastToCore()
        {
            return Type.CastTo(Name, Numerics.CoreType);
        }
    }
}