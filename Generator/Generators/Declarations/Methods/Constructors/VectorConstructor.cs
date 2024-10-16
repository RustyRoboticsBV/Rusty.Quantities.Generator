namespace Generators
{
    public class VectorConstructor : Constructor
    {
        /* Public properties. */
        public int Dimensionality { get; private set; }

        /* Constructors. */
        public VectorConstructor(string name, ScalarParameter x, ScalarParameter y) : base(name, new(x, y), "")
        {
            Dimensionality = 2;
        }
        public VectorConstructor(string name, ScalarParameter x, ScalarParameter y, ScalarParameter z) : base(name, new(x, y, z), "")
        {
            Dimensionality = 3;
        }
        public VectorConstructor(string name, ScalarParameter x, ScalarParameter y, ScalarParameter z, ScalarParameter w) : base(name, new(x, y, z, w), "")
        {
            Dimensionality = 4;
        }
        public VectorConstructor(string name, VectorParameter vectorParameter, int dimensionality) : base(name, vectorParameter, "")
        {
            Dimensionality = dimensionality;
        }
        public VectorConstructor(string name, ScalarNumericType scalarType, int dimensionality) : base(name, new(), "")
        {
            Dimensionality = dimensionality;

            List<ScalarNumericParameter> parameters = new();
            if (dimensionality >= 1)
                parameters.Add(new ScalarNumericParameter(scalarType, "x"));
            if (dimensionality >= 2)
                parameters.Add(new ScalarNumericParameter(scalarType, "y"));
            if (dimensionality >= 3)
                parameters.Add(new ScalarNumericParameter(scalarType, "z"));
            if (dimensionality >= 4)
                parameters.Add(new ScalarNumericParameter(scalarType, "w"));
            Parameters = new(parameters.ToArray());
        }
        public VectorConstructor(string name, ScalarQuantityType scalarType, int dimensionality) : base(name, new(), "")
        {
            Dimensionality = dimensionality;

            List<ScalarQuantityParameter> parameters = new();
            if (dimensionality >= 1)
                parameters.Add(new ScalarQuantityParameter(scalarType, "x"));
            if (dimensionality >= 2)
                parameters.Add(new ScalarQuantityParameter(scalarType, "y"));
            if (dimensionality >= 3)
                parameters.Add(new ScalarQuantityParameter(scalarType, "z"));
            if (dimensionality >= 4)
                parameters.Add(new ScalarQuantityParameter(scalarType, "w"));
            Parameters = new(parameters.ToArray());
        }

        /* Protected methods. */
        protected override string IdContents()
        {
            Implementation = GetImpl();
            return base.IdContents();
        }

        /* Private methods. */
        private string GetImpl()
        {
            // Vector parameter.
            if (Parameters.Count == 1 && Parameters[0] is VectorParameter vectorParam)
            {
                string code = $"x = {vectorParam.CastXTo(Numerics.Core)};";
                if (Dimensionality >= 2)
                    code += $"\ny = {vectorParam.CastYTo(Numerics.Core)};";
                if (Dimensionality >= 3)
                    code += $"\nz = {vectorParam.CastZTo(Numerics.Core)};";
                if (Dimensionality >= 4)
                    code += $"\nw = {vectorParam.CastWTo(Numerics.Core)};";
                return code;
            }

            // Scalar parameters.
            else
            {
                string code = $"this.x = {Parameters[0].CastTo(Numerics.Core)};";
                if (Parameters.Count >= 2)
                    code += $"\nthis.y = {Parameters[1].CastTo(Numerics.Core)};";
                if (Parameters.Count >= 3)
                    code += $"\nthis.z = {Parameters[2].CastTo(Numerics.Core)};";
                if (Parameters.Count >= 4)
                    code += $"\nthis.w = {Parameters[3].CastTo(Numerics.Core)};";
                return code;
            }
        }
    }
}