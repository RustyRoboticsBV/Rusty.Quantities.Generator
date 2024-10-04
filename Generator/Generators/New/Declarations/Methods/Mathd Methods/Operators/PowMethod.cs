﻿namespace Generators
{
    /// <summary>
    /// A power of method generator.
    /// </summary>
    public class PowMethod : MathdMethodPair
    {
        /* Constructors. */
        public PowMethod(string quantityName) : base(
            new ReturnScalarQuantity(quantityName),
            "Pow",
            new ScalarNumericParameter(Numerics.Core, "power"),
            new(new ScalarQuantityParameter(quantityName, "value"), new ScalarNumericParameter(Numerics.Core, "power")),
            new($"Returns the value of PRONOUN QUANTITY_NAME raised to the specified power.",
                quantityName)) { }
    }
}