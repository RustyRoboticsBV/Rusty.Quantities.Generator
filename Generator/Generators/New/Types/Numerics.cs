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
}