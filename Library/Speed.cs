using System;

namespace Modules.L0.Quantities
{
    /// <summary>
    /// Represents a speed quantity.
    /// </summary>
    [Serializable]
    public struct Speed
    {
        /* Fields. */
        private double value;

        /* Public properties. */
        public static Speed Zero => new Speed(0.0);
        public static Speed One => new Speed(1.0);

        /* Constructors. */
        public Speed(double value)
        {
            this.value = value;
        }

        /* Casting operators. */
        public static explicit operator short(Speed value) => (short)value.value;
        public static explicit operator int(Speed value) => (int)value.value;
        public static explicit operator long(Speed value) => (long)value.value;
        public static implicit operator float(Speed value) => (float)value.value;
        public static implicit operator double(Speed value) => value.value;
        public static implicit operator Speed(short value) => new Speed(value);
        public static implicit operator Speed(int value) => new Speed(value);
        public static implicit operator Speed(long value) => new Speed(value);
        public static implicit operator Speed(float value) => new Speed(value);
        public static implicit operator Speed(double value) => new Speed(value);

        /* Arithmetic operators. */
        public static Speed operator +(short a, Speed b) => new Speed(a + b.value);
        public static Speed operator +(int a, Speed b) => new Speed(a + b.value);
        public static Speed operator +(long a, Speed b) => new Speed(a + b.value);
        public static Speed operator +(float a, Speed b) => new Speed(a + b.value);
        public static Speed operator +(double a, Speed b) => new Speed(a + b.value);
        public static Speed operator +(Speed a, short b) => new Speed(a.value + b);
        public static Speed operator +(Speed a, int b) => new Speed(a.value + b);
        public static Speed operator +(Speed a, long b) => new Speed(a.value + b);
        public static Speed operator +(Speed a, float b) => new Speed(a.value + b);
        public static Speed operator +(Speed a, double b) => new Speed(a.value + b);
        public static Speed operator +(Speed a, Speed b) => new Speed(a.value + b.value);
        public static Speed operator -(short a, Speed b) => new Speed(a - b.value);
        public static Speed operator -(int a, Speed b) => new Speed(a - b.value);
        public static Speed operator -(long a, Speed b) => new Speed(a - b.value);
        public static Speed operator -(float a, Speed b) => new Speed(a - b.value);
        public static Speed operator -(double a, Speed b) => new Speed(a - b.value);
        public static Speed operator -(Speed a, short b) => new Speed(a.value - b);
        public static Speed operator -(Speed a, int b) => new Speed(a.value - b);
        public static Speed operator -(Speed a, long b) => new Speed(a.value - b);
        public static Speed operator -(Speed a, float b) => new Speed(a.value - b);
        public static Speed operator -(Speed a, double b) => new Speed(a.value - b);
        public static Speed operator -(Speed a, Speed b) => new Speed(a.value - b.value);
        public static Speed operator *(short a, Speed b) => new Speed(a * b.value);
        public static Speed operator *(int a, Speed b) => new Speed(a * b.value);
        public static Speed operator *(long a, Speed b) => new Speed(a * b.value);
        public static Speed operator *(float a, Speed b) => new Speed(a * b.value);
        public static Speed operator *(double a, Speed b) => new Speed(a * b.value);
        public static Speed operator *(Speed a, short b) => new Speed(a.value * b);
        public static Speed operator *(Speed a, int b) => new Speed(a.value * b);
        public static Speed operator *(Speed a, long b) => new Speed(a.value * b);
        public static Speed operator *(Speed a, float b) => new Speed(a.value * b);
        public static Speed operator *(Speed a, double b) => new Speed(a.value * b);
        public static Speed operator *(Speed a, Speed b) => new Speed(a.value * b.value);
        public static Speed operator /(short a, Speed b) => new Speed(a / b.value);
        public static Speed operator /(int a, Speed b) => new Speed(a / b.value);
        public static Speed operator /(long a, Speed b) => new Speed(a / b.value);
        public static Speed operator /(float a, Speed b) => new Speed(a / b.value);
        public static Speed operator /(double a, Speed b) => new Speed(a / b.value);
        public static Speed operator /(Speed a, short b) => new Speed(a.value / b);
        public static Speed operator /(Speed a, int b) => new Speed(a.value / b);
        public static Speed operator /(Speed a, long b) => new Speed(a.value / b);
        public static Speed operator /(Speed a, float b) => new Speed(a.value / b);
        public static Speed operator /(Speed a, double b) => new Speed(a.value / b);
        public static Speed operator /(Speed a, Speed b) => new Speed(a.value / b.value);
        public static Speed operator %(short a, Speed b) => new Speed(a % b.value);
        public static Speed operator %(int a, Speed b) => new Speed(a % b.value);
        public static Speed operator %(long a, Speed b) => new Speed(a % b.value);
        public static Speed operator %(float a, Speed b) => new Speed(a % b.value);
        public static Speed operator %(double a, Speed b) => new Speed(a % b.value);
        public static Speed operator %(Speed a, short b) => new Speed(a.value % b);
        public static Speed operator %(Speed a, int b) => new Speed(a.value % b);
        public static Speed operator %(Speed a, long b) => new Speed(a.value % b);
        public static Speed operator %(Speed a, float b) => new Speed(a.value % b);
        public static Speed operator %(Speed a, double b) => new Speed(a.value % b);
        public static Speed operator %(Speed a, Speed b) => new Speed(a.value % b.value);
        public static Speed operator -(Speed value) => new Speed(-value.value);

        /* Public methods. */
        public readonly override string ToString() => value.ToString();

        /// <summary>
        /// Return the sign of this speed value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public readonly int Sign() => Mathd.Sign(value);
        /// <summary>
        /// Return the absolute value of this speed value.
        /// </summary>
        public readonly Speed Abs() => new Speed(Mathd.Abs(value));
        /// <summary>
        /// Return the integral part of this speed value.
        /// </summary>
        public readonly Speed Truncate() => new Speed(Mathd.Truncate(value));
        /// <summary>
        /// Return the fractional part of this speed value.
        /// </summary>
        public readonly Speed Frac() => new Speed(Mathd.Frac(value));
        /// <summary>
        /// Return the absolute distance between this and another speed value.
        /// </summary>
        public readonly Speed Dist(Speed other) => new Speed(Mathd.Dist(value, other.value));
        /// <summary>
        /// Return the square root of this speed value.
        /// </summary>
        public readonly Speed Sqrt() => new Speed(Mathd.Sqrt(value));
        /// <summary>
        /// Return the result of raising this speed value to the power of two.
        /// </summary>
        public readonly Speed Pow2() => new Speed(Mathd.Pow2(value));
        /// <summary>
        /// Return the result of raising this speed value to the specified power.
        /// </summary>
        public readonly Speed Pow(double power) => new Speed(Mathd.Pow(value, power));
        /// <summary>
        /// Return the smallest of this and another speed value.
        /// </summary>
        public readonly Speed Min(Speed other) => new Speed(Mathd.Min(value, other.value));
        /// <summary>
        /// Return the largest of this and another speed value.
        /// </summary>
        public readonly Speed Max(Speed other) => new Speed(Mathd.Max(value, other.value));
        /// <summary>
        /// Return the result of clamping this speed value between a min and max value.
        /// </summary>
        public readonly Speed Clamp(Speed min, Speed max) => new Speed(Mathd.Clamp(value, min.value, max.value));
        /// <summary>
        /// Return this speed value rounded  to the nearest integer.
        /// </summary>
        public readonly Speed Round() => new Speed(Mathd.Round(value));
        /// <summary>
        /// Return this speed value rounded down to the nearest integer.
        /// </summary>
        public readonly Speed Floor() => new Speed(Mathd.Floor(value));
        /// <summary>
        /// Return this speed value rounded up to the nearest integer.
        /// </summary>
        public readonly Speed Ceil() => new Speed(Mathd.Ceil(value));
        /// <summary>
        /// Return the sine of this speed value.
        /// </summary>
        public readonly Speed Sin() => new Speed(Mathd.Sin(value));
        /// <summary>
        /// Return the cosine of this speed value.
        /// </summary>
        public readonly Speed Cos() => new Speed(Mathd.Cos(value));
        /// <summary>
        /// Return the tangent of this speed value.
        /// </summary>
        public readonly Speed Tan() => new Speed(Mathd.Tan(value));

        /// <summary>
        /// Return the sign of a speed value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public static int Sign(Speed value) => Mathd.Sign(value.value);
        /// <summary>
        /// Return the absolute value of a speed value.
        /// </summary>
        public static Speed Abs(Speed value) => new Speed(Mathd.Abs(value.value));
        /// <summary>
        /// Return the integral part of a speed value.
        /// </summary>
        public static Speed Truncate(Speed value) => new Speed(Mathd.Truncate(value.value));
        /// <summary>
        /// Return the fractional part of a speed value.
        /// </summary>
        public static Speed Frac(Speed value) => new Speed(Mathd.Frac(value.value));
        /// <summary>
        /// Return the absolute distance between two speed values.
        /// </summary>
        public static Speed Dist(Speed a, Speed b) => new Speed(Mathd.Dist(a.value, b.value));
        /// <summary>
        /// Return the square root of a speed value.
        /// </summary>
        public static Speed Sqrt(Speed value) => new Speed(Mathd.Sqrt(value.value));
        /// <summary>
        /// Return the result of raising a speed value to the power of two.
        /// </summary>
        public static Speed Pow2(Speed value) => new Speed(Mathd.Pow2(value.value));
        /// <summary>
        /// Return the result of raising a speed value to the specified power.
        /// </summary>
        public static Speed Pow(Speed value, double power) => new Speed(Mathd.Pow(value.value, power));
        /// <summary>
        /// Return the smallest of two speed values.
        /// </summary>
        public static Speed Min(Speed a, Speed b) => new Speed(Mathd.Min(a.value, b.value));
        /// <summary>
        /// Return the largest of two speed values.
        /// </summary>
        public static Speed Max(Speed a, Speed b) => new Speed(Mathd.Max(a.value, b.value));
        /// <summary>
        /// Return the result of clamping a speed value between a min and max value.
        /// </summary>
        public static Speed Clamp(Speed value, Speed min, Speed max) => new Speed(Mathd.Clamp(value.value, min.value, max.value));
        /// <summary>
        /// Return a speed value rounded  to the nearest integer.
        /// </summary>
        public static Speed Round(Speed value) => new Speed(Mathd.Round(value.value));
        /// <summary>
        /// Return a speed value rounded down to the nearest integer.
        /// </summary>
        public static Speed Floor(Speed value) => new Speed(Mathd.Floor(value.value));
        /// <summary>
        /// Return a speed value rounded up to the nearest integer.
        /// </summary>
        public static Speed Ceil(Speed value) => new Speed(Mathd.Ceil(value.value));
        /// <summary>
        /// Return the sine of a speed value.
        /// </summary>
        public static Speed Sin(Speed value) => new Speed(Mathd.Sin(value.value));
        /// <summary>
        /// Return the cosine of a speed value.
        /// </summary>
        public static Speed Cos(Speed value) => new Speed(Mathd.Cos(value.value));
        /// <summary>
        /// Return the tangent of a speed value.
        /// </summary>
        public static Speed Tan(Speed value) => new Speed(Mathd.Tan(value.value));
        /// <summary>
        /// Return the result of linearly interpolating between two speed values, using the specified interpolation factor.
        /// </summary>
        public static Speed Lerp(Speed min, Speed max, double factor) => new Speed(Mathd.Lerp(min.value, max.value, factor));

        /// <summary>
        /// Calculate speed from distance and time.
        /// </summary>
        public static Speed Calculate(Distance distance, Time time) => (double)distance/(double)time;
    }
}