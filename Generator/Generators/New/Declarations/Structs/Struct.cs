namespace Generators
{
    /// <summary>
    /// A struct generator.
    /// </summary>
    public abstract class Struct : Id
    {
        /* Public properties. */
        public Area<Field> Fields { get; set; }
        public Area<Property> Properties { get; set; }
        public Area<Constructor> Constructors { get; set; }
        public Area<CastingOperator> CastingOperators { get; set; }
        public Area<ArithmeticOperator> ArithmeticOperators { get; set; }
        public Area<ComparisonOperator> ComparisonOperators { get; set; }
        public Area<Method> InstanceMethods { get; set; }
        public Area<Method> StaticMethods { get; set; }

        /* Public methods. */
        public void AddMethodPair(GeneratorPair<Method> methodPair)
        {
            InstanceMethods.Add(methodPair.Local);
            StaticMethods.Add(methodPair.Static);
        }

        /* Constructors. */
        public Struct(string name, string summary) : base(name, summary)
        {
            Fields = new(name);
            Properties = new(name);
            Constructors = new(name);
            CastingOperators = new(name);
            ArithmeticOperators = new(name);
            ComparisonOperators = new(name);
            InstanceMethods = new(name);
            StaticMethods = new(name);
        }

        /* Protected methods. */
        protected sealed override string IdContents()
        {
            return "[Serializable]"
                + $"\npublic readonly struct {Name} : IEquatable<{Name}>"
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