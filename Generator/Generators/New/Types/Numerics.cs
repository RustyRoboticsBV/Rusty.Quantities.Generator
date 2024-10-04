namespace Generators
{
    /// <summary>
    /// Contains some global constants.
    /// </summary>
    public static class Numerics
    {
        /* Public properties. */
        /// <summary>
        /// The fundamental scalar numeric data type on which all quantities are built.
        /// </summary>
        public static string Core => "double";
        /// <summary>
        /// The scalar numeric data types that have less precision than the core type.
        /// </summary>
        public static string[] Imprecise => new string[] { "byte", "sbyte", "short", "ushort", "int", "uint", "long", "ulong", "float" };
        /// <summary>
        /// The scalar numeric data types that have more precision than the core types.
        /// </summary>
        public static string[] Precise => new string[] { "decimal" };
        /// <summary>
        /// All scalar numeric data types (imprecise, core and precise).
        /// </summary>
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
        /// <summary>
        /// Return whether a cast from one scalar numeric data type to another requires an explicit cast.
        /// </summary>
        public static bool MustCast(string from, string to)
        {
            return HasPrecise(from) && !HasPrecise(to)
                || HasPrecise(to) && !HasPrecise(from)
                || HasCore(from) && HasImprecise(to);
        }

        /// <summary>
        /// Check if an imprecise scalar numeric data type matches some name.
        /// </summary>
        public static bool HasImprecise(string type)
        {
            return Contains(Imprecise, type);
        }

        /// <summary>
        /// Check if the core scalar numeric data type matches some name.
        /// </summary>
        public static bool HasCore(string type)
        {
            return Core == type;
        }

        /// <summary>
        /// Check if a precise scalar numeric data type matches some name.
        /// </summary>
        public static bool HasPrecise(string type)
        {
            return Contains(Precise, type);
        }

        /* Private methods. */
        /// <summary>
        /// Check if an array of strings contains some string.
        /// </summary>
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