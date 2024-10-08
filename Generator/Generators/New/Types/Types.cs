namespace Generators
{
    /// <summary>
    /// Contains some global constants related to non-numeric and non-quantity types.
    /// </summary>
    public static class Types
    {
        /* Public properties. */
        public static BoolType Bool => new();
        public static StringType String => new();
        public static ObjectType Object => new();
    }
}