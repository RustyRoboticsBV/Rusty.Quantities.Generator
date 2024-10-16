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
            if (Type.Size >= 3)
                Fields.Add(new Field(Numerics.Core, "z", null));

            // Properties.
            Properties.Add(new Property(true, type, "Zero", $"new {Name}({GetPropImpl($"{Numerics.Zero}")})", $"A {ScalarType.Name.ToLower()} vector where all components have the value 0."));
            Properties.Add(new Property(true, type, "One", $"new {Name}({GetPropImpl($"{Numerics.One}")})", $"A {ScalarType.Name.ToLower()} vector where all components have the value 1."));
            Properties.Add(new Property(true, type, "Pi", $"new {Name}({GetPropImpl($"{Numerics.Pi}")})", $"A {ScalarType.Name.ToLower()} vector where all components have the value π."));
            Properties.Add(new Property(true, type, "TwoPi", $"new {Name}({GetPropImpl($"{Numerics.TwoPi}")})", $"A {ScalarType.Name.ToLower()} vector where all components have the value 2π."));
            Properties.Add(new Property(false, type.ScalarType, "X", $"x", $"The x component of this {ScalarType.Name.ToLower()} vector."));
            Properties.Add(new Property(false, type.ScalarType, "Y", $"y", $"The y component of this {ScalarType.Name.ToLower()} vector."));
            if (Type.Size >= 3)
                Properties.Add(new Property(false, type.ScalarType, "Z", $"z", $"The z component of this {ScalarType.Name.ToLower()} vector."));

            if (type.Size >= 3)
            {
                Type type2D = Quantities.Get2D(Type);
                Properties.Add(new Property(false, type2D, "XY", $"new {type2D.Name}(x, y)", $"The (x, y) {ScalarType.Name.ToLower()} vector."));
                Properties.Add(new Property(false, type2D, "XZ", $"new {type2D.Name}(x, z)", $"The (x, z) {ScalarType.Name.ToLower()} vector."));
                Properties.Add(new Property(false, type2D, "YZ", $"new {type2D.Name}(y, z)", $"The (y, z) {ScalarType.Name.ToLower()} vector."));
            }

            // Constructors.
            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                Constructors.Add(new VectorConstructor(Name, numeric, Type.Size));
            }
            Constructors.Add(new VectorConstructor(Name, ScalarType, Type.Size));
            foreach (VectorNumericType numeric in Numerics.Vectors)
            {
                Constructors.Add(new VectorConstructor(Name, new VectorNumericParameter(numeric, "value"), Type.Size));
            }
            Constructors.Add(new VectorConstructor(Name, new VectorQuantityParameter(type, "other"), Type.Size));

            // Casting operators.
            CastingOperators.Add(new CastingOperator(Numerics.Vector2.Size <= Type.Size, type, new VectorNumericParameter(Numerics.Vector2, "value")));
            CastingOperators.Add(new CastingOperator(Numerics.Vector2I.Size <= Type.Size, type, new VectorNumericParameter(Numerics.Vector2I, "value")));
            CastingOperators.Add(new CastingOperator(Numerics.Vector3.Size <= Type.Size, type, new VectorNumericParameter(Numerics.Vector3, "value")));
            CastingOperators.Add(new CastingOperator(Numerics.Vector3I.Size <= Type.Size, type, new VectorNumericParameter(Numerics.Vector3I, "value")));
            CastingOperators.Add(new CastingOperator(Numerics.Vector4.Size <= Type.Size, type, new VectorNumericParameter(Numerics.Vector4, "value")));
            CastingOperators.Add(new CastingOperator(Numerics.Vector4I.Size <= Type.Size, type, new VectorNumericParameter(Numerics.Vector4I, "value")));
            CastingOperators.Add(new CastingOperator(Type.Size <= Numerics.Vector2.Size, Numerics.Vector2, new VectorQuantityParameter(type, "value")));
            CastingOperators.Add(new CastingOperator(Type.Size <= Numerics.Vector2I.Size, Numerics.Vector2I, new VectorQuantityParameter(type, "value")));
            CastingOperators.Add(new CastingOperator(Type.Size <= Numerics.Vector3.Size, Numerics.Vector3, new VectorQuantityParameter(type, "value")));
            CastingOperators.Add(new CastingOperator(Type.Size <= Numerics.Vector3I.Size, Numerics.Vector3I, new VectorQuantityParameter(type, "value")));
            CastingOperators.Add(new CastingOperator(Type.Size <= Numerics.Vector4.Size, Numerics.Vector4, new VectorQuantityParameter(type, "value")));
            CastingOperators.Add(new CastingOperator(Type.Size <= Numerics.Vector4I.Size, Numerics.Vector4I, new VectorQuantityParameter(type, "value")));

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
            InstanceMethods.Add(new Method("public", "override readonly", Types.String, "ToString", null, ToStringImpl()));
            InstanceMethods.Add(new Method("public", "override readonly", Types.Bool, "Equals", new ObjectParameter(), $"return obj is {Name} {Name.ToLower()} && Equals({Name.ToLower()});"));
            InstanceMethods.Add(new Method("public", "readonly", Types.Bool, "Equals", new VectorQuantityParameter(type, "other"), $"return this == other;"));
            InstanceMethods.Add(new Method("public", "override readonly", Numerics.Int, "GetHashCode", null, GetHashCodeImpl()));
            InstanceMethods.Add(new Method("public", "readonly", Numerics.Int, "CompareTo", new VectorQuantityParameter(type, "other"),
                $"int myHash = GetHashCode();"
                + "\nint otherHash = other.GetHashCode();"
                + "\nif (myHash > otherHash)"
                + $"\n{Indent("return 1;")}"
                + "\nelse if (myHash < otherHash)"
                + $"\n{Indent("return -1;")}"
                + "\nelse"
                + $"\n{Indent("return 0;")}"
            ));
            InstanceMethods.Space();
        }

        /* Protected methods. */
        protected abstract string ToStringImpl();
        protected abstract string GetHashCodeImpl();

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

            if (Type.Size == 2)
            {
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorNumericParameter(Numerics.Vector2, "a"),
                    new VectorQuantityParameter(Type, "b")
                ));
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorNumericParameter(Numerics.Vector2I, "a"),
                    new VectorQuantityParameter(Type, "b")
                ));
            }
            else if (Type.Size == 3)
            {
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorNumericParameter(Numerics.Vector3, "a"),
                    new VectorQuantityParameter(Type, "b")
                ));
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorNumericParameter(Numerics.Vector3I, "a"),
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

            if (Type.Size == 2)
            {
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorQuantityParameter(Type, "a"),
                    new VectorNumericParameter(Numerics.Vector2, "b")
                ));
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorQuantityParameter(Type, "a"),
                    new VectorNumericParameter(Numerics.Vector2I, "b")
                ));
            }
            else if (Type.Size == 3)
            {
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorQuantityParameter(Type, "a"),
                    new VectorNumericParameter(Numerics.Vector3, "b")
                ));
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new VectorQuantityParameter(Type, "a"),
                    new VectorNumericParameter(Numerics.Vector3I, "b")
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

        private string GetPropImpl(string field)
        {
            string code = field;
            for (int i = 1; i < Type.Size; i++)
            {
                code += ", " + field;
            }
            return code;
        }
    }
}