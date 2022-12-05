using System.Text;

namespace RSAPseRandoCrypter.Models.RSA;

internal class RSAKeyPair
{
    public RSAKey OpenKey { get; set; }
    public RSAKey SecretKey { get; set; }

    public RSAKeyPair(RSAKey openKey, RSAKey secretKey)
    {
        OpenKey = openKey;
        SecretKey = secretKey;
    }
}
