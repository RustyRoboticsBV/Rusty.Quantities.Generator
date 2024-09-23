using System;

namespace Modules.L0.Quantities
{
    /// <summary>
    /// Represents a acceleration quantity.
    /// </summary>
    [Serializable]
    public struct Acceleration
    {
        /* Fields. */
        private double value;

        /* Public properties. */
        public static Acceleration Zero => new Acceleration(0.0);
        public static Acceleration One => new Acceleration(1.0);

        /* Constructors. */
        public Acceleration(double value)
        {
            this.value = value;
        }

        /* Casting operators. */
        public static explicit operator short(Acceleration value) => (short)value.value;
        public static explicit operator int(Acceleration value) => (int)value.value;
        public static explicit operator long(Acceleration value) => (long)value.value;
        public static implicit operator float(Acceleration value) => (float)value.value;
        public static implicit operator double(Acceleration value) => value.value;
        public static implicit operator Acceleration(short value) => new Acceleration(value);
        public static implicit operator Acceleration(int value) => new Acceleration(value);
        public static implicit operator Acceleration(long value) => new Acceleration(value);
        public static implicit operator Acceleration(float value) => new Acceleration(value);
        public static implicit operator Acceleration(double value) => new Acceleration(value);

        /* Arithmetic operators. */
        public static Acceleration operator +(short a, Acceleration b) => new Acceleration(a + b.value);
        public static Acceleration operator +(int a, Acceleration b) => new Acceleration(a + b.value);
        public static Acceleration operator +(long a, Acceleration b) => new Acceleration(a + b.value);
        public static Acceleration operator +(float a, Acceleration b) => new Acceleration(a + b.value);
        public static Acceleration operator +(double a, Acceleration b) => new Acceleration(a + b.value);
        public static Acceleration operator +(Acceleration a, short b) => new Acceleration(a.value + b);
        public static Acceleration operator +(Acceleration a, int b) => new Acceleration(a.value + b);
        public static Acceleration operator +(Acceleration a, long b) => new Acceleration(a.value + b);
        public static Acceleration operator +(Acceleration a, float b) => new Acceleration(a.value + b);
        public static Acceleration operator +(Acceleration a, double b) => new Acceleration(a.value + b);
        public static Acceleration operator +(Acceleration a, Acceleration b) => new Acceleration(a.value + b.value);
        public static Acceleration operator -(short a, Acceleration b) => new Acceleration(a - b.value);
        public static Acceleration operator -(int a, Acceleration b) => new Acceleration(a - b.value);
        public static Acceleration operator -(long a, Acceleration b) => new Acceleration(a - b.value);
        public static Acceleration operator -(float a, Acceleration b) => new Acceleration(a - b.value);
        public static Acceleration operator -(double a, Acceleration b) => new Acceleration(a - b.value);
        public static Acceleration operator -(Acceleration a, short b) => new Acceleration(a.value - b);
        public static Acceleration operator -(Acceleration a, int b) => new Acceleration(a.value - b);
        public static Acceleration operator -(Acceleration a, long b) => new Acceleration(a.value - b);
        public static Acceleration operator -(Acceleration a, float b) => new Acceleration(a.value - b);
        public static Acceleration operator -(Acceleration a, double b) => new Acceleration(a.value - b);
        public static Acceleration operator -(Acceleration a, Acceleration b) => new Acceleration(a.value - b.value);
        public static Acceleration operator *(short a, Acceleration b) => new Acceleration(a * b.value);
        public static Acceleration operator *(int a, Acceleration b) => new Acceleration(a * b.value);
        public static Acceleration operator *(long a, Acceleration b) => new Acceleration(a * b.value);
        public static Acceleration operator *(float a, Acceleration b) => new Acceleration(a * b.value);
        public static Acceleration operator *(double a, Acceleration b) => new Acceleration(a * b.value);
        public static Acceleration operator *(Acceleration a, short b) => new Acceleration(a.value * b);
        public static Acceleration operator *(Acceleration a, int b) => new Acceleration(a.value * b);
        public static Acceleration operator *(Acceleration a, long b) => new Acceleration(a.value * b);
        public static Acceleration operator *(Acceleration a, float b) => new Acceleration(a.value * b);
        public static Acceleration operator *(Acceleration a, double b) => new Acceleration(a.value * b);
        public static Acceleration operator *(Acceleration a, Acceleration b) => new Acceleration(a.value * b.value);
        public static Acceleration operator /(short a, Acceleration b) => new Acceleration(a / b.value);
        public static Acceleration operator /(int a, Acceleration b) => new Acceleration(a / b.value);
        public static Acceleration operator /(long a, Acceleration b) => new Acceleration(a / b.value);
        public static Acceleration operator /(float a, Acceleration b) => new Acceleration(a / b.value);
        public static Acceleration operator /(double a, Acceleration b) => new Acceleration(a / b.value);
        public static Acceleration operator /(Acceleration a, short b) => new Acceleration(a.value / b);
        public static Acceleration operator /(Acceleration a, int b) => new Acceleration(a.value / b);
        public static Acceleration operator /(Acceleration a, long b) => new Acceleration(a.value / b);
        public static Acceleration operator /(Acceleration a, float b) => new Acceleration(a.value / b);
        public static Acceleration operator /(Acceleration a, double b) => new Acceleration(a.value / b);
        public static Acceleration operator /(Acceleration a, Acceleration b) => new Acceleration(a.value / b.value);
        public static Acceleration operator %(short a, Acceleration b) => new Acceleration(a % b.value);
        public static Acceleration operator %(int a, Acceleration b) => new Acceleration(a % b.value);
        public static Acceleration operator %(long a, Acceleration b) => new Acceleration(a % b.value);
        public static Acceleration operator %(float a, Acceleration b) => new Acceleration(a % b.value);
        public static Acceleration operator %(double a, Acceleration b) => new Acceleration(a % b.value);
        public static Acceleration operator %(Acceleration a, short b) => new Acceleration(a.value % b);
        public static Acceleration operator %(Acceleration a, int b) => new Acceleration(a.value % b);
        public static Acceleration operator %(Acceleration a, long b) => new Acceleration(a.value % b);
        public static Acceleration operator %(Acceleration a, float b) => new Acceleration(a.value % b);
        public static Acceleration operator %(Acceleration a, double b) => new Acceleration(a.value % b);
        public static Acceleration operator %(Acceleration a, Acceleration b) => new Acceleration(a.value % b.value);
        public static Acceleration operator -(Acceleration value) => new Acceleration(-value.value);

        /* Public methods. */
        public readonly override string ToString() => value.ToString();

        /// <summary>
        /// Return the sign of this acceleration value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public readonly int Sign() => Mathd.Sign(value);
        /// <summary>
        /// Return the absolute value of this acceleration value.
        /// </summary>
        public readonly Acceleration Abs() => new Acceleration(Mathd.Abs(value));
        /// <summary>
        /// Return the integral part of this acceleration value.
        /// </summary>
        public readonly Acceleration Truncate() => new Acceleration(Mathd.Truncate(value));
        /// <summary>
        /// Return the fractional part of this acceleration value.
        /// </summary>
        public readonly Acceleration Frac() => new Acceleration(Mathd.Frac(value));
        /// <summary>
        /// Return the absolute distance between this and another acceleration value.
        /// </summary>
        public readonly Acceleration Dist(Acceleration other) => new Acceleration(Mathd.Dist(value, other.value));
        /// <summary>
        /// Return the square root of this acceleration value.
        /// </summary>
        public readonly Acceleration Sqrt() => new Acceleration(Mathd.Sqrt(value));
        /// <summary>
        /// Return the result of raising this acceleration value to the power of two.
        /// </summary>
        public readonly Acceleration Pow2() => new Acceleration(Mathd.Pow2(value));
        /// <summary>
        /// Return the result of raising this acceleration value to the specified power.
        /// </summary>
        public readonly Acceleration Pow(double power) => new Acceleration(Mathd.Pow(value, power));
        /// <summary>
        /// Return the smallest of this and another acceleration value.
        /// </summary>
        public readonly Acceleration Min(Acceleration other) => new Acceleration(Mathd.Min(value, other.value));
        /// <summary>
        /// Return the largest of this and another acceleration value.
        /// </summary>
        public readonly Acceleration Max(Acceleration other) => new Acceleration(Mathd.Max(value, other.value));
        /// <summary>
        /// Return the result of clamping this acceleration value between a min and max value.
        /// </summary>
        public readonly Acceleration Clamp(Acceleration min, Acceleration max) => new Acceleration(Mathd.Clamp(value, min.value, max.value));
        /// <summary>
        /// Return this acceleration value rounded  to the nearest integer.
        /// </summary>
        public readonly Acceleration Round() => new Acceleration(Mathd.Round(value));
        /// <summary>
        /// Return this acceleration value rounded down to the nearest integer.
        /// </summary>
        public readonly Acceleration Floor() => new Acceleration(Mathd.Floor(value));
        /// <summary>
        /// Return this acceleration value rounded up to the nearest integer.
        /// </summary>
        public readonly Acceleration Ceil() => new Acceleration(Mathd.Ceil(value));
        /// <summary>
        /// Return the sine of this acceleration value.
        /// </summary>
        public readonly Acceleration Sin() => new Acceleration(Mathd.Sin(value));
        /// <summary>
        /// Return the cosine of this acceleration value.
        /// </summary>
        public readonly Acceleration Cos() => new Acceleration(Mathd.Cos(value));
        /// <summary>
        /// Return the tangent of this acceleration value.
        /// </summary>
        public readonly Acceleration Tan() => new Acceleration(Mathd.Tan(value));

        /// <summary>
        /// Return the sign of a acceleration value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public static int Sign(Acceleration value) => Mathd.Sign(value.value);
        /// <summary>
        /// Return the absolute value of a acceleration value.
        /// </summary>
        public static Acceleration Abs(Acceleration value) => new Acceleration(Mathd.Abs(value.value));
        /// <summary>
        /// Return the integral part of a acceleration value.
        /// </summary>
        public static Acceleration Truncate(Acceleration value) => new Acceleration(Mathd.Truncate(value.value));
        /// <summary>
        /// Return the fractional part of a acceleration value.
        /// </summary>
        public static Acceleration Frac(Acceleration value) => new Acceleration(Mathd.Frac(value.value));
        /// <summary>
        /// Return the absolute distance between two acceleration values.
        /// </summary>
        public static Acceleration Dist(Acceleration a, Acceleration b) => new Acceleration(Mathd.Dist(a.value, b.value));
        /// <summary>
        /// Return the square root of a acceleration value.
        /// </summary>
        public static Acceleration Sqrt(Acceleration value) => new Acceleration(Mathd.Sqrt(value.value));
        /// <summary>
        /// Return the result of raising a acceleration value to the power of two.
        /// </summary>
        public static Acceleration Pow2(Acceleration value) => new Acceleration(Mathd.Pow2(value.value));
        /// <summary>
        /// Return the result of raising a acceleration value to the specified power.
        /// </summary>
        public static Acceleration Pow(Acceleration value, double power) => new Acceleration(Mathd.Pow(value.value, power));
        /// <summary>
        /// Return the smallest of two acceleration values.
        /// </summary>
        public static Acceleration Min(Acceleration a, Acceleration b) => new Acceleration(Mathd.Min(a.value, b.value));
        /// <summary>
        /// Return the largest of two acceleration values.
        /// </summary>
        public static Acceleration Max(Acceleration a, Acceleration b) => new Acceleration(Mathd.Max(a.value, b.value));
        /// <summary>
        /// Return the result of clamping a acceleration value between a min and max value.
        /// </summary>
        public static Acceleration Clamp(Acceleration value, Acceleration min, Acceleration max) => new Acceleration(Mathd.Clamp(value.value, min.value, max.value));
        /// <summary>
        /// Return a acceleration value rounded  to the nearest integer.
        /// </summary>
        public static Acceleration Round(Acceleration value) => new Acceleration(Mathd.Round(value.value));
        /// <summary>
        /// Return a acceleration value rounded down to the nearest integer.
        /// </summary>
        public static Acceleration Floor(Acceleration value) => new Acceleration(Mathd.Floor(value.value));
        /// <summary>
        /// Return a acceleration value rounded up to the nearest integer.
        /// </summary>
        public static Acceleration Ceil(Acceleration value) => new Acceleration(Mathd.Ceil(value.value));
        /// <summary>
        /// Return the sine of a acceleration value.
        /// </summary>
        public static Acceleration Sin(Acceleration value) => new Acceleration(Mathd.Sin(value.value));
        /// <summary>
        /// Return the cosine of a acceleration value.
        /// </summary>
        public static Acceleration Cos(Acceleration value) => new Acceleration(Mathd.Cos(value.value));
        /// <summary>
        /// Return the tangent of a acceleration value.
        /// </summary>
        public static Acceleration Tan(Acceleration value) => new Acceleration(Mathd.Tan(value.value));
        /// <summary>
        /// Return the result of linearly interpolating between two acceleration values, using the specified interpolation factor.
        /// </summary>
        public static Acceleration Lerp(Acceleration min, Acceleration max, double factor) => new Acceleration(Mathd.Lerp(min.value, max.value, factor));

//FORMULAS
    }
}