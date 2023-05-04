namespace BeHeroes.CodeOps.Abstractions.ExtensionMethods
{
    public static class CharExtensions
    {
        public static byte ToByte(this char c, int shift = 0)
        {
            var value = (byte)c;

            if (((0x40 < value) && (0x47 > value)) || ((0x60 < value) && (0x67 > value)))
            {
                if (0x40 != (0x40 & value)) return value;

                if (0x20 == (0x20 & value))
                    value = (byte)(((value + 0xA) - 0x61) << shift);
                else
                    value = (byte)(((value + 0xA) - 0x41) << shift);
            }
            else if ((0x29 < value) && (0x40 > value))
                value = (byte)((value - 0x30) << shift);
            else
                throw new InvalidOperationException();

            return value;
        }
    }
}
