using System.Globalization;
using System.Numerics;
using System.Text;
using BeHeroes.CodeOps.Abstractions.ExtensionMethods;

namespace BeHeroes.CodeOps.Abstractions.Numerics
{
    public readonly struct BigDecimal : IComparable<BigDecimal>, IEquatable<BigDecimal>
    {
        public const int MaxPrecision = 1000;

        static readonly BigInteger DecimalMaxValue = new BigInteger(decimal.MaxValue);

        internal readonly BigInteger Seed;

        internal readonly int Precision;
        
        public BigDecimal(BigInteger seed, int precision)
        {
            if (precision > MaxPrecision)
                throw new ArgumentException($"Maximum precision is {MaxPrecision}", nameof(precision));

            Seed = seed;
            Precision = precision;
        }

        public BigDecimal(decimal dec)
        {
            Span<byte> decimalBytes = stackalloc byte[sizeof(decimal)];
            var maxIndex = decimalBytes.CopyDecimalBigEndian(dec);
            var newSeed = BigInteger.Zero;

            Precision = decimalBytes[2];

            for (var index = 4; index <= maxIndex; index++)
            {
                newSeed <<= 8;
                newSeed += decimalBytes[index];
            }

            Seed = (decimalBytes[3] & 0x80) > 0 ? BigInteger.Negate(newSeed) : newSeed;
        }

        public static bool operator >(BigDecimal left, BigDecimal right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(BigDecimal left, BigDecimal right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator ==(BigDecimal left, BigDecimal right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BigDecimal left, BigDecimal right)
        {
            return !(left == right);
        }

        public static BigDecimal operator +(BigDecimal left, BigDecimal right)
        {
            var maxPrecision = left.Precision;
            var diffPrecision = left.Precision - right.Precision;
            var leftValue = left.Seed;
            var rightValue = right.Seed;

            if (diffPrecision < 0)
            {
                maxPrecision = right.Precision;
                leftValue = BigInteger.Multiply(leftValue, BigInteger.Pow(10, -diffPrecision));
            }
            else if (diffPrecision > 0)
            {
                rightValue = BigInteger.Multiply(rightValue, BigInteger.Pow(10, diffPrecision));
            }

            return new BigDecimal(BigInteger.Add(leftValue, rightValue), maxPrecision);
        }

        public static BigDecimal operator -(BigDecimal left, BigDecimal right)
        {
            return left + (-right);
        }

        public static BigDecimal operator *(BigDecimal left, BigDecimal right)
        {
            return new BigDecimal(BigInteger.Multiply(left.Seed, right.Seed), left.Precision + right.Precision);
        }

        public static BigDecimal operator /(BigDecimal left, BigDecimal right)
        {
            if (left.Seed == 0)
            {
                throw new DivideByZeroException();
            }

            var maxPrecision = Math.Max(left.Precision, right.Precision);
            var leftValue = left.Seed;
            var rightValue = right.Seed;

            if (left.Precision < maxPrecision)
            {
                leftValue *= BigInteger.Pow(10, maxPrecision - left.Precision);
            }

            if (right.Precision < maxPrecision)
            {
                rightValue *= BigInteger.Pow(10, maxPrecision - right.Precision);
            }

            var newSeed = BigInteger.DivRem(leftValue, rightValue, out var remains);
            var newPrecision = 0;

            while (remains != 0 && newPrecision < maxPrecision)
            {
                // increment the new precision to fit the remains
                while (BigInteger.Abs(remains) < BigInteger.Abs(rightValue))
                {
                    remains *= 10;
                    newPrecision++;
                    newSeed *= 10;
                }

                newSeed += BigInteger.DivRem(remains, rightValue, out remains);
            }

            return new BigDecimal(newSeed, newPrecision);
        }

        public static BigDecimal operator -(BigDecimal left)
        {
            return new BigDecimal(BigInteger.Negate(left.Seed), left.Precision);
        }

        public static bool CheckNegativeZero(decimal dec)
        {
            if (dec != 0)
            {
                return false;
            }

            unsafe
            {
                var p = (byte*)&dec;
                return (p[3] & 0b_1000_0000) > 0;
            }
        }

        public static bool TryParse(string text, out BigDecimal result) => TryParse(text.AsSpan(), out result);

        public static bool TryParse(ReadOnlySpan<char> text, out BigDecimal result)
        {
            try
            {
                result = Parse(text);
                return true;
            }
            catch (FormatException)
            {
                result = default;
                return false;
            }
            catch (OverflowException)
            {
                result = default;
                return false;
            }
        }

        public static BigDecimal Parse(string text) => Parse(text.AsSpan());

        public static BigDecimal Parse(ReadOnlySpan<char> text)
        {
            const short sStart = 0, sSeed = 1, sDecimal = 2, sExpStart = 3, sExp = 4;

            var isNegative = false;
            var expNegative = false;
            var started = false;
            var state = sStart;
            BigInteger seed = 0;
            var precision = 0;
            var exponent = 0;
            foreach (var c in text)
            {
                switch (state)
                {
                    case sStart:
                        if (c == '-')
                        {
                            if (started)
                            {
                                throw new FormatException($"Invalid decimal: {text.ToString()}");
                            }

                            started = true;
                            isNegative = true;
                            break;
                        }
                        else if (c == '+')
                        {
                            if (started)
                            {
                                throw new FormatException($"Invalid decimal: {text.ToString()}");
                            }

                            started = true;
                            break;
                        }

                        state = sSeed;
                        goto case sSeed;
                    case sSeed:
                        if (c == '.')
                        {
                            state = sDecimal;
                            break;
                        }

                        if (c == 'd' || c == 'D')
                        {
                            started = false;
                            state = sExpStart;
                            break;
                        }

                        if (!char.IsDigit(c))
                        {                            
                            throw new FormatException($"Invalid decimal: {text.ToString()}");
                        }

                        seed = (seed * 10) + (isNegative ? '0' - c : c - '0');
                        break;
                    case sDecimal:
                        if (c == 'd' || c == 'D')
                        {
                            started = false;
                            state = sExpStart;
                            break;
                        }

                        if (!char.IsDigit(c))
                        {
                            throw new FormatException($"Invalid decimal: {text.ToString()}");
                        }

                        seed = (seed * 10) + (isNegative ? '0' - c : c - '0');
                        precision++;
                        break;
                    case sExpStart:
                        if (c == '-')
                        {
                            if (started)
                            {
                                throw new FormatException($"Invalid decimal: {text.ToString()}");
                            }

                            started = true;

                            expNegative = true;
                            break;
                        }
                        else if (c == '+')
                        {
                            if (started)
                            {
                                throw new FormatException($"Invalid decimal: {text.ToString()}");
                            }

                            started = true;
                            break;
                        }

                        state = sExp;
                        goto case sExp;
                    case sExp:
                        if (!char.IsDigit(c))
                        {
                            throw new FormatException($"Invalid decimal: {text.ToString()}");
                        }

                        exponent = (exponent * 10) + (expNegative ? '0' - c : c - '0');
                        break;                    
                    default:
                        throw new InvalidOperationException("Parse failed unexpectedly");
                }
            }

            if (state == sStart || state == sExpStart)
            {
                throw new FormatException($"Invalid decimal: {text.ToString()}");
            }

            if (seed == 0 && isNegative)
            {
                return NegativeZero(precision - exponent);
            }

            return new BigDecimal(seed, precision - exponent);
        }

        public static BigDecimal NegativeZero(int precision = 0) => new BigDecimal(BigInteger.Negate(0), precision);

        public static BigDecimal Zero(int precision = 0) => new BigDecimal(0, precision);

        public int CompareTo(BigDecimal other)
        {
            var diffPrecision = Precision - other.Precision;

            if (diffPrecision == 0)
            {
                return BigInteger.Compare(Seed, other.Seed);
            }

            if (diffPrecision < 0)
            {
                return BigInteger.Multiply(Seed, BigInteger.Pow(10, -diffPrecision)).CompareTo(other.Seed);
            }

            // pdiff > 0
            return BigInteger.Compare(Seed, BigInteger.Multiply(other.Seed, BigInteger.Pow(10, diffPrecision)));
        }

        public bool Equals(BigDecimal other) => CompareTo(other) == 0;

        public decimal ToDecimal()
        {
            var seed = Seed;
            var precision = Precision;

            while (BigInteger.Abs(seed) > DecimalMaxValue && precision > 0)
            {
                seed /= 10;
                precision--;
            }

            // this will check for overflowing if |intVal| > DecimalMaxValue
            var dec = (decimal)seed;

            // this will account for the case where Precision < 0
            if (precision < 0)
            {
                dec *= (decimal)Math.Pow(10, -precision);
                precision = 0;
            }

            while (precision > 0)
            {
                var step = precision > 28 ? 28 : precision;
                dec /= (decimal)Math.Pow(10, step);
                precision -= step;
            }

            return dec;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is BigDecimal other && Equals(other);
        }

        public override int GetHashCode() => (int)((Precision + (31 * (long)Seed.GetHashCode())) % 2147483647);

        public override string ToString()
        {
            if (Seed.IsNegativeZero())
            {
                return "-0d" + (-Precision);
            }

            var builder = new StringBuilder(Seed.ToString(CultureInfo.InvariantCulture));

            if (Precision == 0)
            {
                builder.Append("d0");
            }
            else if (Precision < 0)
            {
                // write the string as {mag}d{-scale}
                builder.Append('d');
                builder.Append(-Precision);
            }
            else
            {
                var smallestDotIndex = builder[0] == '-' ? 2 : 1;

                if (builder.Length - Precision >= smallestDotIndex)
                {
                    builder.Insert(builder.Length - Precision, '.');
                }
                else
                {
                    var d = Precision - (builder.Length - smallestDotIndex);

                    builder.Insert(smallestDotIndex, '.');
                    builder.Append('d');
                    builder.Append((-d).ToString(CultureInfo.InvariantCulture));
                }
            }

            return builder.ToString();
        }
    }
}