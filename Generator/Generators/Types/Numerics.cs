namespace Generators
{
    /// <summary>
    /// Contains some global constants.
    /// </summary>
    public static class Numerics
    {
        /* Public properties. */
        public static ScalarNumericType Sbyte => new("sbyte", NumericCategory.Integer, 1);
        public static ScalarNumericType Short => new("short", NumericCategory.Integer, 2);
        public static ScalarNumericType Int => new("int", NumericCategory.Integer, 4);
        public static ScalarNumericType Long => new("long", NumericCategory.Integer, 8, "0L");
        public static ScalarNumericType Byte => new("byte", NumericCategory.Unsigned, 1);
        public static ScalarNumericType Ushort => new("ushort", NumericCategory.Unsigned, 2);
        public static ScalarNumericType Uint => new("uint", NumericCategory.Unsigned, 4, "0u");
        public static ScalarNumericType Ulong => new("ulong", NumericCategory.Unsigned, 8, "0UL");
        public static ScalarNumericType Float => new("float", NumericCategory.Real, 4, "0f");
        public static ScalarNumericType Double => new("double", NumericCategory.Real, 8, "0.0");
        public static ScalarNumericType Decimal => new("decimal", NumericCategory.Decimal, 16, "0m");
        public static ScalarNumericType[] Scalars => new[] { Sbyte, Short, Int, Long, Byte, Ushort, Uint, Ulong, Float, Double, Decimal };

        public static VectorNumericType Vector2 => new("Vector2", Float, 2);
        public static VectorNumericType Vector3 => new("Vector3", Float, 3);
        public static VectorNumericType Vector4 => new("Vector4", Float, 4);
        public static VectorNumericType Vector2I => new("Vector2I", Int, 2);
        public static VectorNumericType Vector3I => new("Vector3I", Int, 3);
        public static VectorNumericType Vector4I => new("Vector4I", Int, 4);
        public static VectorNumericType[] Vectors => new[] { Vector2, Vector3, Vector4, Vector2I, Vector3I, Vector4I, };

        public static VectorNumericType Quaternion => new("Quaternion", Float, 4);
        public static VectorNumericType Plane => new("Plane", Float, 4);

        /// <summary>
        /// The core scalar type that all generated structs are based on.
        /// </summary>
#if DOUBLE_PRECISION
        public static ScalarNumericType Core => Double;
        public static string One => "1.0";
        public static string Pi => "Mathd.Pi";
        public static string TwoPi => $"2.0 * {Pi}";
#else
        public static ScalarNumericType Core => Float;
        public static string One => "1f";
        public static string Pi => "(float)Mathd.Pi";
        public static string TwoPi => $"2f * {Pi}";
#endif
        public static string Zero => Core.Zero;

        /* Public methods. */
        /// <summary>
        /// Whether or not we must use an explicit cast to convert from one numeric scalar to another.
        /// </summary>
        public static bool MustExplicitCast(ScalarNumericType from, ScalarNumericType to)
        {
            return from.MustExplicitCastTo(to);
        }
    }
}