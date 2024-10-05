namespace Generators
{
    /// <summary>
    /// A vector struct generator.
    /// </summary>
    public abstract class VectorQuantityStruct : Struct
    {
        /* Constructors. */
        public VectorQuantityStruct(string name, ScalarQuantityType scalarType, string? summary) : base(name, summary)
        {
            // Fields.
            Fields.Add(new Field(scalarType.Name, "x", null));
            Fields.Add(new Field(scalarType.Name, "y", null));
            Fields.Add(new Field(scalarType.Name, "z", null));

            // Properties.
            Properties.Add(new Property(true, name, "Zero", $"new {Name}({scalarType.Name}.Zero, {scalarType.Name}.Zero, {scalarType.Name}.Zero)", $"A {Name.ToLower()} with the value 0."));
            Properties.Add(new Property(true, name, "One", $"new {Name}({scalarType.Name}.One, {scalarType.Name}.One, {scalarType.Name}.One)", $"A {Name.ToLower()} with the value 1."));
            Properties.Add(new Property(true, name, "Pi", $"new {Name}({scalarType.Name}.Pi, {scalarType.Name}.Pi, {scalarType.Name}.Pi)", $"A {Name.ToLower()} with the value π."));
            Properties.Add(new Property(true, name, "TwoPi", $"new {Name}({scalarType.Name}.TwoPi, {scalarType.Name}.TwoPi, {scalarType.Name}.TwoPi)", $"A {Name.ToLower()} with the value 2π."));
            Properties.Space();
            Properties.Add(new Property(false, scalarType.Name, "X", "x", $"The X component of this {Name.ToLower()} value."));
            Properties.Add(new Property(false, scalarType.Name, "Y", "y", $"The Y component of this {Name.ToLower()} value."));
            Properties.Add(new Property(false, scalarType.Name, "Z", "z", $"The Z component of this {Name.ToLower()} value."));
            Properties.Add(new Property(false, name, "XY", $"new {Name}(X, Y, {scalarType.Name}.Zero)", $"A {Name.ToLower()} value derived from this one, with the value (X, Y, 0)"));
            Properties.Add(new Property(false, name, "XZ", $"new {Name}(X, Z, {scalarType.Name}.Zero)", $"A {Name.ToLower()} value derived from this one, with the value (X, Z, 0)"));
            Properties.Add(new Property(false, name, "YZ", $"new {Name}(Y, Z, {scalarType.Name}.Zero)", $"A {Name.ToLower()} value derived from this one, with the value (Y, Z, 0)"));

            // Constructors.
            Constructors.Add(new Constructor(
                name,
                new(
                    new ScalarQuantityParameter(scalarType, "x")
                ), $"this.x = x;"
                + $"\ny = {scalarType.Name}.Zero;"
                + $"\nz = {scalarType.Name}.Zero;"
            ));
            Constructors.Add(new Constructor(
                name,
                new(
                    new ScalarQuantityParameter(scalarType, "x"),
                    new ScalarQuantityParameter(scalarType, "y")
                ), $"this.x = x;"
                + $"\nthis.y = y;"
                + $"\nz = {scalarType.Name}.Zero;"
            ));
            Constructors.Add(new Constructor(
                name,
                new(
                    new ScalarQuantityParameter(scalarType, "x"),
                    new ScalarQuantityParameter(scalarType, "y"),
                    new ScalarQuantityParameter(scalarType, "z")
                ), $"this.x = x;"
                + $"\nthis.y = y;"
                + $"\nthis.z = z;"
            ));
            Constructors.Add(new Constructor(
                name,
                new VectorNumericParameter(Numerics.Vector2, "value"),
                $"x = new {scalarType.Name}(value.X);"
                + $"\ny = new {scalarType.Name}(value.Y);"
                + $"\nz = {scalarType.Name}.Zero;"
            ));
            Constructors.Add(new Constructor(
                name,
                new VectorNumericParameter(Numerics.Vector3, "value"),
                $"x = new {scalarType.Name}(value.X);"
                + $"\ny = new {scalarType.Name}(value.Y);"
                + $"\nz = new {scalarType.Name}(value.Z);"
            ));
            Constructors.Add(new Constructor(
                name,
                new VectorNumericParameter(Numerics.Vector4, "value"),
                $"x = new {scalarType.Name}(value.X);"
                + $"\ny = new {scalarType.Name}(value.Y);"
                + $"\nz = new {scalarType.Name}(value.Z);"
            ));
            Constructors.Add(new Constructor(
                name,
                new VectorNumericParameter(Numerics.Vector2I, "value"),
                $"x = new {scalarType.Name}(value.X);"
                + $"\ny = new {scalarType.Name}(value.Y);"
                + $"\nz = {scalarType.Name}.Zero;"
            ));
            Constructors.Add(new Constructor(
                name,
                new VectorNumericParameter(Numerics.Vector3I, "value"),
                $"x = new {scalarType.Name}(value.X);"
                + $"\ny = new {scalarType.Name}(value.Y);"
                + $"\nz = new {scalarType.Name}(value.Z);"
            ));
            Constructors.Add(new Constructor(
                name,
                new VectorNumericParameter(Numerics.Vector4I, "value"),
                $"x = new {scalarType.Name}(value.X);"
                + $"\ny = new {scalarType.Name}(value.Y);"
                + $"\nz = new {scalarType.Name}(value.Z);"
            ));

            // Casting operators.
            CastingOperators.Add(new CastingOperator(
                true,
                new ReturnVectorNumeric(Numerics.Vector3),
                new VectorQuantityParameter(name, "value"))
            );
            CastingOperators.Add(new CastingOperator(true, new ReturnString(), new ScalarQuantityParameter(name, "value")));

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
            ArithmeticOperators.Add(new BinaryArithmeticOperator(new ReturnVectorQuantity(Name), op,
                new VectorQuantityParameter(Name, "a"),
                new VectorQuantityParameter(Name, "b")
            ));
        }

        /// <summary>
        /// Add all supported variants of an unary operator.
        /// </summary>
        private void AddUnaryOperator(string op)
        {
            ArithmeticOperators.Add(new UnaryArithmeticOperator(new ReturnVectorQuantity(Name), op,
                new VectorQuantityParameter(Name, "value")
            ));
        }

        /// <summary>
        /// Add all supported variants of a comparison operator.
        /// </summary>
        private void AddComparisonOperator(string op)
        {
            /*ComparisonOperators.Add(new ComparisonOperator(op,
                new VectorNumericParameter(type, "a"),
                new VectorQuantityParameter(Name, "b")
            ));
            ComparisonOperators.Add(new ComparisonOperator(op,
                new VectorQuantityParameter(Name, "a"),
                new VectorNumericParameter(type, "b")
            ));*/
            ComparisonOperators.Add(new ComparisonOperator(op,
                new VectorQuantityParameter(Name, "a"),
                new VectorQuantityParameter(Name, "b")
            ));
        }
    }
}