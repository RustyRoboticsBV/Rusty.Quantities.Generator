using System;

namespace Modules.L0.Quantities
{
    /// <summary>
    /// Contains math methods and constants for doubles.
    /// </summary>
    internal static class Mathd
    {
        /* Constants. */
        public const double Pi = 3.1415926535897932384626433832795028841971693993751058209749445923078164062d;
        /// <summary>
        /// Degrees to radians constant.
        /// </summary>
        public const double Deg2Rad = Pi / 180d;
        /// <summary>
        /// Radians to degrees constant.
        /// </summary>
        public const double Rad2Deg = 1d / Deg2Rad;

        /* Public methods. */
        /// <summary>
        /// Return the sign of a number: 1 if the number is positive or equal to 0, and -1 it is negative.
        /// </summary>
        public static int Sign(double value)
        {
            return Math.Sign(value);
        }

        /// <summary>
        /// Remove the sign of a number.
        /// </summary>
        public static double Abs(double value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Return the integral part of a number.
        /// </summary>
        public static double Truncate(double value)
        {
            return Math.Truncate(value);
        }

        /// <summary>
        /// Return the fractional part of a number.
        /// </summary>
        public static double Frac(double value)
        {
            return value - Math.Truncate(value);
        }


        /// <summary>
        /// Return the absolute distance between two numbers.
        /// </summary>
        public static double Dist(double a, double b)
        {
            if (a > b)
                return b - a;
            else
                return a - b;
        }

        /// <summary>
        /// Return the square root of a number.
        /// </summary>
        public static double Sqrt(double value)
        {
            return Math.Sqrt(value);
        }

        /// <summary>
        /// Returns the specified number raised to the power of two.
        /// </summary>
        public static double Pow2(double value)
        {
            return value * value;
        }

        /// <summary>
        /// Returns the specified number raised to the specified power.
        /// </summary>
        public static double Pow(double value, double power)
        {
            return Math.Pow(value, power);
        }

        /// <summary>
        /// Returns the base two logarithm of the specified number.
        /// </summary>
        public static double Log2(double value)
        {
            return Math.Log2(value);
        }

        /// <summary>
        /// Returns the base ten logarithm of the specified number.
        /// </summary>
        public static double Log10(double value)
        {
            return Math.Log10(value);
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of the specified number.
        /// </summary>
        public static double Ln(double value)
        {
            return Math.Log(value);
        }


        /// <summary>
        /// Return the smallest of two numbers.
        /// </summary>
        public static double Min(double a, double b)
        {
            return Math.Min(a, b);
        }

        /// <summary>
        /// Return the largest of two numbers.
        /// </summary>
        public static double Max(double a, double b)
        {
            return Math.Max(a, b);
        }

        /// <summary>
        /// Return the result of clamping a number between two values.
        /// </summary>
        public static double Clamp(double value, double min, double max)
        {
            return Math.Clamp(value, min, max);
        }

        /// <summary>
        /// Return the result of clamping a number between 0 and 1.
        /// </summary>
        public static double Clamp01(double value)
        {
            return Clamp(value, 0d, 1d);
        }


        /// <summary>
        /// Round a number to the nearest integer.
        /// </summary>
        public static double Round(double value)
        {
            return Math.Round(value);
        }

        /// <summary>
        /// Round a number down to the nearest integer.
        /// </summary>
        public static double Floor(double value)
        {
            return Math.Floor(value);
        }

        /// <summary>
        /// Round a number up to the next integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Ceil(double value)
        {
            return Math.Ceiling(value);
        }


        /// <summary>
        /// Return the result of mapping a number into a looping range between the specified min and max.
        /// </summary>
        public static double Wrap(double value, double min, double max)
        {
            double relVal = value - min;
            double length = max - min;
            if (length < 0)
                throw new ArgumentException("length < 0");
            if (relVal < 0.0)
                return min + (length - relVal) % length;
            else
                return min + relVal % length;
        }

        /// <summary>
        /// Return the result of mapping a number into a ping-ponging range between the specified min and max.
        /// </summary>
        public static double PingPong(double value, double min, double max)
        {
            double length = max - min;
            if (length < 0)
                throw new ArgumentException("length < 0");
            if (length == 0)
                return min;

            double relVal = Abs(min - value);

            bool isEven = (byte)(Floor(relVal / length) % 2.0) == 0;

            if (isEven)
                return min + relVal % length;
            else
                return max - relVal % length;
        }

        /// <summary>
        /// Return the result of snapping a number to some interval.
        /// </summary>
        public static double Snap(double value, double offset, double size)
        {
            double relVal = value - offset;
            double mod = relVal % size;
            int step = (int)(relVal / size);
            if (mod < 0.5 * size)
                return offset + step * size;
            else
                return offset + (step + 1) * size;
        }

        /// <summary>
        /// Return the result of linearly mapping a value from a specified range to another specified range.
        /// </summary>
        public static double Map(double value, double fromMin, double fromMax, double toMin, double toMax)
        {
            double proportion = (value - fromMin) / (fromMax - fromMin);
            return toMin + proportion * (toMax - toMin);
        }


        /// <summary>
        /// Returns the sine of the specified number.
        /// </summary>
        public static double Sin(double value)
        {
            return Math.Sin(value);
        }

        /// <summary>
        /// Returns the cosine of the specified number.
        /// </summary>
        public static double Cos(double value)
        {
            return Math.Cos(value);
        }

        /// <summary>
        /// Returns the tangent of the specified number.
        /// </summary>
        public static double Tan(double value)
        {
            return Math.Tan(value);
        }


        /// <summary>
        /// Return the result of stepping from the specified number towards another specified number, with some distance. The
        /// return value cannot pass through the destination number.
        /// </summary>
        public static double Step(double from, double to, double delta)
        {
            if (from < to)
                return Min(from + delta, to);
            else if (from > to)
                return Max(from - delta, to);
            else
                return to;
        }

        /// <summary>
        /// Linearly interpolate between a and b by the specified factor.
        /// </summary>
        public static double Lerp(double a, double b, double factor)
        {
            return a + (b - a) * factor;
        }
    }
}
