using BeHeroes.CodeOps.Abstractions.Strings;

namespace BeHeroes.CodeOps.Abstractions.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsHexString(this string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public static byte[] ToByteArray(this HexString hexString)
        {
            var castHexString = (string) hexString;
            var bytes = new byte[castHexString.Length / 2];

            for (var i = 0; i < castHexString.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(castHexString.Substring(i, 2), 16);

            return bytes;
        }
    }
}
