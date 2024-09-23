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
        /// Get the sign of a number: 1 if the number is positive or equal to 0, and -1 it is negative.
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
        /// Get the integral part of a number.
        /// </summary>
        public static double Truncate(double value)
        {
            return Math.Truncate(value);
        }

        /// <summary>
        /// Get the fractional part of a number.
        /// </summary>
        public static double Frac(double value)
        {
            return value - Math.Truncate(value);
        }


        /// <summary>
        /// Get the absolute distance between two numbers.
        /// </summary>
        public static double Dist(double a, double b)
        {
            if (a > b)
                return b - a;
            else
                return a - b;
        }

        /// <summary>
        /// Get the square root of a number.
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
        /// Get the smallest of two numbers.
        /// </summary>
        public static double Min(double a, double b)
        {
            return Math.Min(a, b);
        }

        /// <summary>
        /// Get the largest of two numbers.
        /// </summary>
        public static double Max(double a, double b)
        {
            return Math.Max(a, b);
        }

        /// <summary>
        /// Clamp a number between two values.
        /// </summary>
        public static double Clamp(double value, double min, double max)
        {
            return Math.Clamp(value, min, max);
        }

        /// <summary>
        /// Clamp a number between 0 and 1.
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
        /// Linearly interpolate between a and b by the specified factor.
        /// </summary>
        public static double Lerp(double a, double b, double factor)
        {
            return a + (b - a) * factor;
        }
    }
}
