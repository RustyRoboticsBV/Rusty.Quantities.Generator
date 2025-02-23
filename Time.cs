using Rusty.CSharpGenerator;

namespace Rusty.Quantities.Generator
{
    /// <summary>
    /// A generator for the time struct.
    /// </summary>
    public class Time : Quantity
    {
        public Time() : base("Time", "A time quantity.")
        {
            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a distance quantity to a time quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Time",
                Operand = new Parameter("Distance", "value"),
                Implementation = "return new Time(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a speed quantity to a time quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Time",
                Operand = new Parameter("Speed", "value"),
                Implementation = "return new Time(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast an acceleration quantity to a time quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Time",
                Operand = new Parameter("Acceleration", "value"),
                Implementation = "return new Time(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);
        }
    }
}