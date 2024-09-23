using System;

namespace Modules.L0.Quantities
{
    /// <summary>
    /// Represents a distance quantity.
    /// </summary>
    [Serializable]
    public struct Distance
    {
        /* Fields. */
        private double value;

        /* Public properties. */
        public static Distance Zero => new Distance(0.0);
        public static Distance One => new Distance(1.0);

        /* Constructors. */
        public Distance(double value)
        {
            this.value = value;
        }

        /* Casting operators. */
        public static explicit operator short(Distance value) => (short)value.value;
        public static explicit operator int(Distance value) => (int)value.value;
        public static explicit operator long(Distance value) => (long)value.value;
        public static implicit operator float(Distance value) => (float)value.value;
        public static implicit operator double(Distance value) => value.value;
        public static implicit operator Distance(short value) => new Distance(value);
        public static implicit operator Distance(int value) => new Distance(value);
        public static implicit operator Distance(long value) => new Distance(value);
        public static implicit operator Distance(float value) => new Distance(value);
        public static implicit operator Distance(double value) => new Distance(value);

        /* Arithmetic operators. */
        public static Distance operator +(short a, Distance b) => new Distance(a + b.value);
        public static Distance operator +(int a, Distance b) => new Distance(a + b.value);
        public static Distance operator +(long a, Distance b) => new Distance(a + b.value);
        public static Distance operator +(float a, Distance b) => new Distance(a + b.value);
        public static Distance operator +(double a, Distance b) => new Distance(a + b.value);
        public static Distance operator +(Distance a, short b) => new Distance(a.value + b);
        public static Distance operator +(Distance a, int b) => new Distance(a.value + b);
        public static Distance operator +(Distance a, long b) => new Distance(a.value + b);
        public static Distance operator +(Distance a, float b) => new Distance(a.value + b);
        public static Distance operator +(Distance a, double b) => new Distance(a.value + b);
        public static Distance operator +(Distance a, Distance b) => new Distance(a.value + b.value);
        public static Distance operator -(short a, Distance b) => new Distance(a - b.value);
        public static Distance operator -(int a, Distance b) => new Distance(a - b.value);
        public static Distance operator -(long a, Distance b) => new Distance(a - b.value);
        public static Distance operator -(float a, Distance b) => new Distance(a - b.value);
        public static Distance operator -(double a, Distance b) => new Distance(a - b.value);
        public static Distance operator -(Distance a, short b) => new Distance(a.value - b);
        public static Distance operator -(Distance a, int b) => new Distance(a.value - b);
        public static Distance operator -(Distance a, long b) => new Distance(a.value - b);
        public static Distance operator -(Distance a, float b) => new Distance(a.value - b);
        public static Distance operator -(Distance a, double b) => new Distance(a.value - b);
        public static Distance operator -(Distance a, Distance b) => new Distance(a.value - b.value);
        public static Distance operator *(short a, Distance b) => new Distance(a * b.value);
        public static Distance operator *(int a, Distance b) => new Distance(a * b.value);
        public static Distance operator *(long a, Distance b) => new Distance(a * b.value);
        public static Distance operator *(float a, Distance b) => new Distance(a * b.value);
        public static Distance operator *(double a, Distance b) => new Distance(a * b.value);
        public static Distance operator *(Distance a, short b) => new Distance(a.value * b);
        public static Distance operator *(Distance a, int b) => new Distance(a.value * b);
        public static Distance operator *(Distance a, long b) => new Distance(a.value * b);
        public static Distance operator *(Distance a, float b) => new Distance(a.value * b);
        public static Distance operator *(Distance a, double b) => new Distance(a.value * b);
        public static Distance operator *(Distance a, Distance b) => new Distance(a.value * b.value);
        public static Distance operator /(short a, Distance b) => new Distance(a / b.value);
        public static Distance operator /(int a, Distance b) => new Distance(a / b.value);
        public static Distance operator /(long a, Distance b) => new Distance(a / b.value);
        public static Distance operator /(float a, Distance b) => new Distance(a / b.value);
        public static Distance operator /(double a, Distance b) => new Distance(a / b.value);
        public static Distance operator /(Distance a, short b) => new Distance(a.value / b);
        public static Distance operator /(Distance a, int b) => new Distance(a.value / b);
        public static Distance operator /(Distance a, long b) => new Distance(a.value / b);
        public static Distance operator /(Distance a, float b) => new Distance(a.value / b);
        public static Distance operator /(Distance a, double b) => new Distance(a.value / b);
        public static Distance operator /(Distance a, Distance b) => new Distance(a.value / b.value);
        public static Distance operator %(short a, Distance b) => new Distance(a % b.value);
        public static Distance operator %(int a, Distance b) => new Distance(a % b.value);
        public static Distance operator %(long a, Distance b) => new Distance(a % b.value);
        public static Distance operator %(float a, Distance b) => new Distance(a % b.value);
        public static Distance operator %(double a, Distance b) => new Distance(a % b.value);
        public static Distance operator %(Distance a, short b) => new Distance(a.value % b);
        public static Distance operator %(Distance a, int b) => new Distance(a.value % b);
        public static Distance operator %(Distance a, long b) => new Distance(a.value % b);
        public static Distance operator %(Distance a, float b) => new Distance(a.value % b);
        public static Distance operator %(Distance a, double b) => new Distance(a.value % b);
        public static Distance operator %(Distance a, Distance b) => new Distance(a.value % b.value);
        public static Distance operator -(Distance value) => new Distance(-value.value);

        /* Public methods. */
        public readonly override string ToString() => value.ToString();

        /// <summary>
        /// Return the sign of this distance value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public readonly int Sign() => Mathd.Sign(value);
        /// <summary>
        /// Return the absolute value of this distance value.
        /// </summary>
        public readonly Distance Abs() => new Distance(Mathd.Abs(value));
        /// <summary>
        /// Return the integral part of this distance value.
        /// </summary>
        public readonly Distance Truncate() => new Distance(Mathd.Truncate(value));
        /// <summary>
        /// Return the fractional part of this distance value.
        /// </summary>
        public readonly Distance Frac() => new Distance(Mathd.Frac(value));
        /// <summary>
        /// Return the absolute distance between this and another distance value.
        /// </summary>
        public readonly Distance Dist(Distance other) => new Distance(Mathd.Dist(value, other.value));
        /// <summary>
        /// Return the square root of this distance value.
        /// </summary>
        public readonly Distance Sqrt() => new Distance(Mathd.Sqrt(value));
        /// <summary>
        /// Return the result of raising this distance value to the power of two.
        /// </summary>
        public readonly Distance Pow2() => new Distance(Mathd.Pow2(value));
        /// <summary>
        /// Return the result of raising this distance value to the specified power.
        /// </summary>
        public readonly Distance Pow(double power) => new Distance(Mathd.Pow(value, power));
        /// <summary>
        /// Return the smallest of this and another distance value.
        /// </summary>
        public readonly Distance Min(Distance other) => new Distance(Mathd.Min(value, other.value));
        /// <summary>
        /// Return the largest of this and another distance value.
        /// </summary>
        public readonly Distance Max(Distance other) => new Distance(Mathd.Max(value, other.value));
        /// <summary>
        /// Return the result of clamping this distance value between a min and max value.
        /// </summary>
        public readonly Distance Clamp(Distance min, Distance max) => new Distance(Mathd.Clamp(value, min.value, max.value));
        /// <summary>
        /// Return this distance value rounded  to the nearest integer.
        /// </summary>
        public readonly Distance Round() => new Distance(Mathd.Round(value));
        /// <summary>
        /// Return this distance value rounded down to the nearest integer.
        /// </summary>
        public readonly Distance Floor() => new Distance(Mathd.Floor(value));
        /// <summary>
        /// Return this distance value rounded up to the nearest integer.
        /// </summary>
        public readonly Distance Ceil() => new Distance(Mathd.Ceil(value));
        /// <summary>
        /// Return the sine of this distance value.
        /// </summary>
        public readonly Distance Sin() => new Distance(Mathd.Sin(value));
        /// <summary>
        /// Return the cosine of this distance value.
        /// </summary>
        public readonly Distance Cos() => new Distance(Mathd.Cos(value));
        /// <summary>
        /// Return the tangent of this distance value.
        /// </summary>
        public readonly Distance Tan() => new Distance(Mathd.Tan(value));

        /// <summary>
        /// Return the sign of a distance value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public static int Sign(Distance value) => Mathd.Sign(value.value);
        /// <summary>
        /// Return the absolute value of a distance value.
        /// </summary>
        public static Distance Abs(Distance value) => new Distance(Mathd.Abs(value.value));
        /// <summary>
        /// Return the integral part of a distance value.
        /// </summary>
        public static Distance Truncate(Distance value) => new Distance(Mathd.Truncate(value.value));
        /// <summary>
        /// Return the fractional part of a distance value.
        /// </summary>
        public static Distance Frac(Distance value) => new Distance(Mathd.Frac(value.value));
        /// <summary>
        /// Return the absolute distance between two distance values.
        /// </summary>
        public static Distance Dist(Distance a, Distance b) => new Distance(Mathd.Dist(a.value, b.value));
        /// <summary>
        /// Return the square root of a distance value.
        /// </summary>
        public static Distance Sqrt(Distance value) => new Distance(Mathd.Sqrt(value.value));
        /// <summary>
        /// Return the result of raising a distance value to the power of two.
        /// </summary>
        public static Distance Pow2(Distance value) => new Distance(Mathd.Pow2(value.value));
        /// <summary>
        /// Return the result of raising a distance value to the specified power.
        /// </summary>
        public static Distance Pow(Distance value, double power) => new Distance(Mathd.Pow(value.value, power));
        /// <summary>
        /// Return the smallest of two distance values.
        /// </summary>
        public static Distance Min(Distance a, Distance b) => new Distance(Mathd.Min(a.value, b.value));
        /// <summary>
        /// Return the largest of two distance values.
        /// </summary>
        public static Distance Max(Distance a, Distance b) => new Distance(Mathd.Max(a.value, b.value));
        /// <summary>
        /// Return the result of clamping a distance value between a min and max value.
        /// </summary>
        public static Distance Clamp(Distance value, Distance min, Distance max) => new Distance(Mathd.Clamp(value.value, min.value, max.value));
        /// <summary>
        /// Return a distance value rounded  to the nearest integer.
        /// </summary>
        public static Distance Round(Distance value) => new Distance(Mathd.Round(value.value));
        /// <summary>
        /// Return a distance value rounded down to the nearest integer.
        /// </summary>
        public static Distance Floor(Distance value) => new Distance(Mathd.Floor(value.value));
        /// <summary>
        /// Return a distance value rounded up to the nearest integer.
        /// </summary>
        public static Distance Ceil(Distance value) => new Distance(Mathd.Ceil(value.value));
        /// <summary>
        /// Return the sine of a distance value.
        /// </summary>
        public static Distance Sin(Distance value) => new Distance(Mathd.Sin(value.value));
        /// <summary>
        /// Return the cosine of a distance value.
        /// </summary>
        public static Distance Cos(Distance value) => new Distance(Mathd.Cos(value.value));
        /// <summary>
        /// Return the tangent of a distance value.
        /// </summary>
        public static Distance Tan(Distance value) => new Distance(Mathd.Tan(value.value));
        /// <summary>
        /// Return the result of linearly interpolating between two distance values, using the specified interpolation factor.
        /// </summary>
        public static Distance Lerp(Distance min, Distance max, double factor) => new Distance(Mathd.Lerp(min.value, max.value, factor));

//FORMULAS
    }
}