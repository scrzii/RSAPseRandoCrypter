using RSAPseRandoCrypter.Extensions;
using RSAPseRandoCrypter.Interfaces;
using RSAPseRandoCrypter.Services;
using RSAPseRandoCrypter.Utils;
using System.Numerics;
using System.Text;

namespace RSAPseRandoCrypter.Models.RSA;

internal class RSAKey : ISerializableObject<RSAKey>
{
    public BigInteger N { get; set; }
    public BigInteger KeyComponent { get; set; }

    public RSAKey(BigInteger n, BigInteger keyComponent)
    {
        N = n;
        KeyComponent = keyComponent;
    }

    public static RSAKey CreateObject(Scanner scanner)
    {
        var keyComponent = scanner.NextBigInt();
        var n = scanner.NextBigInt();
        return new RSAKey(n, keyComponent);
    }

    public string CreateString()
    {
        return StringUtils.BuildString(KeyComponent.ToHex(), N.ToHex());
    }
}
