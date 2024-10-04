namespace Generators
{
    /// <summary>
    /// A angle quantity struct generator.
    /// </summary>
    public sealed class Angle : ScalarQuantityStruct
    {
        /* Constructors. */
        public Angle() : base("Angle", "Represents an angle quantity.") { }

        /* Protected methods. */
        protected override string MethodContents()
        {
            string code = "";
            code += Method.Generate("public", "readonly", "Angle", "ToDegrees", new(), "return Mathd.Rad2Deg * value;", "Return this angle converted from radians to degrees.");
            code += "\n" + Method.Generate("public", "readonly", "Angle", "ToRadians", new(), "return Mathd.Deg2Rad * value;", "Return this angle converted degrees to radians.");
            return base.MethodContents() + "\n\n" + code;
        }
    }
}