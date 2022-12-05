using RSAPseRandoCrypter.Algorithms;
using RSAPseRandoCrypter.Algorithms.BlumBlumShub;
using RSAPseRandoCrypter.Models;
using RSAPseRandoCrypter.Services;
using System.Text;

namespace RSAPseRandoCrypter;

public class Crypter
{
    private readonly NumberFactory _factory;
    private readonly RSACrypter _crypter;

    public Crypter(int bytesCount = 32, int? randomSeed = null)
    {
        CommonValues.BytesCount = bytesCount;
        _factory = new NumberFactory(randomSeed);
        _crypter = new RSACrypter(_factory);
    }

    public KeyPair GenerateKeys()
    {
        var keys = _crypter.GenerateKeys();
        return KeyPair.FromRSAKeys(keys);
    }

    public string Encrypt(string message, string openKey)
    {
        var key = KeyPair.ParseKey(openKey);

        var bbsKeyGenerator = new BlumBlumShubKeyGenerator(_factory);
        var bbsKeys = bbsKeyGenerator.GenerateKeys();
        var bbs = new BlumBlumShubRandom(bbsKeys);

        var bytes = XorBytes(Encoding.UTF8.GetBytes(message), bbs.NextByte);
        return new TransmittingData(bbsKeys, new SerializableBytes(bytes)).CreateString();
    }

    public string Decrypt(string encryptedMessage, string secretKey)
    {
        var key = KeyPair.ParseKey(secretKey);
        var openData = TransmittingData.CreateObject(new Scanner(encryptedMessage));

        var bbsKeys = openData.EncryptionKey;
        var bbs = new BlumBlumShubRandom(bbsKeys);

        var bytes = XorBytes(openData.Message.Data, bbs.NextByte);
        return Encoding.UTF8.GetString(bytes);
    }

    private byte[] XorBytes(byte[] target, Func<byte> interferenceGenerator)
    {
        return target
            .Select(x => (byte)(x ^ interferenceGenerator.Invoke()))
            .ToArray();
    }
}
