

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

            string methods = GenerateToDegreesLocal() + "\n" + GenerateToRadiansLocal()
                + "\n\n" + GenerateToDegreesStatic() + "\n" + GenerateToRadiansStatic();
            code = code.Replace("//METHODS", methods);

            FileWriter.Write("Angle", code);
        }

        /* Private methods. */
        private static string GenerateToDegreesLocal()
        {
            return MethodGenerator.GenerateSummary(GenerateToDegreesDesc(false))
                + "\n" + Indent + "public readonly Angle ToDegrees() => new Angle(Mathd.Rad2Deg * value);";
        }

        private static string GenerateToDegreesStatic()
        {
            return MethodGenerator.GenerateSummary(GenerateToDegreesDesc(true))
                + "\n" + Indent + "public static Angle ToDegrees(Angle value) => new Angle(Mathd.Rad2Deg * value.value);";
        }

        private static string GenerateToDegreesDesc(bool isStatic)
        {
            return $"Return the result of converting {(isStatic ? "an" : "this")} angle from radians to degrees.";
        }

        private static string GenerateToRadiansLocal()
        {
            return MethodGenerator.GenerateSummary(GenerateToRadiansDesc(false))
                + "\n" + Indent + "public readonly Angle ToRadians() => new Angle(Mathd.Deg2Rad * value);";
        }

        private static string GenerateToRadiansStatic()
        {
            return MethodGenerator.GenerateSummary(GenerateToRadiansDesc(true))
                + "\n" + Indent + "public static Angle ToRadians(Angle value) => new Angle(Mathd.Deg2Rad * value.value);";
        }

        private static string GenerateToRadiansDesc(bool isStatic)
        {
            return $"Return the result of converting {(isStatic ? "an" : "this")} angle from radians to radians.";
        }
    }
}
