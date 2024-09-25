using Godot;
using System;

namespace Rusty.Quantities
{
    /// <summary>
    /// Represents a 3D direction vector.
    /// </summary>
    public struct Direction
    {
        /* Fields. */
        private double x;
        private double y;
        private double z;

        /* Public properties. */
        public static Direction Zero => new Direction(0, 0, 0);
        public static Direction Left => new Direction(-1, 0, 0);
        public static Direction Right => new Direction(1, 0, 0);
        public static Direction Down => new Direction(0, -1, 0);
        public static Direction Up => new Direction(0, 1, 0);
        public static Direction Back => new Direction(0, 0, -1);
        public static Direction Forward => new Direction(0, 0, 1);

        public readonly double X => x;
        public readonly double Y => y;
        public readonly double Z => z;
        public readonly Vector2 XY => new Vector2((float)x, (float)y);
        public readonly Vector2 XZ => new Vector2((float)x, (float)z);
        public readonly Vector2 YZ => new Vector2((float)y, (float)z);

        /* Constructors. */
        public Direction(double x, double y, double z)
        {
            double length = Mathd.Sqrt(Mathd.Pow2(x) + Mathd.Pow2(y) + Mathd.Pow2(z));
            this.x = length > 0 ? x / length : 0;
            this.y = length > 0 ? y / length : 0;
            this.z = length > 0 ? z / length : 0;
        }

        /* Cast operators. */
        public static implicit operator Vector2(Direction value) => value.XY;
        public static implicit operator Vector3(Direction value) => new Vector3((float)value.x, (float)value.y, (float)value.z);
        public static implicit operator Direction(Vector2 value) => new Direction(value.X, value.Y, 0f);
        public static implicit operator Direction(Vector3 value) => new Direction(value.X, value.Y, value.Z);

        /* Arithmetic operators. */
        public static Direction operator -(Direction value) => new Direction(-value.x, -value.y, -value.z);
        public static Direction operator +(Direction value) => new Direction(+value.x, +value.y, +value.z);

        /* Comparison operators. */
        public static bool operator ==(Direction a, Direction b) => a.x == b.x && a.y == b.y && a.z == b.z;
        public static bool operator !=(Direction a, Direction b) => a.x != b.x || a.y != b.y || a.z != b.z;

        /* Public methods. */
        public override bool Equals(object? obj) => obj is Direction direction && this == direction;
        public override int GetHashCode() => (x.GetHashCode() * 17 + y.GetHashCode()) * 17 + z.GetHashCode();
        public override string ToString() => $"({x}, {y}, {z})";
    }
}
