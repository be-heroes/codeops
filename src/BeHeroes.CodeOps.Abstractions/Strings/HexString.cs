using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using BeHeroes.CodeOps.Abstractions.ExtensionMethods;

namespace BeHeroes.CodeOps.Abstractions.Strings
{
    public struct HexString : IHexString
    {
        public const string DefaultHexPrefix = "0x";

        public string Prefix { get; set; }
        private byte[] Bytes { get; set; }
        public bool IsLittleEndian { get; set; }

        public static implicit operator string (HexString s)
        {
            return s.Prefix + s.Bytes?.Select(b => b.ToString("x2", CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + s2);
        }

        public static implicit operator HexString (string hexString)
        {
            if (!hexString.IsHexString())
                throw new ArgumentException();

            if (hexString.StartsWith(DefaultHexPrefix) && DefaultHexPrefix.Length > 0)
            {
                hexString = hexString.Substring(DefaultHexPrefix.Length);
            }

            var bytes = new byte[hexString.Length / 2];

            for (var i = 0; i < hexString.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);

            return bytes;
        }

        public static implicit operator byte[] (HexString s)
        {
            return s.Bytes;
        }

        public static implicit operator HexString(byte[] bytes)
        {
            return new HexString { Bytes = bytes };
        }

        public static implicit operator BigInteger (HexString s)
        {
            return s.ToBigInteger();
        }

        public static implicit operator HexString(BigInteger b)
        {
            return b.ToHexString();
        }

        public override string ToString()
        {
            return this;
        }

        public override bool Equals(object obj)
        {
            try
            {
                return (HexString) obj == this;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = (int)2166136261;

                // ReSharper disable once NonReadonlyMemberInGetHashCode
                hash = hash * 16777619 ^ Bytes?.GetHashCode() ?? 0;

                // ReSharper disable once NonReadonlyMemberInGetHashCode
                hash = hash * 16777619 ^ Prefix?.GetHashCode() ?? 0;

                return hash;
            }
        }
    }
}
