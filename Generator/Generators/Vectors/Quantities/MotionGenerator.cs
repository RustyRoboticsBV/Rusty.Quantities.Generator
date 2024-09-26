using Generators.Generic;
using Generators.Scalars;

namespace Generators.Vectors
{
    /// <summary>
    /// A generator for the distance quantity class.
    /// </summary>
    public class MotionGenerator : ClassGenerator
    {
        /* Private properties. */
        private FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public MotionGenerator(FormulaSet[] formulas)
            : base("Motion", "Distance", "Represents a 3D distance quantity vector.")
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = new MotionGenerator(formulas).GenerateClass();

            FileWriter.Write("Motion", code);
        }

        /* Protected methods. */
        protected override string GenerateArithmetic()
        {
            string code = MathOperatorGenerator.Generate(
                "Velocity", "/", "Motion a, Time b", "return new Velocity(a.x / b, a.y / b, a.z / b);"
            );
            return base.GenerateArithmetic() + code + "\n";
        }

        protected override string GenerateLocalMethods()
        {
            string code = MethodGenerator.Generate("public readonly",
                    "Motion",
                    "MoveTowards",
                    "Motion to, Speed speed, Time time",
                    "return Step(to, speed * One * time);",
                    "Move towards some motion value, using a speed and time.") + "\n"
                + MethodGenerator.Generate("public readonly",
                    "Motion",
                    "MoveTowards",
                    "Motion to, Velocity velocity, Time time",
                    "return Step(to, velocity * time);",
                    "Move towards some motion value, using a velocity and time.");

            return base.GenerateLocalMethods() + "\n\n" + code;
        }

        protected override string GenerateStaticMethods()
        {
            return base.GenerateStaticMethods();
        }
    }
}
