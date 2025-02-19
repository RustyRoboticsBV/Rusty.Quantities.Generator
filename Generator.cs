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
            "sbyte", "short", "int", "long", "float", "double", "decimal"
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
            "Time", "Distance", "Speed", "Acceleration"
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

        public static string Convert(string value, string fromType, string toType)
        {
            if (toType == "bool")
            {
                if (PrimitiveTypes.Contains(fromType))
                    return $"{value} != 0.0";

                if (ScalarTypes.Contains(fromType) || Vector2Types.Contains(fromType) || Vector3Types.Contains(fromType))
                    return $"{value} != {fromType}.Zero";
            }

            if (toType == "string" && fromType != "string")
                return $"{value}.ToString()";

            if (PrimitiveTypes.Contains(fromType))
            {
                if (PrimitiveTypes.Contains(toType))
                {
                    if (MustCast(fromType, toType))
                        return $"({toType}){value}";
                    else
                        return fromType;
                }

                if (ScalarTypes.Contains(toType))
                {
                    if (MustCast(fromType, "double"))
                        return $"new {toType}((double){value})";
                    else
                        return $"new {toType}({value})";
                }

                if (Vector2Types.Contains(toType))
                {
                    if (MustCast(fromType, "double"))
                        return $"new {toType}((double){value}, 0.0)";
                    else
                        return $"new {toType}({value}, 0.0)";
                }

                if (Vector3Types.Contains(toType))
                {
                    if (MustCast(fromType, "double"))
                        return $"new {toType}((double){value}, 0.0, 0.0)";
                    else
                        return $"new {toType}({value}, 0.0, 0.0)";
                }
            }

            if (ScalarTypes.Contains(fromType))
            {
                if (PrimitiveTypes.Contains(toType))
                {
                    if (MustCast("double", toType))
                        return $"({toType}){value}.value";
                    else
                        return $"{value}.value";
                }

                if (ScalarTypes.Contains(toType))
                {
                    if (MustCast("double", toType))
                        return $"new {toType}((double){value}.value)";
                    else
                        return $"new {toType}({value}.value)";
                }

                if (Vector2Types.Contains(toType))
                {
                    if (MustCast("double", toType))
                        return $"new {toType}((double){value}.value, 0.0)";
                    else
                        return $"new {toType}({value}.value, 0.0)";
                }

                if (Vector3Types.Contains(toType))
                {
                    if (MustCast("double", toType))
                        return $"new {toType}((double){value}.value, 0.0, 0.0)";
                    else
                        return $"new {toType}({value}.value, 0.0, 0.0)";
                }
            }

            return value;
        }
    }
}