using RSAPseRandoCrypter.Models.RSA;
using RSAPseRandoCrypter.Services;

namespace RSAPseRandoCrypter;

public class KeyPair
{
    public string OpenKey { get; }
    public string SecretKey { get; }

    private KeyPair(string openKey, string secretKey)
    {
        OpenKey = openKey;
        SecretKey = secretKey;
    }

    internal static KeyPair FromRSAKeys(RSAKeyPair keys)
    {
        return new KeyPair(
            keys.OpenKey.CreateString(),
            keys.SecretKey.CreateString());
    }

    internal static RSAKey ParseKey(string source)
    {
        return RSAKey.CreateObject(new Scanner(source));
    }
}
