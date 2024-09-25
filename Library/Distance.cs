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
        /// <summary>
        /// A distance equal to 0.
        /// </summary>
        public static Distance Zero => new Distance(0.0);
        /// <summary>
        /// A distance equal to 1.
        /// </summary>
        public static Distance One => new Distance(1.0);
        /// <summary>
        /// A distance equal to pi.
        /// </summary>
        public static Distance Pi => new Distance(Mathd.Pi);
        /// <summary>
        /// A distance equal to 2 * pi.
        /// </summary>
        public static Distance TwoPi => new Distance(2.0 * Mathd.Pi);

        /* Constructors. */
        public Distance(double value)
        {
            this.value = value;
        }

        /* Casting operators. */
        public static explicit operator byte(Distance value)
        {
            return (byte)value.value;
        }
        public static explicit operator ushort(Distance value)
        {
            return (ushort)value.value;
        }
        public static explicit operator uint(Distance value)
        {
            return (uint)value.value;
        }
        public static explicit operator ulong(Distance value)
        {
            return (ulong)value.value;
        }
        public static explicit operator sbyte(Distance value)
        {
            return (sbyte)value.value;
        }
        public static explicit operator short(Distance value)
        {
            return (short)value.value;
        }
        public static explicit operator int(Distance value)
        {
            return (int)value.value;
        }
        public static explicit operator long(Distance value)
        {
            return (long)value.value;
        }
        public static implicit operator float(Distance value)
        {
            return (float)value.value;
        }
        public static implicit operator double(Distance value)
        {
            return value.value;
        }
        public static explicit operator decimal(Distance value)
        {
            return (decimal)value.value;
        }
        public static implicit operator Distance(byte value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(ushort value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(uint value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(ulong value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(sbyte value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(short value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(int value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(long value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(float value)
        {
            return new Distance(value);
        }
        public static implicit operator Distance(double value)
        {
            return new Distance(value);
        }
        public static explicit operator Distance(decimal value)
        {
            return new Distance((double)value);
        }
        public static explicit operator string(Distance value)
        {
            return value.ToString();
        }

        /* Arithmetic operators. */
        public static Distance operator +(byte a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(ushort a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(uint a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(ulong a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(sbyte a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(short a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(int a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(long a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(float a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(double a, Distance b)
        {
            return new Distance(a + b.value);
        }
        public static Distance operator +(Distance a, byte b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, ushort b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, uint b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, ulong b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, sbyte b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, short b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, int b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, long b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, float b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, double b)
        {
            return new Distance(a.value + b);
        }
        public static Distance operator +(Distance a, Distance b)
        {
            return new Distance(a.value + b.value);
        }
        public static Distance operator -(byte a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(ushort a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(uint a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(ulong a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(sbyte a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(short a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(int a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(long a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(float a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(double a, Distance b)
        {
            return new Distance(a - b.value);
        }
        public static Distance operator -(Distance a, byte b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, ushort b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, uint b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, ulong b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, sbyte b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, short b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, int b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, long b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, float b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, double b)
        {
            return new Distance(a.value - b);
        }
        public static Distance operator -(Distance a, Distance b)
        {
            return new Distance(a.value - b.value);
        }
        public static Distance operator *(byte a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(ushort a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(uint a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(ulong a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(sbyte a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(short a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(int a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(long a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(float a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(double a, Distance b)
        {
            return new Distance(a * b.value);
        }
        public static Distance operator *(Distance a, byte b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, ushort b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, uint b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, ulong b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, sbyte b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, short b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, int b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, long b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, float b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, double b)
        {
            return new Distance(a.value * b);
        }
        public static Distance operator *(Distance a, Distance b)
        {
            return new Distance(a.value * b.value);
        }
        public static Distance operator /(byte a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(ushort a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(uint a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(ulong a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(sbyte a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(short a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(int a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(long a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(float a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(double a, Distance b)
        {
            return new Distance(a / b.value);
        }
        public static Distance operator /(Distance a, byte b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, ushort b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, uint b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, ulong b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, sbyte b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, short b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, int b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, long b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, float b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, double b)
        {
            return new Distance(a.value / b);
        }
        public static Distance operator /(Distance a, Distance b)
        {
            return new Distance(a.value / b.value);
        }
        public static Distance operator %(byte a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(ushort a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(uint a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(ulong a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(sbyte a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(short a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(int a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(long a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(float a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(double a, Distance b)
        {
            return new Distance(a % b.value);
        }
        public static Distance operator %(Distance a, byte b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, ushort b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, uint b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, ulong b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, sbyte b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, short b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, int b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, long b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, float b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, double b)
        {
            return new Distance(a.value % b);
        }
        public static Distance operator %(Distance a, Distance b)
        {
            return new Distance(a.value % b.value);
        }
        public static Distance operator +(Distance value)
        {
            return new Distance(+value.value);
        }
        public static Distance operator -(Distance value)
        {
            return new Distance(-value.value);
        }
        public static Distance operator ++(Distance value)
        {
            return new Distance(++value.value);
        }
        public static Distance operator --(Distance value)
        {
            return new Distance(--value.value);
        }

        public static Speed operator /(Distance a, Time b)
        {
            return new Speed(a.value / (double)b);
        }

        /* Comparison operators. */
        public static bool operator ==(byte a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(ushort a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(uint a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(ulong a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(sbyte a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(short a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(int a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(long a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(float a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(double a, Distance b)
        {
            return a == b.value;
        }
        public static bool operator ==(Distance a, byte b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, ushort b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, uint b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, ulong b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, sbyte b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, short b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, int b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, long b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, float b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, double b)
        {
            return a.value == b;
        }
        public static bool operator ==(Distance a, Distance b)
        {
            return a.value == b.value;
        }
        public static bool operator !=(byte a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(ushort a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(uint a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(ulong a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(sbyte a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(short a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(int a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(long a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(float a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(double a, Distance b)
        {
            return a != b.value;
        }
        public static bool operator !=(Distance a, byte b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, ushort b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, uint b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, ulong b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, sbyte b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, short b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, int b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, long b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, float b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, double b)
        {
            return a.value != b;
        }
        public static bool operator !=(Distance a, Distance b)
        {
            return a.value != b.value;
        }
        public static bool operator >(byte a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(ushort a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(uint a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(ulong a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(sbyte a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(short a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(int a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(long a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(float a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(double a, Distance b)
        {
            return a > b.value;
        }
        public static bool operator >(Distance a, byte b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, ushort b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, uint b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, ulong b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, sbyte b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, short b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, int b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, long b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, float b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, double b)
        {
            return a.value > b;
        }
        public static bool operator >(Distance a, Distance b)
        {
            return a.value > b.value;
        }
        public static bool operator <(byte a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(ushort a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(uint a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(ulong a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(sbyte a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(short a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(int a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(long a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(float a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(double a, Distance b)
        {
            return a < b.value;
        }
        public static bool operator <(Distance a, byte b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, ushort b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, uint b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, ulong b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, sbyte b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, short b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, int b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, long b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, float b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, double b)
        {
            return a.value < b;
        }
        public static bool operator <(Distance a, Distance b)
        {
            return a.value < b.value;
        }
        public static bool operator >=(byte a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(ushort a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(uint a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(ulong a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(sbyte a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(short a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(int a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(long a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(float a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(double a, Distance b)
        {
            return a >= b.value;
        }
        public static bool operator >=(Distance a, byte b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, ushort b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, uint b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, ulong b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, sbyte b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, short b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, int b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, long b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, float b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, double b)
        {
            return a.value >= b;
        }
        public static bool operator >=(Distance a, Distance b)
        {
            return a.value >= b.value;
        }
        public static bool operator <=(byte a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(ushort a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(uint a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(ulong a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(sbyte a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(short a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(int a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(long a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(float a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(double a, Distance b)
        {
            return a <= b.value;
        }
        public static bool operator <=(Distance a, byte b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, ushort b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, uint b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, ulong b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, sbyte b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, short b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, int b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, long b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, float b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, double b)
        {
            return a.value <= b;
        }
        public static bool operator <=(Distance a, Distance b)
        {
            return a.value <= b.value;
        }

        /* Public methods. */
        public override readonly bool Equals(object? obj)
        {
            return obj is Distance distance && this == distance;
        }
        public override readonly int GetHashCode()
        {
            return value.GetHashCode();
        }
        public override readonly string ToString()
        {
            return value.ToString();
        }

        /// <summary>
        /// Return the sign of this distance value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public readonly int Sign()
        {
            return Mathd.Sign(value);
        }
        /// <summary>
        /// Return the absolute value of this distance value.
        /// </summary>
        public readonly Distance Abs()
        {
            return new Distance(Mathd.Abs(value));
        }
        /// <summary>
        /// Return the integral part of this distance value.
        /// </summary>
        public readonly Distance Truncate()
        {
            return new Distance(Mathd.Truncate(value));
        }
        /// <summary>
        /// Return the fractional part of this distance value.
        /// </summary>
        public readonly Distance Frac()
        {
            return new Distance(Mathd.Frac(value));
        }
        /// <summary>
        /// Return the absolute distance between this and another distance value.
        /// </summary>
        public readonly Distance Dist(Distance other)
        {
            return new Distance(Mathd.Dist(value, other.value));
        }
        /// <summary>
        /// Return the square root of this distance value.
        /// </summary>
        public readonly Distance Sqrt()
        {
            return new Distance(Mathd.Sqrt(value));
        }
        /// <summary>
        /// Return the result of raising this distance value to the power of two.
        /// </summary>
        public readonly Distance Pow2()
        {
            return new Distance(Mathd.Pow2(value));
        }
        /// <summary>
        /// Return the result of raising this distance value to the specified power.
        /// </summary>
        public readonly Distance Pow(double power)
        {
            return new Distance(Mathd.Pow(value, power));
        }
        /// <summary>
        /// Return the smallest of this and another distance value.
        /// </summary>
        public readonly Distance Min(Distance other)
        {
            return new Distance(Mathd.Min(value, other.value));
        }
        /// <summary>
        /// Return the largest of this and another distance value.
        /// </summary>
        public readonly Distance Max(Distance other)
        {
            return new Distance(Mathd.Max(value, other.value));
        }
        /// <summary>
        /// Return the result of clamping this distance value between a min and max value.
        /// </summary>
        public readonly Distance Clamp(Distance min, Distance max)
        {
            return new Distance(Mathd.Clamp(value, min.value, max.value));
        }
        /// <summary>
        /// Return this distance value rounded  to the nearest integer.
        /// </summary>
        public readonly Distance Round()
        {
            return new Distance(Mathd.Round(value));
        }
        /// <summary>
        /// Return this distance value rounded down to the nearest integer.
        /// </summary>
        public readonly Distance Floor()
        {
            return new Distance(Mathd.Floor(value));
        }
        /// <summary>
        /// Return this distance value rounded up to the nearest integer.
        /// </summary>
        public readonly Distance Ceil()
        {
            return new Distance(Mathd.Ceil(value));
        }
        /// <summary>
        /// Return the sine of this distance value.
        /// </summary>
        public readonly Distance Sin()
        {
            return new Distance(Mathd.Sin(value));
        }
        /// <summary>
        /// Return the cosine of this distance value.
        /// </summary>
        public readonly Distance Cos()
        {
            return new Distance(Mathd.Cos(value));
        }
        /// <summary>
        /// Return the tangent of this distance value.
        /// </summary>
        public readonly Distance Tan()
        {
            return new Distance(Mathd.Tan(value));
        }
        /// <summary>
        /// Return the result of mapping this distance to the specified, looping range.
        /// </summary>
        public readonly Distance Wrap(Distance min, Distance max)
        {
            return new Distance(Mathd.Wrap(value, min.value, max.value));
        }
        /// <summary>
        /// Return the result of mapping this distance value to the specified, ping-ponging range.
        /// </summary>
        public readonly Distance PingPong(Distance min, Distance max)
        {
            return new Distance(Mathd.PingPong(value, min.value, max.value));
        }
        /// <summary>
        /// Return the result of snapping this distance value to the specified interval.
        /// </summary>
        public readonly Distance Snap(Distance offset, Distance size)
        {
            return new Distance(Mathd.Snap(value, offset.value, size.value));
        }
        /// <summary>
        /// Return the result of mapping this distance value from the specified source range to the specified target range.
        /// </summary>
        public readonly Distance Map(Distance fromMin, Distance fromMax, Distance toMin, Distance toMax)
        {
            return new Distance(Mathd.Map(value, fromMin.value, fromMax.value, toMin.value, toMax.value));
        }
        /// <summary>
        /// Return the result of mapping this distance value from the specified source range to the specified target range.
        /// </summary>
        public readonly Distance Step(Distance to, Distance delta)
        {
            return new Distance(Mathd.Step(value, to.value, delta.value));
        }

        /// <summary>
        /// Move towards some distance value, using a speed and time.
        /// </summary>
        public readonly Distance MoveTowards(Distance to, Speed speed, Time time)
        {
            return Step(to, speed * time);
        }

        /// <summary>
        /// Return the sign of this distance value; -1 if negative, 1 if positive and 0 if equal to 0.
        /// </summary>
        public static int Sign(Distance value)
        {
            return Mathd.Sign(value.value);
        }
        /// <summary>
        /// Return the absolute value of a distance value.
        /// </summary>
        public static Distance Abs(Distance value)
        {
            return new Distance(Mathd.Abs(value.value));
        }
        /// <summary>
        /// Return the integral part of a distance value.
        /// </summary>
        public static Distance Truncate(Distance value)
        {
            return new Distance(Mathd.Truncate(value.value));
        }
        /// <summary>
        /// Return the fractional part of a distance value.
        /// </summary>
        public static Distance Frac(Distance value)
        {
            return new Distance(Mathd.Frac(value.value));
        }
        /// <summary>
        /// Return the absolute distance between two distance values.
        /// </summary>
        public static Distance Dist(Distance a, Distance b)
        {
            return new Distance(Mathd.Dist(a.value, b.value));
        }
        /// <summary>
        /// Return the square root of a distance value.
        /// </summary>
        public static Distance Sqrt(Distance value)
        {
            return new Distance(Mathd.Sqrt(value.value));
        }
        /// <summary>
        /// Return the result of raising a distance value to the power of two.
        /// </summary>
        public static Distance Pow2(Distance value)
        {
            return new Distance(Mathd.Pow2(value.value));
        }
        /// <summary>
        /// Return the result of raising this distance value to the specified power.
        /// </summary>
        public static Distance Pow(Distance value, double power)
        {
            return new Distance(Mathd.Pow(value.value, power));
        }
        /// <summary>
        /// Return the smallest of two distance values.
        /// </summary>
        public static Distance Min(Distance a, Distance b)
        {
            return new Distance(Mathd.Min(a.value, b.value));
        }
        /// <summary>
        /// Return the largest of two distance values.
        /// </summary>
        public static Distance Max(Distance a, Distance b)
        {
            return new Distance(Mathd.Max(a.value, b.value));
        }
        /// <summary>
        /// Return the result of clamping a distance value between a min and max value.
        /// </summary>
        public static Distance Clamp(Distance value, Distance min, Distance max)
        {
            return new Distance(Mathd.Clamp(value.value, min.value, max.value));
        }
        /// <summary>
        /// Return a distance value rounded  to the nearest integer.
        /// </summary>
        public static Distance Round(Distance value)
        {
            return new Distance(Mathd.Round(value.value));
        }
        /// <summary>
        /// Return a distance value rounded down to the nearest integer.
        /// </summary>
        public static Distance Floor(Distance value)
        {
            return new Distance(Mathd.Floor(value.value));
        }
        /// <summary>
        /// Return a distance value rounded up to the nearest integer.
        /// </summary>
        public static Distance Ceil(Distance value)
        {
            return new Distance(Mathd.Ceil(value.value));
        }
        /// <summary>
        /// Return the sine of a distance value.
        /// </summary>
        public static Distance Sin(Distance value)
        {
            return new Distance(Mathd.Sin(value.value));
        }
        /// <summary>
        /// Return the cosine of a distance value.
        /// </summary>
        public static Distance Cos(Distance value)
        {
            return new Distance(Mathd.Cos(value.value));
        }
        /// <summary>
        /// Return the tangent of a distance value.
        /// </summary>
        public static Distance Tan(Distance value)
        {
            return new Distance(Mathd.Tan(value.value));
        }
        /// <summary>
        /// Return the result of mapping an distance to the specified, looping range.
        /// </summary>
        public static Distance Wrap(Distance value, Distance min, Distance max)
        {
            return new Distance(Mathd.Wrap(value.value, min.value, max.value));
        }
        /// <summary>
        /// Return the result of mapping a distance value to the specified, ping-ponging range.
        /// </summary>
        public static Distance PingPong(Distance value, Distance min, Distance max)
        {
            return new Distance(Mathd.PingPong(value.value, min.value, max.value));
        }
        /// <summary>
        /// Return the result of snapping a distance value to the specified interval.
        /// </summary>
        public static Distance Snap(Distance value, Distance min, Distance max)
        {
            return new Distance(Mathd.Snap(value.value, min.value, max.value));
        }
        /// <summary>
        /// Return the result of mapping a distance value from the specified source range to the specified target range.
        /// </summary>
        public static Distance Map(Distance value, Distance fromMin, Distance fromMax, Distance toMin, Distance toMax)
        {
            return new Distance(Mathd.Map(value.value, fromMin.value, fromMax.value, toMin.value, toMax.value));
        }
        /// <summary>
        /// Return the result of moving a distance value towards the target value with some amount. The return value doesn't move past the target value.
        /// </summary>
        public static Distance Step(Distance from, Distance to, Distance delta)
        {
            return new Distance(Mathd.Step(from.value, to.value, delta.value));
        }
        /// <summary>
        /// Return the result of linearly interpolating between two distance values, using the specified interpolation factor.
        /// </summary>
        public static Distance Lerp(Distance min, Distance max, double factor)
        {
            return new Distance(Mathd.Lerp(min.value, max.value, factor));
        }

        /// <summary>
        /// Calculate distance from start speed, end speed and acceleration.
        /// </summary>
        public static Distance CalcFromUVA(Speed startSpeed, Speed endSpeed, Acceleration acceleration)
        {
            return (Mathd.Pow2((double)endSpeed) - Mathd.Pow2((double)startSpeed)) / (2 * (double)acceleration);
        }
        /// <summary>
        /// Calculate distance from start speed, acceleration and time.
        /// </summary>
        public static Distance CalcFromUAT(Speed startSpeed, Acceleration acceleration, Time time)
        {
            return (double)startSpeed * (double)time + 0.5 * (double)acceleration * Mathd.Pow2((double)time);
        }
        /// <summary>
        /// Calculate distance from end speed, acceleration and time.
        /// </summary>
        public static Distance CalcFromVAT(Speed endSpeed, Acceleration acceleration, Time time)
        {
            return (double)endSpeed * (double)time - 0.5 * (double)acceleration * Mathd.Pow2((double)time);
        }
    }
}