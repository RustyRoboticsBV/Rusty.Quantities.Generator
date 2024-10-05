namespace Generators
{
    /// <summary>
    /// A scalar struct generator.
    /// </summary>
    public abstract class ScalarQuantityStruct : Struct
    {
        /* Constructors. */
        public ScalarQuantityStruct(string name, string? summary) : base(name, summary)
        {
            // Fields.
            Fields.Add(new Field(Numerics.Core, "value", null));

            // Properties.
            Properties.Add(new Property(true, name, "Zero", $"new {Name}({Numerics.Zero})", $"A {Name.ToLower()} with the value 0."));
            Properties.Add(new Property(true, name, "One", $"new {Name}({Numerics.One})", $"A {Name.ToLower()} with the value 1."));
            Properties.Add(new Property(true, name, "Pi", $"new {Name}({Numerics.Pi})", $"A {Name.ToLower()} with the value π."));
            Properties.Add(new Property(true, name, "TwoPi", $"new {Name}({Numerics.TwoPi})", $"A {Name.ToLower()} with the value 2π."));

            // Constructors.
            foreach (string type in Numerics.Scalars)
            {
                Constructors.Add(new Constructor(name, new ScalarNumericParameter(type, "value"),
                    $"this.value = {new ScalarNumericType(type).CastTo("value", Numerics.CoreType)};"));
            }
            Constructors.Add(new Constructor(name, new ScalarQuantityParameter(name, "value"), "this.value = value.value;"));

            // Casting operators.
            foreach (string type in Numerics.Scalars)
            {
                CastingOperators.Add(new CastingOperator(
                    !Numerics.MustCast(Numerics.Core, type),
                    new ReturnScalarNumeric(type),
                    new ScalarQuantityParameter(name, "value"))
                );
            }

            CastingOperators.Add(new CastingOperator(true, new ReturnString(), new ScalarQuantityParameter(name, "value")));

            foreach (string type in Numerics.Scalars)
            {
                CastingOperators.Add(new CastingOperator(
                    !Numerics.MustCast(type, Numerics.Core),
                    new ReturnScalarQuantity(new ScalarQuantityType(name)),
                    new ScalarNumericParameter(type, "value")));
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
            InstanceMethods.Add(new Method("public", "override readonly", "string", "ToString", null, "return value.ToString();"));
            InstanceMethods.Add(new Method("public", "override readonly", "bool", "Equals", new ObjectParameter(), $"return obj is {Name} {Name.ToLower()} && Equals({Name.ToLower()});"));
            InstanceMethods.Add(new Method("public", "readonly", "bool", "Equals", new ScalarQuantityParameter(Name, "other"), $"return this == other;"));
            InstanceMethods.Add(new Method("public", "override readonly", "int", "GetHashCode", null, "return value.GetHashCode();"));
            InstanceMethods.Space();
            AddMethodPair(new SignMethod(name));
            AddMethodPair(new AbsMethod(name));
            AddMethodPair(new TruncateMethod(name));
            AddMethodPair(new FracMethod(name));
            AddMethodPair(new DistMethod(name));
            AddMethodPair(new SqrtMethod(name));
            AddMethodPair(new Pow2Method(name));
            AddMethodPair(new PowMethod(name));
            AddMethodPair(new MinMethod(name));
            AddMethodPair(new MaxMethod(name));
            AddMethodPair(new ClampMethod(name));
            AddMethodPair(new RoundMethod(name));
            AddMethodPair(new FloorMethod(name));
            AddMethodPair(new CeilMethod(name));
            AddMethodPair(new SinMethod(name));
            AddMethodPair(new CosMethod(name));
            AddMethodPair(new TanMethod(name));
            AddMethodPair(new WrapMethod(name));
            AddMethodPair(new PingPongMethod(name));
            AddMethodPair(new SnapMethod(name));
            AddMethodPair(new MapMethod(name));
            AddMethodPair(new StepMethod(name));
            StaticMethods.Add(new MathdMethod(true, new ReturnScalarQuantity(Name), "Lerp", new(new ScalarQuantityParameter(Name, "a"), new ScalarQuantityParameter(Name, "b"), new ScalarNumericParameter(Numerics.CoreType, "factor")), $"Return the result of linearly interpolating between two {Name.ToLower()} values, using some lerp factor between 0 and 1."));
        }

        /* Protected methods. */
        /// <summary>
        /// Add a binary operator with some other quantity type.
        /// </summary>
        protected void AddBinaryOperator(string returnType, string op, string otherType)
        {
            ArithmeticOperators.Add(new BinaryArithmeticOperator(new ReturnScalarQuantity(returnType), op,
                new ScalarQuantityParameter(Name, "a"),
                new ScalarQuantityParameter(new ScalarQuantityType(otherType, Name), "b"))
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
            foreach (string numeric in Numerics.Scalars)
            {
                ArithmeticOperators.Add(new BinaryArithmeticOperator(new ReturnScalarQuantity(Name), op,
                    new ScalarNumericParameter(numeric, "a"),
                    new ScalarQuantityParameter(Name, "b")
                ));
            }
            foreach (string numeric in Numerics.Scalars)
            {
                ArithmeticOperators.Add(new BinaryArithmeticOperator(new ReturnScalarQuantity(Name), op,
                    new ScalarQuantityParameter(Name, "a"),
                    new ScalarNumericParameter(numeric, "b")
                ));
            }
            ArithmeticOperators.Add(new BinaryArithmeticOperator(new ReturnScalarQuantity(Name), op,
                new ScalarQuantityParameter(Name, "a"),
                new ScalarQuantityParameter(Name, "b")
            ));
        }

        /// <summary>
        /// Add all supported variants of an unary operator.
        /// </summary>
        private void AddUnaryOperator(string op)
        {
            ArithmeticOperators.Add(new UnaryArithmeticOperator(new ReturnScalarQuantity(Name), op,
                new ScalarQuantityParameter(Name, "value")
            ));
        }

        /// <summary>
        /// Add all supported variants of a comparison operator.
        /// </summary>
        private void AddComparisonOperator(string op)
        {
            foreach (string type in Numerics.Scalars)
            {
                ComparisonOperators.Add(new ComparisonOperator(op,
                    new ScalarNumericParameter(type, "a"),
                    new ScalarQuantityParameter(Name, "b")
                ));
            }
            foreach (string type in Numerics.Scalars)
            {
                ComparisonOperators.Add(new ComparisonOperator(op,
                    new ScalarQuantityParameter(Name, "a"),
                    new ScalarNumericParameter(type, "b")
                ));
            }
            ComparisonOperators.Add(new ComparisonOperator(op,
                new ScalarQuantityParameter(Name, "a"),
                new ScalarQuantityParameter(Name, "b")
            ));
        }
    }
}