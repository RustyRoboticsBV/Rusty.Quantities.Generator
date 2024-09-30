namespace Generators
{
    /// <summary>
    /// A struct generator.
    /// </summary>
    public abstract class Struct : Id
    {
        /* Constructors. */
        public Struct(string name, string summary) : base(name, summary) { }

        /* Protected methods. */
        protected sealed override string IdContents()
        {
            return "[Serializable]"
                + $"\npublic struct {Name}"
                + "\n{"
                + "\n" + Indent(StructContents())
                + "\n}";
        }

        protected abstract string FieldContents();
        protected abstract string PropertyContents();
        protected abstract string ConstructorContents();
        protected abstract string CastOpContents();
        protected abstract string MathOpContents();
        protected abstract string CompareOpContents();
        protected abstract string MethodContents();

        /* Private methods. */
        private string StructContents()
        {
            return SectionList.Generate(new Section[] {
                new Section("Fields.", FieldContents()),
                new Section("Public properties.", PropertyContents()),
                new Section("Constructors.", ConstructorContents()),
                new Section("Casting operators.", CastOpContents()),
                new Section("Arithmetic operators.", MathOpContents()),
                new Section("Comparison operators.", CompareOpContents()),
                new Section("Public methods.", MethodContents())
            });
        }
    }
}