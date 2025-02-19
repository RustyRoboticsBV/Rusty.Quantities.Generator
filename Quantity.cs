using CSharpGenerator;

namespace Rusty.Quantities.Generator
{
    /// <summary>
    /// A quantity struct.
    /// </summary>
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
                    GetToString(), new Empty(),
                    GetEquals(), new Empty(),
                    GetEquals2(), new Empty(),
                    GetHashCode(), new Empty(),
                    GetCompare()
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
            string summary = $"Create a new {LowercaseName} quantity from {Types.Adjectives[type]} {type} object.";
            if (type == Name)
                summary = $"Create a new {LowercaseName} quantity from another {LowercaseName} object.";

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
                Summary = summary,
                TypeName = Name,
                Parameters = new Parameter(type, "value"),
                Implementation = implementation
            };
        }

        public CastingOperator GetCastTo(string type)
        {
            bool mustCast = Types.MustCast("double", type);

            bool @implicit = !mustCast || type == "float" || type == "string";
            string implementation = $"return {Types.Convert("value", Name, type)};";

            return new CastingOperator()
            {
                Summary = $"Convert this {LowercaseName} quantity to {Types.Adjectives[type]} {type} object.",
                Modifier = @implicit ? CastingModifierID.Implicit : CastingModifierID.Explicit,
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

        public Method GetEquals()
        {
            return new Method()
            {
                Summary = $"Check if this {LowercaseName} quantity is equal to another object.",
                Modifiers = MethodModifierID.Override,
                ReturnType = "bool",
                Name = "Equals",
                Parameters = new Parameter("object", "obj"),
                Implementation = $"return obj is {Name} value && Equals(value);"
            };
        }

        public Method GetEquals2()
        {
            return new Method()
            {
                Summary = $"Check if this {LowercaseName} quantity is equal to another one.",
                ReturnType = "bool",
                Name = "Equals",
                Parameters = new Parameter(Name, "value"),
                Implementation = $"return this.value == value.value;"
            };
        }

        public new Method GetHashCode()
        {
            return new Method()
            {
                Summary = $"Get a hash code for this {LowercaseName} quantity.",
                Modifiers = MethodModifierID.Override,
                ReturnType = "int",
                Name = "GetHashCode",
                Implementation = $"return value.GetHashCode();"
            };
        }

        public Method GetCompare()
        {
            string implementation =
                $"if (this > other)" +
                $"\n    return 1;" +
                $"\nelse if (this < other)" +
                $"\n    return -1;" +
                $"\nelse" +
                $"\n    return 0;";

            return new Method()
            {
                Summary = $"Compare this {LowercaseName} quantity to another one. Returns -1 if it is smaller, 0 if it is "
                    + "equal, and 1 if it is larger.",
                Modifiers = MethodModifierID.Readonly,
                Name = "CompareTo",
                ReturnType = "int",
                Parameters = new Parameter(Name, "other"),
                Implementation = implementation
            };
        }
    }
}