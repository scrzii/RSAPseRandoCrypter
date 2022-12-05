using RSAPseRandoCrypter.Extensions;
using RSAPseRandoCrypter.Interfaces;
using RSAPseRandoCrypter.Services;
using RSAPseRandoCrypter.Utils;
using System.Numerics;

namespace RSAPseRandoCrypter.Models;

internal class BBSKeyPair : ISerializableObject<BBSKeyPair>
{
    public BigInteger ModuloKey { get; }
    public BigInteger InitKey { get; }

    public BBSKeyPair(BigInteger moduloKey, BigInteger initKey)
    {
        ModuloKey = moduloKey;
        InitKey = initKey;
    }

    public static BBSKeyPair CreateObject(Scanner scanner)
    {
        var moduloKey = scanner.NextBigInt();
        var initKey = scanner.NextBigInt();
        return new BBSKeyPair(moduloKey, initKey);
    }

    public string CreateString()
    {
        return StringUtils.BuildString(ModuloKey.ToHex(), InitKey.ToHex());
    }
}
