using Rusty.CSharpGenerator;
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
            Inheritance = $"IScalarQuantity, IEquatable<{Name}>, IComparable<{Name}>";

            StructSection fieldSection = new()
            {
                Title = "Fields.",
                Members = new IStructMember[]
                {
                    Field("value"), Empty.Get
                }
            };
            Members.Elements.Add(fieldSection);

            StructSection propertySection = new()
            {
                Title = "Public properties.",
                Members = new IStructMember[]
                {
                    StaticProperty("Zero", Types.Convert("0.0", "double", Name), $"A {LowercaseName} object with the value 0."),
                    StaticProperty("One", Types.Convert("1.0", "double", Name), $"A {LowercaseName} object with the value 1."),
                    StaticProperty("Pi", Types.Convert("Math.PI", "double", Name), $"A {LowercaseName} object with the value π."),
                    StaticProperty("TwoPi", Types.Convert("2.0 * Math.PI", "double", Name), $"A {LowercaseName} object with the value 2π."),
                    Empty.Get,
                    ValueProperty(),
                    Empty.Get
                }
            };
            Members.Elements.Add(propertySection);

            StructSection constructorSection = new()
            {
                Title = "Constructors.",
                Members = new IStructMember[]
                {
                    Constructor(name), Empty.Get,
                    Constructor("IScalarQuantity"), Empty.Get,
                    Constructor("bool"), Empty.Get,
                    Constructor("sbyte"), Empty.Get,
                    Constructor("byte"), Empty.Get,
                    Constructor("short"), Empty.Get,
                    Constructor("ushort"), Empty.Get,
                    Constructor("int"), Empty.Get,
                    Constructor("uint"), Empty.Get,
                    Constructor("long"), Empty.Get,
                    Constructor("ulong"), Empty.Get,
                    Constructor("float"), Empty.Get,
                    Constructor("double"), Empty.Get,
                    Constructor("decimal"), Empty.Get,
                    Constructor("char"), Empty.Get,
                    Constructor("string"), Empty.Get,
                    ObjConstructor(), Empty.Get
                }
            };
            Members.Elements.Add(constructorSection);

            StructSection castSection = new()
            {
                Title = "Casting operators.",
                Members = new IStructMember[]
                {
                    CastToOperator("bool"), Empty.Get,
                    CastToOperator("sbyte"), Empty.Get,
                    CastToOperator("byte"), Empty.Get,
                    CastToOperator("short"), Empty.Get,
                    CastToOperator("ushort"), Empty.Get,
                    CastToOperator("int"), Empty.Get,
                    CastToOperator("uint"), Empty.Get,
                    CastToOperator("long"), Empty.Get,
                    CastToOperator("ulong"), Empty.Get,
                    CastToOperator("float"), Empty.Get,
                    CastToOperator("double"), Empty.Get,
                    CastToOperator("decimal"), Empty.Get,
                    CastToOperator("char"), Empty.Get,
                    CastToOperator("string"), Empty.Get,
                    CastFromOperator("bool"), Empty.Get,
                    CastFromOperator("sbyte"), Empty.Get,
                    CastFromOperator("byte"), Empty.Get,
                    CastFromOperator("short"), Empty.Get,
                    CastFromOperator("ushort"), Empty.Get,
                    CastFromOperator("int"), Empty.Get,
                    CastFromOperator("uint"), Empty.Get,
                    CastFromOperator("long"), Empty.Get,
                    CastFromOperator("ulong"), Empty.Get,
                    CastFromOperator("float"), Empty.Get,
                    CastFromOperator("double"), Empty.Get,
                    CastFromOperator("decimal"), Empty.Get,
                    CastFromOperator("char"), Empty.Get,
                    CastFromOperator("string"), Empty.Get
                }
            };
            Members.Elements.Add(castSection);

            StructSection compareSection = new()
            {
                Title = "Casting operators.",
                Members = new IStructMember[]
                {
                    ComparisonOperator(ComparisonOperatorID.Equal), Empty.Get,
                    ComparisonOperator(ComparisonOperatorID.NotEqual), Empty.Get,
                    ComparisonOperator(ComparisonOperatorID.Less), Empty.Get,
                    ComparisonOperator(ComparisonOperatorID.Greater), Empty.Get,
                    ComparisonOperator(ComparisonOperatorID.LessOrEqual), Empty.Get,
                    ComparisonOperator(ComparisonOperatorID.GreaterOrEqual), Empty.Get
                }
            };
            Members.Elements.Add(compareSection);

            StructSection mathOperators = new()
            {
                Title = "Math operators.",
                Members = new IStructMember[]
                {
                    BinaryMathOperator(BinaryMathOperatorID.Add), Empty.Get,
                    BinaryMathOperator(BinaryMathOperatorID.Subtract), Empty.Get,
                    BinaryMathOperator(BinaryMathOperatorID.Multiply), Empty.Get,
                    BinaryMathOperator(BinaryMathOperatorID.Divide), Empty.Get,
                    BinaryMathOperator(BinaryMathOperatorID.Modulo), Empty.Get,
                    UnaryMinusOperator(), Empty.Get,
                    IncrementOperator(), Empty.Get,
                    DecrementOperator(), Empty.Get
                }
            };
            Members.Elements.Add(mathOperators);

            StructSection methodSection = new()
            {
                Title = "Public methods.",
                Members = new IStructMember[]
                {
                    ToString(), Empty.Get,
                    Equals(), Empty.Get,
                    Equals2(), Empty.Get,
                    GetHashCode(), Empty.Get,
                    CompareMethod(), Empty.Get,

                    Abs(true), Empty.Get,
                    Abs(false), Empty.Get,
                    Sign(true), Empty.Get,
                    Sign(false), Empty.Get,
                    Truncate(true), Empty.Get,
                    Truncate(false), Empty.Get,
                    Frac(true), Empty.Get,
                    Frac(false), Empty.Get,
                    Dist(true), Empty.Get,
                    Dist(false), Empty.Get,

                    Pow(true), Empty.Get,
                    Pow(false), Empty.Get,
                    Sqrt(true), Empty.Get,
                    Sqrt(false), Empty.Get,

                    Min(true), Empty.Get,
                    Min(false), Empty.Get,
                    Max(true), Empty.Get,
                    Max(false), Empty.Get,
                    Clamp(true), Empty.Get,
                    Clamp(false), Empty.Get,

                    Round(true), Empty.Get,
                    Round(false), Empty.Get,
                    Floor(true), Empty.Get,
                    Floor(false), Empty.Get,
                    Ceil(true), Empty.Get,
                    Ceil(false), Empty.Get,

                    Sin(true), Empty.Get,
                    Sin(false), Empty.Get,
                    Cos(true), Empty.Get,
                    Cos(false), Empty.Get,
                    Tan(true), Empty.Get,
                    Tan(false), Empty.Get,

                    Step(true), Empty.Get,
                    Step(false), Empty.Get,
                    Lerp(), Empty.Get
                }
            };
            Method[] formulaMethods = GetFormulaMethods();
            foreach (Method method in formulaMethods)
            {
                methodSection.Members.Elements.Add(method);
                methodSection.Members.Elements.Add(Empty.Get);
            }
            Members.Elements.Add(methodSection);

            StructSection privateMethods = new()
            {
                Title = "Private methods.",
                Members = Pow2()
            };
            Members.Elements.Add(privateMethods);
        }

        /* Public methods. */
        public Field Field(string name)
        {
            return new Field()
            {
                Summary = $"The internal value of this {LowercaseName} quantity.",
#if UNITY_5_3_OR_NEWER
                    Attributes = "SerializeField",
#endif
                Modifier = FieldModifierID.Readonly,
                Type = "double",
                Name = name
            };
        }

        public Property StaticProperty(string name, string value, string summary)
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

        public Property ValueProperty()
        {
            return new Property()
            {
                Summary = $"The internal value of this {LowercaseName} quantity.",
                Modifier = PropertyModifierID.Readonly,
                Type = "double",
                Name = "Value",
                Getter = "value",
                Setter = null
            };
        }


        public Constructor Constructor(string type)
        {
            string typeName = type;
            if (typeName == "IScalarQuantity")
                typeName = "scalar quantity";

            string summary = $"Create a new {LowercaseName} quantity from {Types.Adjectives[type]} {typeName} object.";
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

        public string GetObjCase(string type, string name)
        {
            if (type == "default")
            {
                return $"\n    default:"
                     + $"\n        this = new {Name}(0.0);"
                      + "\n        break;";
            }

            if (type == "IScalarQuantity")
            {
                return $"\n    case {type} {name}:"
                     + $"\n        this = new {Name}({name});"
                      + "\n        break;";
            }

            return $"\n    case {type} {name}:"
                 + $"\n        this = {name};"
                  + "\n        break;";
        }

        public Constructor ObjConstructor()
        {
            string implementation =
                "switch (value)"
                + "\n{"
                + GetObjCase("IScalarQuantity", "q")
                + GetObjCase("bool", "b")
                + GetObjCase("sbyte", "i8")
                + GetObjCase("short", "i16")
                + GetObjCase("int", "i32")
                + GetObjCase("long", "i64")
                + GetObjCase("byte", "u8")
                + GetObjCase("ushort", "u16")
                + GetObjCase("uint", "u32")
                + GetObjCase("ulong", "u64")
                + GetObjCase("float", "f32")
                + GetObjCase("double", "f64")
                + GetObjCase("decimal", "f128")
                + GetObjCase("char", "c")
                + GetObjCase("string", "s")
                + GetObjCase("default", "")

                + "\n}";

            return new Constructor()
            {
                Summary = $"Create a new {LowercaseName} quantity from a generic object. Results in the value 0 if the object cannot be converted.",
                TypeName = Name,
                Parameters = new Parameter("object", "value"),
                Implementation = implementation
            };
        }


        public CastingOperator CastToOperator(string type)
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

        public CastingOperator CastFromOperator(string type)
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

        public ComparisonOperator ComparisonOperator(ComparisonOperatorID id)
        {
            string adj = Types.Adjectives[Name];
            string summary = $"Check if {adj} {LowercaseName} quantity is numerically equal to another one.";
            if (id == ComparisonOperatorID.NotEqual)
                summary = summary.Replace("numerically equal", "NOT numerically equal");
            else if (id == ComparisonOperatorID.Less)
                summary = summary.Replace("equal to", "smaller than");
            else if (id == ComparisonOperatorID.Greater)
                summary = summary.Replace("equal to", "greater than");
            else if (id == ComparisonOperatorID.LessOrEqual)
                summary = summary.Replace("equal to", "smaller than or equal to");
            else if (id == ComparisonOperatorID.GreaterOrEqual)
                summary = summary.Replace("equal to", "greater than or equal than");

            ComparisonOperatorSymbol symbol = id;

            return new ComparisonOperator()
            {
                Summary = summary,
                ReturnType = "bool",
                Operator = id,
                Operand1 = new Parameter(Name, "a"),
                Operand2 = new Parameter(Name, "b"),
                Implementation = $"return {Types.Convert("a", Name, "double")} {symbol.Generate()} {Types.Convert("b", Name, "double")};"
            };
        }

        public BinaryMathOperator BinaryMathOperator(BinaryMathOperatorID id)
        {
            string adj = Types.Adjectives[Name];
            string summary = $"Return the result of adding two {LowercaseName} quantities.";
            if (id == BinaryMathOperatorID.Subtract)
                summary = $"Return the result of subtracting {adj} {LowercaseName} quantity from another.";
            if (id == BinaryMathOperatorID.Multiply)
                summary = summary.Replace("adding", "multiplying");
            if (id == BinaryMathOperatorID.Divide)
                summary = $"Return the result of dividing {adj} {LowercaseName} quantity by another.";
            if (id == BinaryMathOperatorID.Modulo)
                summary = $"Return the remainder of dividing {adj} {LowercaseName} quantity by another.";

            BinaryMathOperatorSymbol symbol = id;

            return new BinaryMathOperator()
            {
                Summary = summary,
                ReturnType = Name,
                Operator = id,
                Operand1 = new Parameter(Name, "a"),
                Operand2 = new Parameter(Name, "b"),
                Implementation = $"return new {Name}({Types.Convert("a", Name, "double")} {symbol.Generate()} {Types.Convert("b", Name, "double")});"
            };
        }

        public UnaryMathOperator UnaryMinusOperator()
        {
            return new UnaryMathOperator()
            {
                Summary = $"Return this {LowercaseName} quantity made negative.",
                ReturnType = Name,
                Operator = UnaryMathOperatorID.Negative,
                Operand = new Parameter(Name, "value"),
                Implementation = $"return new {Name}(-{Types.Convert("value", Name, "double")});"
            };
        }

        public UnaryMathOperator IncrementOperator()
        {
            return new UnaryMathOperator()
            {
                Summary = $"Return this {LowercaseName} quantity incremented with 1.",
                ReturnType = Name,
                Operator = UnaryMathOperatorID.Increment,
                Operand = new Parameter(Name, "value"),
                Implementation = $"return new {Name}({Types.Convert("value", Name, "double")} + 1.0);"
            };
        }

        public UnaryMathOperator DecrementOperator()
        {
            return new UnaryMathOperator()
            {
                Summary = $"Return this {LowercaseName} quantity decremented with 1.",
                ReturnType = Name,
                Operator = UnaryMathOperatorID.Decrement,
                Operand = new Parameter(Name, "value"),
                Implementation = $"return new {Name}({Types.Convert("value", Name, "double")} - 1.0);"
            };
        }


        public new Method ToString()
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

        public Method Equals()
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

        public Method Equals2()
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

        public Method CompareMethod()
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


        public Method Sign(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Sign(value);";
            if (@static)
                implementation = "return value.Sign();";

            return new Method()
            {
                Summary = $"Return the mathematical sign of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = "int",
                Name = "Sign",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Abs(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Abs(value);";
            if (@static)
                implementation = "return value.Abs();";

            return new Method()
            {
                Summary = $"Return the absolute value of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Abs",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Truncate(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Truncate(value);";
            if (@static)
                implementation = "return value.Truncate();";

            return new Method()
            {
                Summary = $"Return the integral part of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Truncate",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Frac(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = $"return new {Name}(((decimal)value) % 1m);";
            if (@static)
                implementation = "return value.Frac();";

            return new Method()
            {
                Summary = $"Return the fractional part of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Frac",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Dist(bool @static)
        {
            string summary = $"Return the distance between this {LowercaseName} quantity and another one.";
            if (@static)
                summary = $"Return the distance between two {LowercaseName} quantities.";

            ParameterList parameters = new Parameter(Name, "other");
            if (@static)
            {
                parameters.Elements.Insert(0, new Parameter(Name, "a"));
                parameters.Elements[1].Name = "b";
            }

            string implementation = $"return new {Name}(this > other ? this - other : other - this);";
            if (@static)
                implementation = "return a.Dist(b);";

            return new Method()
            {
                Summary = summary,
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Dist",
                Parameters = parameters,
                Implementation = implementation
            };
        }


        public Method Pow(bool @static)
        {
            ParameterList parameters = new Parameter(Name, "exponent");
            if (@static)
                parameters.Elements.Insert(0, new Parameter(Name, "value"));

            string implementation = "return Math.Pow(value, exponent);";
            if (@static)
                implementation = "return value.Pow(exponent);";

            return new Method()
            {
                Summary = $"Return the result of raising {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity to some exponent.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Pow",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Sqrt(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters = new Parameter(Name, "value");

            string implementation = "return Math.Sqrt(value);";
            if (@static)
                implementation = "return value.Sqrt();";

            return new Method()
            {
                Summary = $"Return the square root of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Sqrt",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Pow2()
        {
            return new Method()
            {
                Access = AccessID.Private,
                Modifiers = MethodModifierID.Static,
                ReturnType = Name,
                Name = "Pow2",
                Parameters = new Parameter("double", "value"),
                Implementation = "return value * value;"
            };
        }


        public Method Min(bool @static)
        {
            string summary = $"Compare this {LowercaseName} quantity to another one and return the smallest one.";
            if (@static)
                summary = $"Return the smallest of two {LowercaseName} quantities.";

            ParameterList parameters = new Parameter(Name, "other");
            if (@static)
            {
                parameters.Elements.Insert(0, new Parameter(Name, "a"));
                parameters.Elements[1].Name = "b";
            }

            string implementation = "return Math.Min(value, other.value);";
            if (@static)
                implementation = "return a.Min(b);";

            return new Method()
            {
                Summary = summary,
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Min",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Max(bool @static)
        {
            string summary = $"Compare this {LowercaseName} quantity to another one and return the largest one.";
            if (@static)
                summary = $"Return the largest of two {LowercaseName} quantities.";

            ParameterList parameters = new Parameter(Name, "other");
            if (@static)
            {
                parameters.Elements.Insert(0, new Parameter(Name, "a"));
                parameters.Elements[1].Name = "b";
            }

            string implementation = "return Math.Max(value, other.value);";
            if (@static)
                implementation = "return a.Max(b);";

            return new Method()
            {
                Summary = summary,
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Max",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Clamp(bool @static)
        {
            string summary = $"Force this {LowercaseName} quantity into some numerical range.";
            if (@static)
                summary = $"Force a {LowercaseName} quantity into some numerical range.";

            ParameterList parameters = new();
            parameters.Elements.Add(new Parameter(Name, "min"));
            parameters.Elements.Add(new Parameter(Name, "max"));
            if (@static)
                parameters.Elements.Insert(0, new Parameter(Name, "value"));

            string implementation =
                "if (value < min)" +
                "\n    return min;" +
                "\nelse if (value > max)" +
                "\n    return max;" +
                "\nelse" +
                "\n    return value;";
            if (@static)
                implementation = "return value.Clamp(min, max);";

            return new Method()
            {
                Summary = summary,
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Clamp",
                Parameters = parameters,
                Implementation = implementation
            };
        }


        public Method Round(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters = new Parameter(Name, "value");

            string implementation = "return Math.Round(value);";
            if (@static)
                implementation = "return value.Round();";

            return new Method()
            {
                Summary = $"Round {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity and return the result.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Round",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Floor(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters = new Parameter(Name, "value");

            string implementation = "return Math.Floor(value);";
            if (@static)
                implementation = "return value.Floor();";

            return new Method()
            {
                Summary = $"Round {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity down to the nearest integer and return the result.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Floor",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Ceil(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters = new Parameter(Name, "value");

            string implementation = "return Math.Ceiling(value);";
            if (@static)
                implementation = "return value.Ceil();";

            return new Method()
            {
                Summary = $"Round {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity up to the nearest integer and return the result.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Ceil",
                Parameters = parameters,
                Implementation = implementation
            };
        }


        public Method Sin(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Sin(value);";
            if (@static)
                implementation = "return value.Sin();";

            return new Method()
            {
                Summary = $"Return the sine of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Sin",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Cos(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Cos(value);";
            if (@static)
                implementation = "return value.Cos();";

            return new Method()
            {
                Summary = $"Return the cosine of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Cos",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Tan(bool @static)
        {
            ParameterList parameters = new();
            if (@static)
                parameters.Elements.Add(new Parameter(Name, "value"));

            string implementation = "return Math.Tan(value);";
            if (@static)
                implementation = "return value.Tan();";

            return new Method()
            {
                Summary = $"Return the tangent of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Tan",
                Parameters = parameters,
                Implementation = implementation
            };
        }


        public Method Step(bool @static)
        {
            ParameterList parameters = new();
            parameters.Elements.Add(new Parameter(Name, "target"));
            parameters.Elements.Add(new Parameter(Name, "stepSize"));
            if (@static)
            {
                parameters.Elements.Insert(0, new Parameter(Name, "from"));
                parameters.Elements[1].Name = "to";
            }

            string implementation =
                "if (this < target)" +
                "\n    return Min(this + stepSize.Abs(), target);" +
                "\nelse if (this > target)" +
                "\n    return Max(this - stepSize.Abs(), target);" +
                "\nelse" +
                "\n    return target;";
            if (@static)
                implementation = "return from.Step(to, stepSize);";

            return new Method()
            {
                Summary = $"Return the result of stepping {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity towards a target value, using some step size.",
                Modifiers = @static ? MethodModifierID.Static : MethodModifierID.Readonly,
                ReturnType = Name,
                Name = "Step",
                Parameters = parameters,
                Implementation = implementation
            };
        }

        public Method Lerp()
        {
            ParameterList parameters = new();
            parameters.Elements.Add(new Parameter(Name, "a"));
            parameters.Elements.Add(new Parameter(Name, "b"));
            parameters.Elements.Add(new Parameter("double", "factor"));

            string implementation = "return a + (b - a) * Math.Min(Math.Max(factor, 0.0), 1.0);";

            return new Method()
            {
                Summary = $"Return the result of linearly-interpolating between two {LowercaseName} quantities, using some interpolation factor between 0 and 1.",
                Modifiers = MethodModifierID.Static,
                ReturnType = Name,
                Name = "Lerp",
                Parameters = parameters,
                Implementation = implementation
            };
        }


        public Method[] GetFormulaMethods()
        {
            List<Method> result = new();
            foreach (Formula formula in Formulas.All)
            {
                foreach (Equation equation in formula.Variants)
                {
                    if (equation.Result.Type == Name)
                        result.Add(new FormulaMethod(equation, Name));
                }
            }
            return result.ToArray();
        }
    }
}