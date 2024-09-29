namespace Generators.New
{
    public static class Numerics
    {
        /* Public properties. */
        public static string Core => "double";
        public static string[] Imprecise => new string[] { "byte", "sbyte", "short", "ushort", "int", "uint", "long", "ulong", "float" };
        public static string[] Precise => new string[] { "decimal" };
        public static string[] Scalars
        {
            get
            {
                string[] types = new string[Imprecise.Length + Precise.Length + 1];
                Array.Copy(Imprecise, types, Imprecise.Length);
                types[Imprecise.Length] = Core;
                Array.Copy(Precise, 0, types, Imprecise.Length + 1, Precise.Length);
                return types;
            }
        }

        /// <summary>
        /// The core, scalar numeric type that the entire module is built upon.
        /// </summary>
        public static ScalarNumericType CoreType => new ScalarNumericType(Core);

        /* Public methods. */
        public static bool MustCast(string from, string to)
        {
            return HasPrecise(from) && !HasPrecise(to)
                || HasPrecise(to) && !HasPrecise(from)
                || HasCore(from) && HasImprecise(to);
        }

        public static bool HasImprecise(string type)
        {
            return Contains(Imprecise, type);
        }

        public static bool HasCore(string type)
        {
            return Core == type;
        }

        public static bool HasPrecise(string type)
        {
            return Contains(Precise, type);
        }

        /* Private methods. */
        private static bool Contains(string[] array, string value)
        {
            foreach (string member in array)
            {
                if (member == value)
                    return true;
            }
            return false;
        }
    }

    public abstract class Type
    {
        /* Public properties. */
        public string Name { get; set; }
        public string StructScope { get; set; }

        /* Constructors. */
        public Type(string name, string structScope = "")
        {
            Name = name;
            StructScope = structScope;
        }

        /* Public methods. */
        public abstract string CastTo(string value, Type to);
    }

    public abstract class ScalarType : Type
    {
        /* Constructors. */
        public ScalarType(string name, string structScope = "") : base(name, structScope) { }
    }

    public abstract class VectorType : Type
    {
        public VectorType(string name, string structScope = "") : base(name, structScope) { }
    }

    public class StringType : Type
    {
        public StringType() : base("string" ) { }

        public override string CastTo(string value, Type to)
        {
            throw new NotImplementedException();
        }
    }

    public class ScalarNumericType : ScalarType
    {
        public ScalarNumericType(string name) : this(name, name) { }
        public ScalarNumericType(string name, string structScope = "") : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            if (to is ScalarNumericType toN)
            {
                if (Numerics.MustCast(Name, toN.Name))
                    return $"({toN.Name}){value}";
                else
                    return value;
            }
            else if (to is StringType)
                return $"{value}.ToString()";
            else if (to is ScalarQuantityType toS)
            {
                if (Numerics.MustCast(Name, Numerics.Core))
                    return $"new {toS.Name}(({Numerics.Core}){value})";
                else
                    return $"new {toS.Name}({value})";
            }
            else if (to is VectorQuantityType toV)
                return $"new {toV.Name}({value}, {value}, {value})";
            throw new InvalidCastException();
        }
    }

    public class ScalarQuantityType : ScalarType
    {
        public ScalarQuantityType(string name) : this(name, name) { }
        public ScalarQuantityType(string name, string structScope) : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            if (to is ScalarNumericType n)
            {
                if (StructScope == Name)
                {
                    if (to.Name == Numerics.Core)
                        return $"{value}.value";
                    else
                        return $"({n.Name}){value}.value";
                }
                else
                    return $"({n.Name}){value}";
            }
            else if (to is StringType s)
                return $"{value}.ToString()";
            else if (to is ScalarQuantityType scalar)
            {
                if (Name == scalar.Name)
                    return value;
                else if (StructScope == Name)
                    return $"new {scalar.Name}({value}.value)";
                else
                    return $"new {scalar.Name}(({Numerics.Core}){value})";
            }
            else
                throw new ArgumentOutOfRangeException(value + " from " + Name + " to " + to.Name);
        }
    }

    public class VectorNumericType : ScalarType
    {
        public VectorNumericType(string name) : this(name, name) { }
        public VectorNumericType(string name, string structScope = "") : base(name, structScope) { }

        public override string CastTo(string value, Type to)
        {
            throw new NotImplementedException();
        }
    }

    public class VectorQuantityType : VectorType
    {
        public VectorQuantityType(string name) : this(name, name) { }
        public VectorQuantityType(string name, string structScope = "") : base(name, structScope) { }

        public override string CastTo(string value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}