using RSAPseRandoCrypter.Extensions;
using RSAPseRandoCrypter.Interfaces;
using RSAPseRandoCrypter.Services;
using RSAPseRandoCrypter.Utils;

namespace RSAPseRandoCrypter.Models;

internal class SerializableBytes : ISerializableObject<SerializableBytes>
{
    public byte[] Data { get; }

    public SerializableBytes(byte[] data)
    {
        Data = data;
    }

    public static SerializableBytes CreateObject(Scanner scanner)
    {
        var bytesCount = scanner.NextInt();
        return new SerializableBytes(scanner.NextBytes(bytesCount));
    }

    public string CreateString()
    {
        return StringUtils.BuildString(Data.Length.ToHex(), Data.ToHex());
    }
}
