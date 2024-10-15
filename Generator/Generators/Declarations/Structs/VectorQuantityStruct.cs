namespace Generators
{
    /// <summary>
    /// A vector struct generator.
    /// </summary>
    public abstract class VectorQuantityStruct : Struct
    {
        /* Public properties. */
        public new VectorQuantityType Type => base.Type as VectorQuantityType;
        public ScalarQuantityType ScalarType => Type.ScalarType as ScalarQuantityType;

        /* Constructors. */
        public VectorQuantityStruct(VectorQuantityType type, string summary) : base(type, summary)
        {
            // Fields.
            Fields.Add(new Field(Numerics.Core, "x", null));
            Fields.Add(new Field(Numerics.Core, "y", null));
            Fields.Add(new Field(Numerics.Core, "z", null));

            // Properties.
            Properties.Add(new Property(true, type, "Zero", $"new {Name}({Numerics.Zero}, {Numerics.Zero}, {Numerics.Zero})", $"A {Name.ToLower()} object where all components have the value 0."));
            Properties.Add(new Property(true, type, "One", $"new {Name}({Numerics.One}, {Numerics.One} ,{Numerics.One})", $"A {Name.ToLower()} object where all components have the value 1."));
            Properties.Add(new Property(true, type, "Pi", $"{Numerics.Pi} * One", $"A {Name.ToLower()} object where all components have the value π."));
            Properties.Add(new Property(true, type, "TwoPi", $"{Numerics.TwoPi} * One", $"A {Name.ToLower()} object where all components have the value 2π."));
            Properties.Add(new Property(false, type.ScalarType, "X", $"x", $"The x component of this {Name.ToLower()} object."));
            Properties.Add(new Property(false, type.ScalarType, "Y", $"y", $"The y component of this {Name.ToLower()} object."));
            Properties.Add(new Property(false, type.ScalarType, "Z", $"z", $"The z component of this {Name.ToLower()} object."));

            // Constructors.
            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                Constructors.Add(new Vector3Constructor(Name, new ScalarNumericParameter(numeric, "x"),
                    new ScalarNumericParameter(numeric, "y"), new ScalarNumericParameter(numeric, "z")));
            }
            Constructors.Add(new Vector3Constructor(Name, new ScalarQuantityParameter(type.ScalarType as ScalarQuantityType, "x")
                , new ScalarQuantityParameter(type.ScalarType as ScalarQuantityType, "y"), new ScalarQuantityParameter(type.ScalarType as ScalarQuantityType, "z")));
            foreach (VectorNumericType numeric in Numerics.Vectors)
            {
                Constructors.Add(new Vector3Constructor(Name, new VectorNumericParameter(numeric, "value")));
            }
            Constructors.Add(new Vector3Constructor(Name, new VectorQuantityParameter(type, "value")));

            // Casting operators.
            CastingOperators.Add(new CastingOperator(true, type, new VectorNumericParameter(Numerics.Vector3, "value")));
            CastingOperators.Add(new CastingOperator(true, Numerics.Vector3, new VectorQuantityParameter(type, "value")));

            // Arithmetic operators.
            AddBinaryOperator("+", false, false);
            AddBinaryOperator("-", false, false);
            AddBinaryOperator("*", true, true);
            AddBinaryOperator("/", false, true);
            AddBinaryOperator("%", false, true);

            // Comparison operators.
            AddComparisonOperator("==");
            AddComparisonOperator("!=");

            // Methods.
            InstanceMethods.Add(new Method("public", "override readonly", Types.String, "ToString", null, "return $\"({x}, {y}, {z})\";"));
            InstanceMethods.Add(new Method("public", "override readonly", Types.Bool, "Equals", new ObjectParameter(), $"return obj is {Name} {Name.ToLower()} && Equals({Name.ToLower()});"));
            InstanceMethods.Add(new Method("public", "readonly", Types.Bool, "Equals", new VectorQuantityParameter(type, "other"), $"return this == other;"));
            InstanceMethods.Add(new Method("public", "override readonly", Numerics.Int, "GetHashCode", null, "return (x.GetHashCode() * 13 + y.GetHashCode()) * 13 + z.GetHashCode();"));
            InstanceMethods.Add(new Method("public", "readonly", Numerics.Int, "CompareTo", new VectorQuantityParameter(type, "other"), $"int myHash = GetHashCode();\nint otherHash = other.GetHashCode();\nif (myHash > otherHash)\n{Indent("return 1;")}\nelse if (myHash < otherHash)\n{Indent("return -1;")}\nelse\n{Indent("return 0;")}"));
            InstanceMethods.Space();
        }

        /* Private methods. */
        /// <summary>
        /// Add all supported variants of a binary arithmetic operator.
        /// </summary>
        private void AddBinaryOperator(string op, bool allowScalarLeft, bool allowScalarRight)
        {
            if (allowScalarLeft)
            {
                foreach (ScalarNumericType numeric in Numerics.Scalars)
                {
                    ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                        new ScalarNumericParameter(numeric, "a"),
                        new VectorQuantityParameter(Type, "b")
                    ));
                }
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new ScalarQuantityParameter(ScalarType, "a"),
                    new VectorQuantityParameter(Type, "b")
                ));
            }

            if (allowScalarRight)
            {
                foreach (ScalarNumericType numeric in Numerics.Scalars)
                {
                    ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                        new VectorQuantityParameter(Type, "a"),
                        new ScalarNumericParameter(numeric, "b")
                    ));
                }
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorQuantityParameter(Type, "a"),
                    new ScalarQuantityParameter(ScalarType, "b")
                ));
            }

            ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                new VectorQuantityParameter(Type, "a"),
                new VectorQuantityParameter(Type, "b")
            ));
        }

        /// <summary>
        /// Add all supported variants of a comparison operator.
        /// </summary>
        private void AddComparisonOperator(string name)
        {
            ComparisonOperators.Add(new ComparisonOperator(name, new VectorNumericParameter(Numerics.Vector3, "a"), new VectorQuantityParameter(Type, "b")));
            ComparisonOperators.Add(new ComparisonOperator(name, new VectorNumericParameter(Numerics.Vector3I, "a"), new VectorQuantityParameter(Type, "b")));
            ComparisonOperators.Add(new ComparisonOperator(name, new VectorQuantityParameter(Type, "a"), new VectorNumericParameter(Numerics.Vector3, "b")));
            ComparisonOperators.Add(new ComparisonOperator(name, new VectorQuantityParameter(Type, "a"), new VectorNumericParameter(Numerics.Vector3I, "b")));
            ComparisonOperators.Add(new ComparisonOperator(name, new VectorQuantityParameter(Type, "a"), new VectorQuantityParameter(Type, "b")));
        }
    }
}