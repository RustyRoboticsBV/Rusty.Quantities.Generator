using Generators.Generic;
using Generators.Scalars;

namespace Generators.Vectors
{
    /// <summary>
    /// A generator for the velocity quantity class.
    /// </summary>
    public class VelocityGenerator : ClassGenerator
    {
        /* Private properties. */
        private FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public VelocityGenerator(FormulaSet[] formulas)
            : base("Velocity", "Speed", "Represents a 3D speed quantity vector.")
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = new VelocityGenerator(formulas).GenerateClass();

            FileWriter.Write("Velocity", code);
        }

        /* Protected methods. */
        protected override string GenerateArithmetic()
        {
            string code = MathOperatorGenerator.Generate(
                    "Motion", "*", "Velocity a, Time b", "return new Motion(a.x * b, a.y * b, a.z * b);"
                )
                + "\n" + MathOperatorGenerator.Generate(
                    "Motion", "*", "Time a, Velocity b", "return new Motion(a * b.x, a * b.y, a * b.z);"
                );
            return base.GenerateArithmetic() + code + "\n";
        }

        protected override string GenerateLocalMethods()
        {
            string code = MethodGenerator.Generate("public readonly",
                    "Velocity",
                    "AccelerateTowards",
                    "Velocity to, Acceleration acceleration, Time time",
                    "return Step(to, acceleration * time * One);",
                    "Move towards some velocity value, using an acceleration and time.");

            return base.GenerateLocalMethods() + "\n\n" + code;
        }

        protected override string GenerateStaticMethods()
        {
            return base.GenerateStaticMethods();
        }
    }
}
