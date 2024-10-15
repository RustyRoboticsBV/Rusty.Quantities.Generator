namespace Generators
{
    /// <summary>
    /// A scalar struct generator.
    /// </summary>
    public abstract class ScalarQuantityStruct : Struct
    {
        /* Public properties. */
        public new ScalarQuantityType Type => base.Type as ScalarQuantityType;

        /* Constructors. */
        public ScalarQuantityStruct(ScalarQuantityType type, string summary) : base(type, summary)
        {
            // Fields.
            Fields.Add(new Field(Numerics.Core, "value", null));

            // Properties.
            Properties.Add(new Property(true, type, "Zero", $"new {Name}({Numerics.Zero})", $"A {Name.ToLower()} with the value 0."));
            Properties.Add(new Property(true, type, "One", $"new {Name}({Numerics.One})", $"A {Name.ToLower()} with the value 1."));
            Properties.Add(new Property(true, type, "Pi", $"new {Name}({Numerics.Pi})", $"A {Name.ToLower()} with the value π."));
            Properties.Add(new Property(true, type, "TwoPi", $"new {Name}({Numerics.TwoPi})", $"A {Name.ToLower()} with the value 2π."));

            // Constructors.
            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                Constructors.Add(new ScalarConstructor(Name, new ScalarNumericParameter(numeric, "value")));
            }
            Constructors.Add(new ScalarConstructor(Name, new ScalarQuantityParameter(type, "value")));

            // Casting operators.
            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                CastingOperators.Add(new CastingOperator(
                    !Numerics.MustExplicitCast(Numerics.Core, numeric),
                    numeric,
                    new ScalarQuantityParameter(type, "value"))
                );
            }

            CastingOperators.Add(new CastingOperator(true, Types.String, new ScalarQuantityParameter(type, "value")));

            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                CastingOperators.Add(new CastingOperator(
                    !Numerics.MustExplicitCast(numeric, Numerics.Core),
                    Type,
                    new ScalarNumericParameter(numeric, "value")));
            }

            // Arithmetic operators.
            AddBinaryOperator("+");
            AddBinaryOperator("-");
            AddBinaryOperator("*");
            AddBinaryOperator("/");
            AddBinaryOperator("%");
            AddUnaryOperator("++");
            AddUnaryOperator("--");
            AddUnaryOperator("+");
            AddUnaryOperator("-");

            // Comparison operators.
            AddComparisonOperator("==");
            AddComparisonOperator("!=");
            AddComparisonOperator(">");
            AddComparisonOperator("<");
            AddComparisonOperator(">=");
            AddComparisonOperator("<=");

            // Methods.
            InstanceMethods.Add(new Method("public", "override readonly", Types.String, "ToString", null, "return value.ToString();"));
            InstanceMethods.Add(new Method("public", "override readonly", Types.Bool, "Equals", new ObjectParameter(), $"return obj is {Name} {Name.ToLower()} && Equals({Name.ToLower()});"));
            InstanceMethods.Add(new Method("public", "readonly", Types.Bool, "Equals", new ScalarQuantityParameter(type, "other"), $"return this == other;"));
            InstanceMethods.Add(new Method("public", "override readonly", Numerics.Int, "GetHashCode", null, "return value.GetHashCode();"));
            InstanceMethods.Add(new Method("public", "readonly", Numerics.Int, "CompareTo", new ScalarQuantityParameter(type, "other"), $"if (this > other)\n{Indent("return 1;")}\nelse if (this < other)\n{Indent("return -1;")}\nelse\n{Indent("return 0;")}"));
            InstanceMethods.Space();
            AddMethodPair(new SignMethod(type));
            AddMethodPair(new AbsMethod(type));
            AddMethodPair(new TruncateMethod(type));
            AddMethodPair(new FracMethod(type));
            AddMethodPair(new DistMethod(type));
            AddMethodPair(new SqrtMethod(type));
            AddMethodPair(new Pow2Method(type));
            AddMethodPair(new PowMethod(type));
            AddMethodPair(new MinMethod(type));
            AddMethodPair(new MaxMethod(type));
            AddMethodPair(new ClampMethod(type));
            AddMethodPair(new RoundMethod(type));
            AddMethodPair(new FloorMethod(type));
            AddMethodPair(new CeilMethod(type));
            AddMethodPair(new SinMethod(type));
            AddMethodPair(new CosMethod(type));
            AddMethodPair(new TanMethod(type));
            AddMethodPair(new WrapMethod(type));
            AddMethodPair(new PingPongMethod(type));
            AddMethodPair(new SnapMethod(type));
            AddMethodPair(new MapMethod(type));
            AddMethodPair(new StepMethod(type));
            StaticMethods.Add(new MathdMethod(true, type, "Lerp", new(new ScalarQuantityParameter(type, "a"), new ScalarQuantityParameter(type, "b"), new ScalarNumericParameter(Numerics.Core, "factor")), $"Return the result of linearly interpolating between two {Name.ToLower()} values, using some lerp factor between 0 and 1."));
        }

        /* Protected methods. */
        /// <summary>
        /// Add a binary operator with some other quantity type.
        /// </summary>
        protected void AddBinaryOperator(Type returnType, string op, ScalarQuantityType otherType)
        {
            ArithmeticOperators.Add(new BinaryArithmeticOperator(
                returnType,
                op,
                new ScalarQuantityParameter(Type, "a"),
                new ScalarQuantityParameter(otherType, "b"))
            );
        }

        /// <summary>
        /// Add all formula methods from a library of formulas.
        /// </summary>
        protected void AddFormulas(FormulaSet[] formulas, char targetParam)
        {
            foreach (FormulaSet formulaSet in formulas)
            {
                if (formulaSet.HasFormula(targetParam))
                    StaticMethods.Add(new FormulaMethod(formulaSet, targetParam));
            }
        }

        /* Private methods. */
        /// <summary>
        /// Add all supported variants of a binary arithmetic operator.
        /// </summary>
        private void AddBinaryOperator(string op)
        {
            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new ScalarNumericParameter(numeric, "a"),
                    new ScalarQuantityParameter(Type, "b")
                ));
            }
            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                    new ScalarQuantityParameter(Type, "a"),
                    new ScalarNumericParameter(numeric, "b")
                ));
            }
            ArithmeticOperators.Add(new BinaryArithmeticOperator(Type, op,
                new ScalarQuantityParameter(Type, "a"),
                new ScalarQuantityParameter(Type, "b")
            ));
        }

        /// <summary>
        /// Add all supported variants of an unary operator.
        /// </summary>
        private void AddUnaryOperator(string op)
        {
            ArithmeticOperators.Add(new UnaryArithmeticOperator(Type, op,
                new ScalarQuantityParameter(Type, "value")
            ));
        }

        /// <summary>
        /// Add all supported variants of a comparison operator.
        /// </summary>
        private void AddComparisonOperator(string op)
        {
            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                ComparisonOperators.Add(new ComparisonOperator(op,
                    new ScalarNumericParameter(numeric, "a"),
                    new ScalarQuantityParameter(Type, "b")
                ));
            }
            foreach (ScalarNumericType numeric in Numerics.Scalars)
            {
                ComparisonOperators.Add(new ComparisonOperator(op,
                    new ScalarQuantityParameter(Type, "a"),
                    new ScalarNumericParameter(numeric, "b")
                ));
            }
            ComparisonOperators.Add(new ComparisonOperator(op,
                new ScalarQuantityParameter(Type, "a"),
                new ScalarQuantityParameter(Type, "b")
            ));
        }
    }
}