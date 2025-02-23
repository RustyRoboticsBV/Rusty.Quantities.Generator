using Rusty.CSharpGenerator;

namespace Rusty.Quantities.Generator
{
    /// <summary>
    /// A generator for the acceleration struct.
    /// </summary>
    public class Acceleration : Quantity
    {
        public Acceleration() : base("Acceleration", "An acceleration quantity.")
        {
            // Casting operators.
            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a time quantity to an acceleration quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Acceleration",
                Operand = new Parameter("Time", "value"),
                Implementation = "return new Acceleration(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a distance quantity to an acceleration quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Acceleration",
                Operand = new Parameter("Distance", "value"),
                Implementation = "return new Acceleration(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a speed quantity to an acceleration quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Acceleration",
                Operand = new Parameter("Speed", "value"),
                Implementation = "return new Acceleration(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

        }
    }
}