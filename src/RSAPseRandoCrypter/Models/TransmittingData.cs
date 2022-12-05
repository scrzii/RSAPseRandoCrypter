using RSAPseRandoCrypter.Extensions;
using RSAPseRandoCrypter.Interfaces;
using RSAPseRandoCrypter.Services;
using RSAPseRandoCrypter.Utils;
using System.Numerics;
using System.Text;

namespace RSAPseRandoCrypter.Models;

internal class TransmittingData : ISerializableObject<TransmittingData>
{
    public BBSKeyPair EncryptionKey { get; }
    public SerializableBytes Message { get; }

    public TransmittingData(BBSKeyPair encryptionKey, SerializableBytes message)
    {
        Message = message;
        EncryptionKey = encryptionKey;
    }

    public static TransmittingData CreateObject(Scanner scanner)
    {
        var encryptionKey = BBSKeyPair.CreateObject(scanner);
        var message = SerializableBytes.CreateObject(scanner);
        return new TransmittingData(encryptionKey, message);
    }

    public string CreateString()
    {
        return StringUtils.BuildString(EncryptionKey.CreateString(), Message.CreateString());
    }
}
