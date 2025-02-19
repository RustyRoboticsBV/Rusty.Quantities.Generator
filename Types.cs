using System.Collections.Generic;

namespace Rusty.Quantities.Generator
{
    /// <summary>
    /// Some type info used by the generator.
    /// </summary>
    public static class Types
    {
        /* Public properties. */
        public static HashSet<string> QuantityTypes => new HashSet<string>
        {
            "Time", "Distance", "Speed", "Acceleration", "Angle"
        };

        public static HashSet<string> Byte1Types => new HashSet<string>
        {
            "sbyte", "byte"
        };

        public static HashSet<string> Byte2Types => new HashSet<string>
        {
            "short", "ushort"
        };

        public static HashSet<string> Byte4Types => new HashSet<string>
        {
            "int", "uint", "float",
        };

        public static HashSet<string> Byte8Types => new HashSet<string>
        {
            "long", "ulong", "double"
        };

        public static HashSet<string> Byte16Types => new HashSet<string>
        {
            "decimal"
        };

        public static HashSet<string> IntTypes => new HashSet<string>
        {
            "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong"
        };

        public static HashSet<string> FloatTypes => new HashSet<string>
        {
            "float", "double", "decimal"
        };

        public static HashSet<string> SignedTypes => new HashSet<string>
        {
            "sbyte", "short", "int", "long"
        };

        public static HashSet<string> UnsignedTypes => new HashSet<string>
        {
            "byte", "ushort", "uint", "ulong", "char"
        };

        public static HashSet<string> PrimitiveTypes => new HashSet<string>
        {
            "bool",
            "sbyte", "short", "int", "long",
            "byte", "ushort", "uint", "ulong",
            "float", "double", "decimal",
            "char", "string"
        };

        public static HashSet<string> ScalarTypes => new HashSet<string>
        {
            "Time", "Distance", "Speed", "Acceleration", "Angle"
        };

        public static HashSet<string> Vector2Types => new HashSet<string>
        {
            "Distance2D", "Velocity2D", "Acceleration2D"
        };

        public static HashSet<string> Vector3Types => new HashSet<string>
        {
            "Distance3D", "Velocity3D", "Acceleration3D"
        };

        public static Dictionary<string, string> Adjectives => new Dictionary<string, string>
        {
            { "bool", "a" },
            { "sbyte", "an" },
            { "byte", "a" },
            { "short", "a" },
            { "ushort", "an" },
            { "int", "an" },
            { "uint", "an" },
            { "long", "a" },
            { "ulong", "an" },
            { "float", "a" },
            { "double", "a" },
            { "decimal", "a" },
            { "char", "a" },
            { "string", "a" },
            { "Time", "a" },
            { "Distance", "a" },
            { "Speed", "a" },
            { "Acceleration", "an" },
            { "Distance2D", "a" },
            { "Speed2D", "a" },
            { "Acceleration2D", "an" },
            { "Distance3D", "a" },
            { "Speed3D", "a" },
            { "Acceleration3D", "an" }
        };

        public static Dictionary<string, string> Zero => new Dictionary<string, string>
        {
            { "bool", "false" },
            { "sbyte", "0" },
            { "byte", "0u" },
            { "short", "0" },
            { "ushort", "0u" },
            { "int", "0" },
            { "uint", "0u" },
            { "long", "0L" },
            { "ulong", "0UL" },
            { "float", "0f" },
            { "double", "0.0" },
            { "decimal", "0m" },
            { "char", "'0'" },
            { "string", "\"0\"" },
            { "Vector2", "Vector2.Zero" },
            { "Vector3", "Vector3.Zero" },
            { "Quaternion", "Quaternion.FromEuler(Vector3.Zero)" },
            { "Angle", "Angle.Zero" },
            { "Time", "Time.Zero" },
            { "Distance", "Distance.Zero" },
            { "Speed", "Speed.Zero" },
            { "Acceleration", "Acceleration.Zero" },
            { "Distance2D", "Distance2D.Zero" },
            { "Speed2D", "Speed2D.Zero" },
            { "Acceleration2D", "Acceleration2D.Zero" },
            { "Distance3D", "Distance3D.Zero" },
            { "Speed3D", "Speed3D.Zero" },
            { "Acceleration3D", "Acceleration3D.Zero" }
        };

        public static Dictionary<string, string> One => new Dictionary<string, string>
        {
            { "bool", "true" },
            { "sbyte", "1" },
            { "byte", "1u" },
            { "short", "1" },
            { "ushort", "1u" },
            { "int", "1" },
            { "uint", "1u" },
            { "long", "1L" },
            { "ulong", "1UL" },
            { "float", "1f" },
            { "double", "1.0" },
            { "decimal", "1m" },
            { "char", "'1'" },
            { "string", "\"1\"" },
            { "Time", "Time.One" },
            { "Vector2", "Vector2.Zero" },
            { "Vector3", "Vector3.One" },
            { "Quaternion", "Quaternion.FromEuler(Vector3.One)" },
            { "Angle", "Angle.One" },
            { "Distance", "Distance.One" },
            { "Speed", "Speed.One" },
            { "Acceleration", "Acceleration.One" },
            { "Distance2D", "Distance2D.One" },
            { "Speed2D", "Speed2D.One" },
            { "Acceleration2D", "Acceleration2D.One" },
            { "Distance3D", "Distance3D.One" },
            { "Speed3D", "Speed3D.One" },
            { "Acceleration3D", "Acceleration3D.One" }
        };

        /* Public methods. */
        public static int GetSize(string type)
        {
            if (Byte1Types.Contains(type))
                return 1;
            if (Byte2Types.Contains(type))
                return 2;
            if (Byte4Types.Contains(type))
                return 4;
            if (Byte8Types.Contains(type))
                return 8;
            if (Byte16Types.Contains(type))
                return 16;
            return 0;
        }

        public static bool MustCast(string type1, string type2)
        {
            int size1 = GetSize(type1);
            int size2 = GetSize(type2);
            return FloatTypes.Contains(type1) && IntTypes.Contains(type2)
                || SignedTypes.Contains(type1) && UnsignedTypes.Contains(type2)
                || UnsignedTypes.Contains(type1) && SignedTypes.Contains(type2)
                || size1 > size2
                || size2 == 16 && size1 != 16 && FloatTypes.Contains(type1);
        }

        public static string Convert(string value, string fromType, string toType, string scope = "")
        {
            if (scope == "")
                scope = fromType;

            if (fromType == toType)
                return value;

            if (fromType == "bool")
            {
                if (PrimitiveTypes.Contains(toType))
                    return $"{value} ? {Zero[toType]} : {One[toType]}";
            }

            if (toType == "bool")
                return $"{value} != {Zero[fromType]}";

            if (fromType == "char")
            {
                if (PrimitiveTypes.Contains(toType))
                    return $"{toType}({value} - '0')";
            }

            if (toType == "string" && fromType != "string")
                return $"{value}.ToString()";

            if (fromType == "string")
            {
                if (PrimitiveTypes.Contains(toType))
                    return $"({toType}.TryParse({value}, out {toType} result)) ? result : {Zero[toType]}";
            }

            if (PrimitiveTypes.Contains(fromType))
            {
                if (toType == "char")
                    return $"(char)({value} + '0')";

                if (PrimitiveTypes.Contains(toType))
                {
                    if (MustCast(fromType, toType))
                        return $"({toType}){value}";
                    else
                        return value;
                }

                if (ScalarTypes.Contains(toType))
                    return $"new {toType}({value})";

                if (Vector2Types.Contains(toType))
                    return $"new {toType}({value}, {Zero[fromType]})";

                if (Vector3Types.Contains(toType))
                    return $"new {toType}({value}, {Zero[fromType]}, {Zero[fromType]})";
            }

            if (ScalarTypes.Contains(fromType))
            {
                if (scope != fromType)
                    return Convert($"(double){value}", "double", toType, scope);

                if (PrimitiveTypes.Contains(toType))
                    return Convert($"{value}.value", "double", toType);

                if (ScalarTypes.Contains(toType))
                    return $"new {toType}({Convert($"{value}.value", fromType, "double")})";

                if (Vector2Types.Contains(toType))
                    return $"new {toType}({Convert($"{value}.value", fromType, "double")}, 0.0)";

                if (Vector3Types.Contains(toType))
                    return $"new {toType}({Convert($"{value}.value", fromType, "double")}, 0.0, 0.0)";
            }

            return value;
        }
    }
}