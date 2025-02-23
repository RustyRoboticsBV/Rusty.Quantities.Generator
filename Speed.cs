using Rusty.CSharpGenerator;

namespace Rusty.Quantities.Generator
{
    /// <summary>
    /// A generator for the speed struct.
    /// </summary>
    public class Speed : Quantity
    {
        public Speed() : base("Speed", "A speed quantity.")
        {
            // Casting operators.
            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a time quantity to a speed quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Speed",
                Operand = new Parameter("Time", "value"),
                Implementation = "return new Speed(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast a distance quantity to a speed quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Speed",
                Operand = new Parameter("Distance", "value"),
                Implementation = "return new Speed(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            CastOperators.Members.Elements.Add(new CastingOperator()
            {
                Summary = "Cast an acceleration quantity to a speed quantity.",
                Modifier = CastingModifierID.Explicit,
                ReturnType = "Speed",
                Operand = new Parameter("Acceleration", "value"),
                Implementation = "return new Speed(value.Value);"
            });
            CastOperators.Members.Elements.Add(Empty.Get);

            // Inter-quantity methods.
            Methods.Members.Elements.Add(new Method()
            {
                Summary = "Return the result of accelerating towards a target speed, using some acceleration and delta time.",
                Name = "AccelerateTowards",
                Modifiers = MethodModifierID.Readonly,
                ReturnType = "Speed",
                Parameters = new Parameter[3]
                {
                    new("Speed", "targetSpeed"),
                    new("Acceleration", "acceleration"),
                    new("Time", "time")
                },
                Implementation =
                      "if (this < targetSpeed)"
                    + "\n    return Min(targetSpeed, this + (double)acceleration.Abs() * (double)time);"
                    + "\nif (this > targetSpeed)"
                    + "\n    return Max(targetSpeed, this - (double)acceleration.Abs() * (double)time);"
                    + "\nelse"
                    + "\n    return targetSpeed;"
            });
            Methods.Members.Elements.Add(Empty.Get);
        }
    }
}