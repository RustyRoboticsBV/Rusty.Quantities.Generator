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

        public static VectorQuantityType Distance2D => new("Distance2D", Distance, 2);
        public static VectorQuantityType Speed2D => new("Speed2D", Speed, 2);
        public static VectorQuantityType Acceleration2D => new("Acceleration2D", Acceleration, 2);
        public static VectorQuantityType Direction2D => new("Direction2D", Numerics.Core, 2);

        public static VectorQuantityType Distance3D => new("Distance2D", Distance, 3);
        public static VectorQuantityType Speed3D => new("Speed3D", Speed, 3);
        public static VectorQuantityType Acceleration3D => new("Acceleration2D", Acceleration, 3);
        public static VectorQuantityType Rotation3D => new("Rotation3D", Angle, 3);
        public static VectorQuantityType Direction3D => new("Direction3D", Numerics.Core, 3);

        public static VectorQuantityType Get2D(VectorQuantityType type3D)
        {
            if (type3D.Name == Distance3D.Name)
                return Distance2D;
            else if (type3D.Name == Speed3D.Name)
                return Speed2D;
            else if (type3D.Name == Acceleration3D.Name)
                return Acceleration2D;
            else if (type3D.Name == Direction3D.Name)
                return Direction2D;

            throw new ArgumentOutOfRangeException(type3D.GetType().Name, $"Cannot get 2D value of the type {type3D.Name}.");
        }
    }
}