namespace BeHeroes.CodeOps.Abstractions.Strings
{
    public interface IHexString
    {
        bool IsLittleEndian { get; set; }

        string ToString();
    }
}
