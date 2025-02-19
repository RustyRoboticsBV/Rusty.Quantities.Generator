using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CSharpGenerator;

namespace Rusty.Quantities.Generator
{
    public static class Types
    {
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

                if (ScalarTypes.Contains(fromType))
                    return $"{value} != {fromType}.Zero";

                if (Vector2Types.Contains(fromType))
                    return $"{value} != {fromType}.Zero";

                if (Vector3Types.Contains(fromType))
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
    }

    public class Quantity : Struct
    {
        /* Public properties. */
        public string LowercaseName => Name.ToLower();

        /* Constructors. */
        public Quantity(string name, string summary) : base()
        {
            Summary = summary;
            Attributes = "Serializable";
            Modifier = StructModifierID.Readonly;
            Name = name;
            Inheritance = $"IEquatable<{Name}>, IComparable<{Name}>";

            StructSection fieldSection = new()
            {
                Title = "Fields.",
                Members = new IStructMember[]
                {
                    GetField(), new Empty()
                }
            };
            Members.Elements.Add(fieldSection);

            StructSection propertySection = new()
            {
                Title = "Public properties.",
                Members = new IStructMember[]
                {
                    GetProperty("Zero", Types.Convert("0.0", "double", Name), $"A {LowercaseName} object with the value 0."),
                    GetProperty("One", Types.Convert("1.0", "double", Name), $"A {LowercaseName} object with the value 1."),
                    GetProperty("Pi", Types.Convert("Math.PI", "double", Name), $"A {LowercaseName} object with the value π."),
                    GetProperty("TwoPi", Types.Convert("2.0 * Math.PI", "double", Name), $"A {LowercaseName} object with the value 2π."),
                    new Empty()
                }
            };
            Members.Elements.Add(propertySection);

            StructSection constructorSection = new()
            {
                Title = "Constructors.",
                Members = new IStructMember[]
                {
                    GetConstructor(name), new Empty(),
                    GetConstructor("bool"), new Empty(),
                    GetConstructor("sbyte"), new Empty(),
                    GetConstructor("byte"), new Empty(),
                    GetConstructor("short"), new Empty(),
                    GetConstructor("ushort"), new Empty(),
                    GetConstructor("int"), new Empty(),
                    GetConstructor("uint"), new Empty(),
                    GetConstructor("long"), new Empty(),
                    GetConstructor("ulong"), new Empty(),
                    GetConstructor("float"), new Empty(),
                    GetConstructor("double"), new Empty(),
                    GetConstructor("decimal"), new Empty(),
                    GetConstructor("char"), new Empty(),
                    GetConstructor("string"), new Empty()
                }
            };
            Members.Elements.Add(constructorSection);

            StructSection castSection = new()
            {
                Title = "Casting operators.",
                Members = new IStructMember[]
                {
                    GetCastTo("bool"), new Empty(),
                    GetCastTo("sbyte"), new Empty(),
                    GetCastTo("byte"), new Empty(),
                    GetCastTo("short"), new Empty(),
                    GetCastTo("ushort"), new Empty(),
                    GetCastTo("int"), new Empty(),
                    GetCastTo("uint"), new Empty(),
                    GetCastTo("long"), new Empty(),
                    GetCastTo("ulong"), new Empty(),
                    GetCastTo("float"), new Empty(),
                    GetCastTo("double"), new Empty(),
                    GetCastTo("decimal"), new Empty(),
                    GetCastTo("char"), new Empty(),
                    GetCastTo("string"), new Empty()
                }
            };
            Members.Elements.Add(castSection);

            StructSection methodSection = new()
            {
                Title = "Public methods.",
                Members = new IStructMember[]
                {
                    GetToString()
                }
            };
            Members.Elements.Add(methodSection);
        }

        /* Public methods. */
        public Field GetField()
        {
            return new Field()
            {
                Summary = $"The internal value of this {LowercaseName} quantity.",
#if UNITY_5_3_OR_NEWER
                    Attributes = "SerializeField",
#endif
                Readonly = true,
                Type = "double",
                Name = "value"
            };
        }

        public Property GetProperty(string name, string value, string summary)
        {
            return new Property()
            {
                Summary = summary,
                Type = Name,
                Name = name,
                Getter = (Code)$"=> {value};",
                Setter = null,
            };
        }

        public Constructor GetConstructor(string type)
        {
            string implementation = "";

            if (type == "string")
                implementation = $"if (double.TryParse(value, out double result))\n    this.value = result;";
            else
            {
                implementation = "value";
                if (Types.Byte16Types.Contains(type))
                    implementation = "(double)" + implementation;
                else if (Types.ScalarTypes.Contains(type))
                    implementation += ".value";
                else if (type == "bool")
                    implementation += " ? 1.0 : 0.0";
                implementation = $"this.value = {implementation};";
            }

            return new Constructor()
            {
                Summary = $"Create a new {LowercaseName} quantity from {Types.Adjectives[type]} {type} object.",
                TypeName = Name,
                Parameters = new Parameter(type, "value"),
                Implementation = implementation
            };
        }

        public CastingOperator GetCastTo(string type)
        {
            bool mustCast = Types.MustCast("double", type);

            string implementation = $"return {Types.Convert("value", Name, type)};";

            return new CastingOperator()
            {
                Summary = $"Convert this {LowercaseName} quantity to {Types.Adjectives[type]} {type} object.",
                Modifier = mustCast ? CastingModifierID.Explicit : CastingModifierID.Implicit,
                ReturnType = type,
                Operand = new Parameter(Name, "value"),
                Implementation = implementation
            };
        }

        public Method GetToString()
        {
            return new Method()
            {
                Summary = $"Convert this {LowercaseName} quantity to a string.",
                Name = "ToString",
                Modifiers = MethodModifierID.Override,
                ReturnType = "string",
                Implementation = "return value.ToString();",
            };
        }
    }
}