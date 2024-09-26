namespace Generators.New
{
    /// <summary>
    /// A struct generator.
    /// </summary>
    public abstract class Struct : Id
    {
        /* Constructors. */
        public Struct(string name, string? summary) : base(name, summary) { }

        /* Protected methods. */
        protected sealed override string IdContents()
        {
            return $"public class {Name}"
                + "\n{"
                + "\n" + Indent(StructContents())
                + "\n}";
        }

        protected abstract string FieldContents();
        protected abstract string PropertyContents();
        protected abstract string CastOpContents();
        protected abstract string MathOpContents();
        protected abstract string CompareOpContents();
        protected abstract string MethodContents();

        /* Private methods. */
        private string StructContents()
        {
            return MultiLineComment.Generate("Fields.")
                + "\n" + FieldContents()
                + "\n" + MultiLineComment.Generate("Public properties.")
                + "\n" + PropertyContents()
                + "\n" + MultiLineComment.Generate("Casting operators.")
                + "\n" + CastOpContents()
                + "\n" + MultiLineComment.Generate("Arithmetic operators.")
                + "\n" + MathOpContents()
                + "\n" + MultiLineComment.Generate("Comparison operators.")
                + "\n" + CompareOpContents()
                + "\n" + MultiLineComment.Generate("Public methods.")
                + "\n" + MethodContents();
        }
    }
}