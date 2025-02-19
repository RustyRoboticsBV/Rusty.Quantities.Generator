using Rusty.CSharpGenerator;

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
                    Field("value"), Empty.Get
                }
            };
            Members.Elements.Add(fieldSection);

            StructSection propertySection = new()
            {
                Title = "Public properties.",
                Members = new IStructMember[]
                {
                    Property("Zero", Types.Convert("0.0", "double", Name), $"A {LowercaseName} object with the value 0."),
                    Property("One", Types.Convert("1.0", "double", Name), $"A {LowercaseName} object with the value 1."),
                    Property("Pi", Types.Convert("Math.PI", "double", Name), $"A {LowercaseName} object with the value π."),
                    Property("TwoPi", Types.Convert("2.0 * Math.PI", "double", Name), $"A {LowercaseName} object with the value 2π."),
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
                    Constructor("string"), Empty.Get
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
                    DecrementOperator(), Empty.Get,
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
                    Frac(false)
                }
            };
            Members.Elements.Add(methodSection);
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

        public Property Property(string name, string value, string summary)
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


        public Constructor Constructor(string type)
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
                Summary = $"Get the mathematical sign of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
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
                Summary = $"Get the absolute value of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
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
                Summary = $"Get the integral part of {(@static ? Types.Adjectives[Name] : "this")} {LowercaseName} quantity.",
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