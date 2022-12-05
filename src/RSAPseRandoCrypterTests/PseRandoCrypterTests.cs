using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSAPseRandoCrypter;

namespace RSAPseRandoCrypterTests;

[TestClass]
public class PseRandoCrypterTests : CommonTestEnvironment
{
    public PseRandoCrypterTests() : base(123) { }

    private Crypter Sut(int seed = 123123123)
    {
        return new Crypter(randomSeed: seed);
    }

    [TestMethod]
    public void TestMessages()
    {
        var messages = new string[]
        {
            "",
            "A",
            "a",
            "AbaCaBa",
            "tex t sdf text",
            "very long text very long text very long text very long text very long text very long text very long text very long text very long text "
        };

        foreach (var message in messages)
        {
            var crypter = Sut();
            TestCrypting(message, crypter);
        }
    }

    [TestMethod]
    public void TestCoding()
    {
        var messages = new string[]
        {
            "English text",
            "English\ntext",
            "Русский текст",
            "Русский\nтекст",
            "نص عربي",
            "عرب\nنص"
        };

        foreach (var message in messages)
        {
            var crypter = Sut();
            TestCrypting(message, crypter);
        }
    }

    [TestMethod]
    public void TestSeeds()
    {
        var message = "Test message 123";
        var randomSeeds = new int[] { 0, 1, int.MinValue, int.MaxValue, 234235, 12325, -238974, -124798235, -1, 23, 15, 1, -5, 2, -2, 3, -3 };
        foreach (var randomSeed in randomSeeds)
        {
            var crypter = Sut(randomSeed);
            TestCrypting(message, crypter);
        }
    }

    private void TestCrypting(string message, Crypter crypter)
    {
        var keys = crypter.GenerateKeys();
        var encrypted = crypter.Encrypt(message, keys.OpenKey);
        var decrypted = crypter.Decrypt(encrypted, keys.SecretKey);
        decrypted.Should().Be(message);
    }
}