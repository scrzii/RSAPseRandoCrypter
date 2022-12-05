using RSAPseRandoCrypter.Models.RSA;
using RSAPseRandoCrypter.Services;
using System.Numerics;

namespace RSAPseRandoCrypter.Algorithms;

internal class RSACrypter
{
    private readonly NumberFactory _factory;
    private const int E = 17;

    public RSACrypter(NumberFactory factory)
    {
        _factory = factory;
    }

    public RSAKeyPair GenerateKeys(int maxTries = 1000000)
    {
        for (int i = 0; i < maxTries; i++)
        {
            var result = TryGenerateKeys();
            if (result.SecretKey.KeyComponent > 1)
            {
                return result;
            }
        }
        throw new Exception($"Max tries limit exceeded with rsa key pair generating. Limit: {maxTries}");
    }

    private RSAKeyPair TryGenerateKeys()
    {
        var p = _factory.GenerateProbablyPrime();
        var q = _factory.GenerateProbablyPrime();
        var n = p * q;
        var openKey = new RSAKey(n, E);
        var secretKey = new RSAKey(n, GetSecretExponent(p, q));
        return new RSAKeyPair(openKey, secretKey);
    }

    public BigInteger Encrypt(BigInteger data, RSAKey openKey)
    {
        return BigInteger.ModPow(data, openKey.KeyComponent, openKey.N);
    }

    public BigInteger Decrypt(BigInteger encryptedData, RSAKey secretKey)
    {
        return BigInteger.ModPow(encryptedData, secretKey.KeyComponent, secretKey.N);
    }

    private BigInteger GetSecretExponent(BigInteger p, BigInteger q)
    {
        var phi = (p - 1) * (q - 1);
        return (EuclidExtended.Calculate(E, phi).ACofficient % phi + phi) % phi;
    }
}