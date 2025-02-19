using CSharpGenerator;
using System.Collections.Generic;

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
                    GetField(), Empty.Get
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
                    Empty.Get
                }
            };
            Members.Elements.Add(propertySection);

            StructSection constructorSection = new()
            {
                Title = "Constructors.",
                Members = new IStructMember[]
                {
                    GetConstructor(name), Empty.Get,
                    GetConstructor("bool"), Empty.Get,
                    GetConstructor("sbyte"), Empty.Get,
                    GetConstructor("byte"), Empty.Get,
                    GetConstructor("short"), Empty.Get,
                    GetConstructor("ushort"), Empty.Get,
                    GetConstructor("int"), Empty.Get,
                    GetConstructor("uint"), Empty.Get,
                    GetConstructor("long"), Empty.Get,
                    GetConstructor("ulong"), Empty.Get,
                    GetConstructor("float"), Empty.Get,
                    GetConstructor("double"), Empty.Get,
                    GetConstructor("decimal"), Empty.Get,
                    GetConstructor("char"), Empty.Get,
                    GetConstructor("string"), Empty.Get
                }
            };
            Members.Elements.Add(constructorSection);

            StructSection castSection = new()
            {
                Title = "Casting operators.",
                Members = new IStructMember[]
                {
                    GetCastTo("bool"), Empty.Get,
                    GetCastTo("sbyte"), Empty.Get,
                    GetCastTo("byte"), Empty.Get,
                    GetCastTo("short"), Empty.Get,
                    GetCastTo("ushort"), Empty.Get,
                    GetCastTo("int"), Empty.Get,
                    GetCastTo("uint"), Empty.Get,
                    GetCastTo("long"), Empty.Get,
                    GetCastTo("ulong"), Empty.Get,
                    GetCastTo("float"), Empty.Get,
                    GetCastTo("double"), Empty.Get,
                    GetCastTo("decimal"), Empty.Get,
                    GetCastTo("char"), Empty.Get,
                    GetCastTo("string"), Empty.Get,
                    GetCastFrom("bool"), Empty.Get,
                    GetCastFrom("sbyte"), Empty.Get,
                    GetCastFrom("byte"), Empty.Get,
                    GetCastFrom("short"), Empty.Get,
                    GetCastFrom("ushort"), Empty.Get,
                    GetCastFrom("int"), Empty.Get,
                    GetCastFrom("uint"), Empty.Get,
                    GetCastFrom("long"), Empty.Get,
                    GetCastFrom("ulong"), Empty.Get,
                    GetCastFrom("float"), Empty.Get,
                    GetCastFrom("double"), Empty.Get,
                    GetCastFrom("decimal"), Empty.Get,
                    GetCastFrom("char"), Empty.Get,
                    GetCastFrom("string"), Empty.Get
                }
            };
            Members.Elements.Add(castSection);

            StructSection compareSection = new()
            {
                Title = "Casting operators.",
                Members = new IStructMember[]
                {
                    GetComparison(ComparisonOperatorID.Equal), Empty.Get,
                    GetComparison(ComparisonOperatorID.NotEqual), Empty.Get,
                    GetComparison(ComparisonOperatorID.Less), Empty.Get,
                    GetComparison(ComparisonOperatorID.Greater), Empty.Get,
                    GetComparison(ComparisonOperatorID.LessOrEqual), Empty.Get,
                    GetComparison(ComparisonOperatorID.GreaterOrEqual), Empty.Get
                }
            };
            Members.Elements.Add(compareSection);

            StructSection methodSection = new()
            {
                Title = "Public methods.",
                Members = new IStructMember[]
                {
                    GetToString(), Empty.Get,
                    GetEquals(), Empty.Get,
                    GetEquals2(), Empty.Get,
                    GetHashCode(), Empty.Get,
                    GetCompare(), Empty.Get,
                    GetAbs(true), Empty.Get,
                    GetAbs(false), Empty.Get,
                    GetSign(true), Empty.Get,
                    GetSign(false), Empty.Get,
                    GetTruncate(true), Empty.Get,
                    GetTruncate(false), Empty.Get,
                    GetFrac(true), Empty.Get,
                    GetFrac(false)
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
                Modifier = FieldModifierID.Readonly,
                Type = "double",
                Name = "value"
            };
        }

        public Property GetProperty(string name, string value, string summary)
        {
            return new Property()
            {
                Summary = summary,
                Modifier = PropertyModifierID.Static,
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

            return new Constructor()
            {
                Summary = summary,
                TypeName = Name,
                Parameters = new Parameter(type, "value"),
                Implementation = $"this.value = {Types.Convert("value", type, "double")};"
            };
        }

        public CastingOperator GetCastTo(string type)
        {
            return new CastingOperator()
            {
                Summary = $"Convert this {LowercaseName} quantity to {Types.Adjectives[type]} {type} object.",
                Modifier = CastingModifierID.Implicit,
                ReturnType = type,
                Operand = new Parameter(Name, "value"),
                Implementation = $"return {Types.Convert("value", Name, type)};"
            };
        }

        public CastingOperator GetCastFrom(string type)
        {
            return new CastingOperator()
            {
                Summary = $"Convert {Types.Adjectives[type]} {type} object to a {LowercaseName} quantity.",
                Modifier = CastingModifierID.Implicit,
                ReturnType = Name,
                Operand = new Parameter(type, "value"),
                Implementation = $"return {Types.Convert("value", type, Name)};"
            };
        }

        public ComparisonOperator GetComparison(ComparisonOperatorID @operator)
        {
            string adj = Types.Adjectives[Name];
            string summary = $"Check if {adj} {LowercaseName} quantity is numerically equal to another one.";
            if (@operator == ComparisonOperatorID.NotEqual)
                summary = summary.Replace("numerically equal", "NOT numerically equal");
            else if (@operator == ComparisonOperatorID.Less)
                summary = summary.Replace("equal to", "smaller than");
            else if (@operator == ComparisonOperatorID.Greater)
                summary = summary.Replace("equal to", "greater than");
            else if (@operator == ComparisonOperatorID.LessOrEqual)
                summary = summary.Replace("equal to", "smaller than or equal to");
            else if (@operator == ComparisonOperatorID.GreaterOrEqual)
                summary = summary.Replace("equal to", "greater than or equal than");

            ComparisonOperatorSymbol symbol = @operator;

            return new ComparisonOperator()
            {
                Summary = summary,
                ReturnType = "bool",
                Operator = @operator,
                Operand1 = new Parameter(Name, "a"),
                Operand2 = new Parameter(Name, "b"),
                Implementation = $"return {Types.Convert("a", Name, "double")} {symbol.Generate()} {Types.Convert("b", Name, "double")};"
            };
        }

        public Method GetToString()
        {
            return new Method()
            {
                Summary = $"Convert this {LowercaseName} quantity to a string.",
                Name = "ToString",
                Modifiers = MethodModifierID.OverrideReadonly,
                ReturnType = "string",
                Implementation = "return value.ToString();",
            };
        }

        public Method GetEquals()
        {
            return new Method()
            {
                Summary = $"Check if this {LowercaseName} quantity is equal to another object.",
                Modifiers = MethodModifierID.OverrideReadonly,
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
                Modifiers = MethodModifierID.Readonly,
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
                Modifiers = MethodModifierID.OverrideReadonly,
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

        public Method GetSign(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Sign(value);";
            if (@static)
                implementation = "return value.Sign();";

            return new Method()
            {
                Summary = $"Get the mathematical sign of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = "int",
                Name = "Sign",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method GetAbs(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Abs(value);";
            if (@static)
                implementation = "return value.Abs();";

            return new Method()
            {
                Summary = $"Get the absolute value of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Abs",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method GetTruncate(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Truncate(value);";
            if (@static)
                implementation = "return value.Truncate();";

            return new Method()
            {
                Summary = $"Get the integral part of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Truncate",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method GetFrac(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = $"return new {Name}(((decimal)value) % 1m);";
            if (@static)
                implementation = "return value.Frac();";

            return new Method()
            {
                Summary = $"Get the fractional part of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Frac",
                Parameters = parameters,
                Implementation = implementation
            };
        }
    }
}