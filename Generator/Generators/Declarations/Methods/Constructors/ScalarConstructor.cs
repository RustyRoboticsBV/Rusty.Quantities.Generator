namespace Generators
{
    public class ScalarConstructor : Constructor
    {
        /* Constructors. */
        public ScalarConstructor(string name, ScalarParameter value) : base(name, value, "") { }

        /* Protected methods. */
        protected override string IdContents()
        {
            Implementation = GetImpl();
            return base.IdContents();
        }

        /* Private methods. */
        private string GetImpl()
        {
            if (Parameters[0].Name == "value")
                return $"this.value = {Parameters[0].CastTo(Numerics.Core)};";
            else
                return $"value = {Parameters[0].CastTo(Numerics.Core)};";
        }
    }
}