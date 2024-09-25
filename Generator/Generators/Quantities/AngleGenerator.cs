using Generators.Scalars;

namespace Generators.Quantities
{
    /// <summary>
    /// A generator for the angle quantity class.
    /// </summary>
    public class AngleGenerator : ClassGenerator
    {
        /* Private properties. */
        private FormulaSet[] Formulas { get; set; }

        /* Constructors. */
        public AngleGenerator(FormulaSet[] formulas)
            : base()
        {
            Formulas = formulas;
        }

        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = new AngleGenerator(formulas).GenerateClass("Angle", "Represents an angle quantity.");

            FileWriter.Write("Angle", code);
        }

        /* Protected methods. */
        protected override string GenerateLocalMethods()
        {
            return base.GenerateLocalMethods()
                + "\n" + GenerateConversionLocal(false)
                + "\n" + GenerateConversionLocal(true);
        }

        protected override string GenerateStaticMethods()
        {
            return base.GenerateStaticMethods()
                + "\n" + GenerateConversionStatic(false)
                + "\n" + GenerateConversionStatic(true);
        }

        /* Private methods. */
        private static string GenerateConversionLocal(bool toRadians)
        {
            string name = toRadians ? "ToRadians" : "ToDegrees";
            string factor = toRadians ? "Deg2Rad" : "Rad2Deg";
            string summary = GetSummary(false, toRadians);
            return MethodGenerator.Generate("public readonly", "Angle", name, "",
                $"return new Angle(Mathd.{factor} * value);", summary);
        }

        private static string GenerateConversionStatic(bool toRadians)
        {
            string name = toRadians ? "ToRadians" : "ToDegrees";
            string factor = toRadians ? "Deg2Rad" : "Rad2Deg";
            string summary = GetSummary(true, toRadians);
            return MethodGenerator.Generate("public static", "Angle", name, $"Angle value",
                $"return new Angle(Mathd.{factor} * value.value);", summary);
        }

        private static string GetSummary(bool isStatic, bool toRadians)
        {
            string from = toRadians ? "degrees" : "radians";
            string to = toRadians ? "radians" : "degrees";
            return $"Return the result of converting {(isStatic ? "an" : "this")} angle from {from} to {to}.";
        }
    }
}
