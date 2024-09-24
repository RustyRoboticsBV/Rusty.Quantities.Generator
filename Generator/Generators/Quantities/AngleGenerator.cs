

namespace Generators
{
    /// <summary>
    /// A generator for the angle quantity class.
    /// </summary>
    public class AngleGenerator : Generator
    {
        /* Public methods. */
        public static void Generate()
        {
            string code = ClassGenerator.Generate("Angle", "Represents a angle quantity.");

            string props = "";
            code = code.Replace("//PROPS", props);

            string casts = "";
            code = code.Replace("//CASTS", casts);

            string math = "";
            code = code.Replace("//MATH", math);

            string methods = GenerateConversionLocal(false)
                + "\n" + GenerateConversionLocal(true)
                + "\n\n" + GenerateConversionStatic(false)
                + "\n" + GenerateConversionStatic(true);
            code = code.Replace("//METHODS", methods);

            FileWriter.Write("Angle", code);
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
