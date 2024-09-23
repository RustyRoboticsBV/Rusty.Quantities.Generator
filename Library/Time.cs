using System;

namespace Modules.L0.Quantities
{
    /// <summary>
    /// Represents a time quantity.
    /// </summary>
    [Serializable]
    public struct Time
    {
        /* Fields. */
        private double value;

        /* Public properties. */
        public static Time Zero => new Time(0.0);
        public static Time One => new Time(1.0);

        /* Constructors. */
        public Time(double value)
        {
            this.value = value;
        }

        /* Casting operators. */
        public static explicit operator short(Time value) => (short)value.value;
        public static explicit operator int(Time value) => (int)value.value;
        public static explicit operator long(Time value) => (long)value.value;
        public static implicit operator float(Time value) => (float)value.value;
        public static implicit operator double(Time value) => value.value;
        public static implicit operator Time(short value) => new Time(value);
        public static implicit operator Time(int value) => new Time(value);
        public static implicit operator Time(long value) => new Time(value);
        public static implicit operator Time(float value) => new Time(value);
        public static implicit operator Time(double value) => new Time(value);

        /* Arithmetic operators. */
        public static Time operator +(short a, Time b) => new Time(a + b.value);
        public static Time operator +(int a, Time b) => new Time(a + b.value);
        public static Time operator +(long a, Time b) => new Time(a + b.value);
        public static Time operator +(float a, Time b) => new Time(a + b.value);
        public static Time operator +(double a, Time b) => new Time(a + b.value);
        public static Time operator +(Time a, short b) => new Time(a.value + b);
        public static Time operator +(Time a, int b) => new Time(a.value + b);
        public static Time operator +(Time a, long b) => new Time(a.value + b);
        public static Time operator +(Time a, float b) => new Time(a.value + b);
        public static Time operator +(Time a, double b) => new Time(a.value + b);
        public static Time operator +(Time a, Time b) => new Time(a.value + b.value);
        public static Time operator -(short a, Time b) => new Time(a - b.value);
        public static Time operator -(int a, Time b) => new Time(a - b.value);
        public static Time operator -(long a, Time b) => new Time(a - b.value);
        public static Time operator -(float a, Time b) => new Time(a - b.value);
        public static Time operator -(double a, Time b) => new Time(a - b.value);
        public static Time operator -(Time a, short b) => new Time(a.value - b);
        public static Time operator -(Time a, int b) => new Time(a.value - b);
        public static Time operator -(Time a, long b) => new Time(a.value - b);
        public static Time operator -(Time a, float b) => new Time(a.value - b);
        public static Time operator -(Time a, double b) => new Time(a.value - b);
        public static Time operator -(Time a, Time b) => new Time(a.value - b.value);
        public static Time operator *(short a, Time b) => new Time(a * b.value);
        public static Time operator *(int a, Time b) => new Time(a * b.value);
        public static Time operator *(long a, Time b) => new Time(a * b.value);
        public static Time operator *(float a, Time b) => new Time(a * b.value);
        public static Time operator *(double a, Time b) => new Time(a * b.value);
        public static Time operator *(Time a, short b) => new Time(a.value * b);
        public static Time operator *(Time a, int b) => new Time(a.value * b);
        public static Time operator *(Time a, long b) => new Time(a.value * b);
        public static Time operator *(Time a, float b) => new Time(a.value * b);
        public static Time operator *(Time a, double b) => new Time(a.value * b);
        public static Time operator *(Time a, Time b) => new Time(a.value * b.value);
        public static Time operator /(short a, Time b) => new Time(a / b.value);
        public static Time operator /(int a, Time b) => new Time(a / b.value);
        public static Time operator /(long a, Time b) => new Time(a / b.value);
        public static Time operator /(float a, Time b) => new Time(a / b.value);
        public static Time operator /(double a, Time b) => new Time(a / b.value);
        public static Time operator /(Time a, short b) => new Time(a.value / b);
        public static Time operator /(Time a, int b) => new Time(a.value / b);
        public static Time operator /(Time a, long b) => new Time(a.value / b);
        public static Time operator /(Time a, float b) => new Time(a.value / b);
        public static Time operator /(Time a, double b) => new Time(a.value / b);
        public static Time operator /(Time a, Time b) => new Time(a.value / b.value);
        public static Time operator %(short a, Time b) => new Time(a % b.value);
        public static Time operator %(int a, Time b) => new Time(a % b.value);
        public static Time operator %(long a, Time b) => new Time(a % b.value);
        public static Time operator %(float a, Time b) => new Time(a % b.value);
        public static Time operator %(double a, Time b) => new Time(a % b.value);
        public static Time operator %(Time a, short b) => new Time(a.value % b);
        public static Time operator %(Time a, int b) => new Time(a.value % b);
        public static Time operator %(Time a, long b) => new Time(a.value % b);
        public static Time operator %(Time a, float b) => new Time(a.value % b);
        public static Time operator %(Time a, double b) => new Time(a.value % b);
        public static Time operator %(Time a, Time b) => new Time(a.value % b.value);
        public static Time operator -(Time value) => new Time(-value.value);

        /* Public methods. */
        public readonly override string ToString() => value.ToString();

        /// <summary>
        /// Return the sign of this time value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public readonly int Sign() => Mathd.Sign(value);
        /// <summary>
        /// Return the absolute value of this time value.
        /// </summary>
        public readonly Time Abs() => new Time(Mathd.Abs(value));
        /// <summary>
        /// Return the integral part of this time value.
        /// </summary>
        public readonly Time Truncate() => new Time(Mathd.Truncate(value));
        /// <summary>
        /// Return the fractional part of this time value.
        /// </summary>
        public readonly Time Frac() => new Time(Mathd.Frac(value));
        /// <summary>
        /// Return the absolute distance between this and another time value.
        /// </summary>
        public readonly Time Dist(Time other) => new Time(Mathd.Dist(value, other.value));
        /// <summary>
        /// Return the square root of this time value.
        /// </summary>
        public readonly Time Sqrt() => new Time(Mathd.Sqrt(value));
        /// <summary>
        /// Return the result of raising this time value to the power of two.
        /// </summary>
        public readonly Time Pow2() => new Time(Mathd.Pow2(value));
        /// <summary>
        /// Return the result of raising this time value to the specified power.
        /// </summary>
        public readonly Time Pow(double power) => new Time(Mathd.Pow(value, power));
        /// <summary>
        /// Return the smallest of this and another time value.
        /// </summary>
        public readonly Time Min(Time other) => new Time(Mathd.Min(value, other.value));
        /// <summary>
        /// Return the largest of this and another time value.
        /// </summary>
        public readonly Time Max(Time other) => new Time(Mathd.Max(value, other.value));
        /// <summary>
        /// Return the result of clamping this time value between a min and max value.
        /// </summary>
        public readonly Time Clamp(Time min, Time max) => new Time(Mathd.Clamp(value, min.value, max.value));
        /// <summary>
        /// Return this time value rounded  to the nearest integer.
        /// </summary>
        public readonly Time Round() => new Time(Mathd.Round(value));
        /// <summary>
        /// Return this time value rounded down to the nearest integer.
        /// </summary>
        public readonly Time Floor() => new Time(Mathd.Floor(value));
        /// <summary>
        /// Return this time value rounded up to the nearest integer.
        /// </summary>
        public readonly Time Ceil() => new Time(Mathd.Ceil(value));
        /// <summary>
        /// Return the sine of this time value.
        /// </summary>
        public readonly Time Sin() => new Time(Mathd.Sin(value));
        /// <summary>
        /// Return the cosine of this time value.
        /// </summary>
        public readonly Time Cos() => new Time(Mathd.Cos(value));
        /// <summary>
        /// Return the tangent of this time value.
        /// </summary>
        public readonly Time Tan() => new Time(Mathd.Tan(value));

        /// <summary>
        /// Return the sign of a time value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public static int Sign(Time value) => Mathd.Sign(value.value);
        /// <summary>
        /// Return the absolute value of a time value.
        /// </summary>
        public static Time Abs(Time value) => new Time(Mathd.Abs(value.value));
        /// <summary>
        /// Return the integral part of a time value.
        /// </summary>
        public static Time Truncate(Time value) => new Time(Mathd.Truncate(value.value));
        /// <summary>
        /// Return the fractional part of a time value.
        /// </summary>
        public static Time Frac(Time value) => new Time(Mathd.Frac(value.value));
        /// <summary>
        /// Return the absolute distance between two time values.
        /// </summary>
        public static Time Dist(Time a, Time b) => new Time(Mathd.Dist(a.value, b.value));
        /// <summary>
        /// Return the square root of a time value.
        /// </summary>
        public static Time Sqrt(Time value) => new Time(Mathd.Sqrt(value.value));
        /// <summary>
        /// Return the result of raising a time value to the power of two.
        /// </summary>
        public static Time Pow2(Time value) => new Time(Mathd.Pow2(value.value));
        /// <summary>
        /// Return the result of raising a time value to the specified power.
        /// </summary>
        public static Time Pow(Time value, double power) => new Time(Mathd.Pow(value.value, power));
        /// <summary>
        /// Return the smallest of two time values.
        /// </summary>
        public static Time Min(Time a, Time b) => new Time(Mathd.Min(a.value, b.value));
        /// <summary>
        /// Return the largest of two time values.
        /// </summary>
        public static Time Max(Time a, Time b) => new Time(Mathd.Max(a.value, b.value));
        /// <summary>
        /// Return the result of clamping a time value between a min and max value.
        /// </summary>
        public static Time Clamp(Time value, Time min, Time max) => new Time(Mathd.Clamp(value.value, min.value, max.value));
        /// <summary>
        /// Return a time value rounded  to the nearest integer.
        /// </summary>
        public static Time Round(Time value) => new Time(Mathd.Round(value.value));
        /// <summary>
        /// Return a time value rounded down to the nearest integer.
        /// </summary>
        public static Time Floor(Time value) => new Time(Mathd.Floor(value.value));
        /// <summary>
        /// Return a time value rounded up to the nearest integer.
        /// </summary>
        public static Time Ceil(Time value) => new Time(Mathd.Ceil(value.value));
        /// <summary>
        /// Return the sine of a time value.
        /// </summary>
        public static Time Sin(Time value) => new Time(Mathd.Sin(value.value));
        /// <summary>
        /// Return the cosine of a time value.
        /// </summary>
        public static Time Cos(Time value) => new Time(Mathd.Cos(value.value));
        /// <summary>
        /// Return the tangent of a time value.
        /// </summary>
        public static Time Tan(Time value) => new Time(Mathd.Tan(value.value));
        /// <summary>
        /// Return the result of linearly interpolating between two time values, using the specified interpolation factor.
        /// </summary>
        public static Time Lerp(Time min, Time max, double factor) => new Time(Mathd.Lerp(min.value, max.value, factor));

//FORMULAS
    }
}