using Rusty.CSharpGenerator;

namespace Rusty.Quantities.Generator
{
    /// <summary>
    /// A generator for the distance struct.
    /// </summary>
    public class Distance : Quantity
    {
        public Distance() : base("Distance", "A distance quantity.")
        {
            // Casting operators.
            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a time quantity to a distance quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Distance",
                Operand = new Parameter("Time", "value"),
                Implementation = "return new Distance(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a speed quantity to a distance quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Distance",
                Operand = new Parameter("Speed", "value"),
                Implementation = "return new Distance(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast an acceleration quantity to a distance quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Distance",
                Operand = new Parameter("Acceleration", "value"),
                Implementation = "return new Distance(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            // Inter-quantity methods.
            Methods.Members.Elements.Add(new Method()
            {
                Summary = "Return the result of speeding towards a target distance, using some speed and delta time.",
                Name = "SpeedTowards",
                Modifiers = MethodModifierID.Readonly,
                ReturnType = "Distance",
                Parameters = new Parameter[3]
                {
                    new("Distance", "targetDistance"),
                    new("Speed", "speed"),
                    new("Time", "time")
                },
                Implementation =
                      "if (this < targetDistance)"
                    + "\n    return Min(targetDistance, this + (double)speed.Abs() * (double)time);"
                    + "\nif (this > targetDistance)"
                    + "\n    return Max(targetDistance, this - (double)speed.Abs() * (double)time);"
                    + "\nelse"
                    + "\n    return targetDistance;"
            });
            Methods.Members.Elements.Add(Empty.Get);
        }
    }
}