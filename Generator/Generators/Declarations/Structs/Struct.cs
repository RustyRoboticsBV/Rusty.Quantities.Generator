namespace Generators
{
    /// <summary>
    /// A struct generator.
    /// </summary>
    public abstract class Struct : Id
    {
        /* Public properties. */
        public Type Type { get; private set; }

        public Area<Field> Fields { get; private set; } = new();
        public Area<Property> Properties { get; private set; } = new();
        public Area<Constructor> Constructors { get; private set; } = new();
        public Area<CastingOperator> CastingOperators { get; private set; } = new();
        public Area<ArithmeticOperator> ArithmeticOperators { get; private set; } = new();
        public Area<ComparisonOperator> ComparisonOperators { get; private set; } = new();
        public Area<Method> InstanceMethods { get; private set; } = new();
        public Area<Method> StaticMethods { get; private set; } = new();

        /* Public methods. */
        public void AddMethodPair(GeneratorPair<MathdMethod> methodPair)
        {
            InstanceMethods.Add(methodPair.Local);
            StaticMethods.Add(methodPair.Static);
        }

        /* Constructors. */
        public Struct(Type type, string summary) : base(type.Name, summary)
        {
            Type = type;
            Scope = Name;

            Fields.Parent = this;
            Properties.Parent = this;
            Constructors.Parent = this;
            CastingOperators.Parent = this;
            ArithmeticOperators.Parent = this;
            ComparisonOperators.Parent = this;
            InstanceMethods.Parent = this;
            StaticMethods.Parent = this;
        }

        /* Protected methods. */
        protected sealed override string IdContents()
        {
            return "[Serializable]"
                + $"\npublic readonly struct {Name} : IEquatable<{Name}>, IComparable<{Name}>"
                + "\n{"
                + "\n" + Indent(StructContents())
                + "\n}";
        }

        /* Private methods. */
        private string StructContents()
        {
            return SectionList.Generate(new Section[] {
                new Section("Fields.", Fields.Generate()),
                new Section("Public properties.", Properties.Generate()),
                new Section("Constructors.", Constructors.Generate()),
                new Section("Casting operators.", CastingOperators.Generate()),
                new Section("Arithmetic operators.", ArithmeticOperators.Generate()),
                new Section("Comparison operators.", ComparisonOperators.Generate()),
                new Section("Public methods.", InstanceMethods.Generate() + "\n\n" + StaticMethods.Generate())
            });
        }
    }
}