using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSAPseRandoCrypter.Models;
using RSAPseRandoCrypter.Models.RSA;
using RSAPseRandoCrypter.Services;
using System.Linq;

namespace RSAPseRandoCrypterTests;

[TestClass]
public class SerializableObjectTests : CommonTestEnvironment
{
    public SerializableObjectTests() : base(123)
    {
    }

    [TestMethod]
    public void TestBBSKeyPair()
    {
        var target = GenerateBBSKeyPair();
        var serialized = target.CreateString();
        var deserialized = BBSKeyPair.CreateObject(new Scanner(serialized));
        deserialized.Should().BeEquivalentTo(target);
    }

    [TestMethod]
    public void TestRSAKey()
    {
        var target = new RSAKey(NextBigInt(), NextBigInt());
        var serialized = target.CreateString();
        var deserialized = RSAKey.CreateObject(new Scanner(serialized));
        deserialized.Should().BeEquivalentTo(target);
    }

    [TestMethod]
    public void TestSerializableBytes()
    {
        var target = GenerateSerializableBytes();
        var serialized = target.CreateString();
        var deserialized = SerializableBytes.CreateObject(new Scanner(serialized));
        deserialized.Data.Should().BeEquivalentTo(target.Data);
    }

    [TestMethod]
    public void TestTransmittedData()
    {
        var target = new TransmittingData(GenerateBBSKeyPair(), GenerateSerializableBytes());
        var serialized = target.CreateString();
        var deserialized = TransmittingData.CreateObject(new Scanner(serialized));
        deserialized.Should().BeEquivalentTo(target);
    }

    private BBSKeyPair GenerateBBSKeyPair()
    {
        return new BBSKeyPair(NextBigInt(), NextBigInt());
    }

    private SerializableBytes GenerateSerializableBytes()
    {
        var bytes = Enumerable.Range(0, 10)
            .Select(x => NextByte())
            .ToArray();
        return new SerializableBytes(bytes);
    }
}
