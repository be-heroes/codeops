using System.Numerics;
using BeHeroes.CodeOps.Abstractions.Strings;

namespace BeHeroes.CodeOps.Abstractions.ExtensionMethods
{
    public static class BigIntegerExtensions
    {
        public static HexString ToHexString(this BigInteger value, bool littleEndian = false)
        {
            if (value == 0) return "0x0";

            var bytes = BitConverter.IsLittleEndian != littleEndian ? value.ToByteArray().Reverse().ToArray() : value.ToByteArray().ToArray();

            var result = (HexString) bytes;

            result.IsLittleEndian = littleEndian;

            return result;
        }

        public static BigInteger ToBigInteger(this HexString hex)
        {
            var encoded = hex.ToByteArray();

            if (BitConverter.IsLittleEndian != hex.IsLittleEndian)
            {
                encoded = encoded.ToArray().Reverse().ToArray();
            }

            return new BigInteger(encoded);
        }

        public static bool IsNegativeZero(this BigInteger value)
        {
            return BigInteger.IsNegative(value) && value == 0;
        }
    }
}
