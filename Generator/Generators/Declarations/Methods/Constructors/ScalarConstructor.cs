namespace Generators
{
    public class ScalarConstructor : Constructor
    {
        /* Constructors. */
        public ScalarConstructor(string name, ScalarNumericParameter value) : base(name, value, "") { }
        public ScalarConstructor(string name, ScalarQuantityParameter value) : base(name, value, "") { }

        /* Protected methods. */
        protected override string IdContents()
        {
            Implementation = GetImpl();
            return base.IdContents();
        }

        /* Private methods. */
        private string GetImpl()
        {
            return $"this.value = {Parameters[0].CastTo(Numerics.Core)};";
        }
    }
}