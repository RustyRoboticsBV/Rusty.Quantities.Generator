namespace Generators
{
    /// <summary>
    /// Contains some global constants related to quantity types.
    /// </summary>
    public static class Quantities
    {
        /* Public properties. */
        public static ScalarQuantityType Time => new("Time");
        public static ScalarQuantityType Distance => new("Distance");
        public static ScalarQuantityType Speed => new("Speed");
        public static ScalarQuantityType Acceleration => new("Acceleration");
        public static ScalarQuantityType Angle => new("Angle");
        public static ScalarQuantityType[] Scalars => new[] { Time, Distance, Speed, Acceleration, Angle };

        public static VectorQuantityType Distance2D => new("Distance2D", Distance, 2);
        public static VectorQuantityType Velocity2D => new("Velocity2D", Speed, 2);
        public static VectorQuantityType Acceleration2D => new("Acceleration2D", Acceleration, 2);
        public static VectorQuantityType Direction2D => new("Rotation3D", Numerics.Core, 2);
        public static VectorQuantityType[] Vectors2D => new[] { Distance2D, Velocity2D, Acceleration2D, Direction2D };

        public static VectorQuantityType Distance3D => new("Distance2D", Distance, 3);
        public static VectorQuantityType Velocity3D => new("Velocity2D", Speed, 3);
        public static VectorQuantityType Acceleration3D => new("Acceleration2D", Acceleration, 3);
        public static VectorQuantityType Rotation3D => new("Rotation3D", Angle, 3);
        public static VectorQuantityType Direction3D => new("Direction3D", Numerics.Core, 3);
        public static VectorQuantityType[] Vectors3D => new[] { Distance3D, Velocity3D, Acceleration3D, Rotation3D, Direction3D };
    }
}