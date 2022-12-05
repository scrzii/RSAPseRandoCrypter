using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSAPseRandoCrypter;
using RSAPseRandoCrypter.Algorithms;
using RSAPseRandoCrypter.Models.RSA;
using RSAPseRandoCrypter.Services;
using System.Linq;
using System.Numerics;

namespace RSAPseRandoCrypterTests;

[TestClass]
public class RSATests : CommonTestEnvironment
{
    public RSATests() : base(123)
    {

    }

    private RSAKeyPair Sut()
    {
        var open = new RSAKey(
            BigInteger.Parse("84308120350611195789438645913364355646494000611990149031823367930625233404048556290596634969754904600260176136673702503188605251916747243680805780118389"),
            17);
        var secret = new RSAKey(
            open.N,
            BigInteger.Parse("4959301197094776222908155641962609155676117683058244060695492231213249023766091349926876697269246358838064639748223150476552209913112957999332255318013"));
        return new RSAKeyPair(open, secret);
    }

    [TestMethod]
    public void PreMadeKeyTest()
    {
        var factory = new NumberFactory(123456);
        var crypter = new RSACrypter(factory);
        var keys = Sut();
        var stringNumbers = new string[]
        {
                "0",
                "1",
                "-1",
                "8235982356238747093274892340832897548923757863498532488273495872385325235",
                "-293479823754623450932759827048325787435907239048230948239472395782937857832789578932"
        };
        foreach (var stringNumber in stringNumbers)
        {
            var number = BigInteger.Parse(stringNumber);
            var encrypted = crypter.Encrypt(number, keys.OpenKey);
            var decrypted = crypter.Decrypt(encrypted, keys.SecretKey);
            decrypted.Should().Be(number);
        }

    }

    [TestMethod]
    public void RandomKeyTest()
    {
        var randomSeeds = new int[] { 0, 1, -5, 234723, -1924 };
        foreach (var randomSeed in randomSeeds)
        {
            var factory = new NumberFactory(randomSeed);
            var crypter = new RSACrypter(factory);
            var number = BigInteger.Parse("-234569234801572348750284328904327528497320482375902323325829755");
            TestEncryption(number, crypter);
        }
    }

    [TestMethod]
    public void SecretExponentTest()
    {
        var randomSeeds = Enumerable.Range(-100, 201);
        foreach (var randomSeed in randomSeeds)
        {
            var factory = new NumberFactory(randomSeed);
            var crypter = new RSACrypter(factory);
            var number = BigInteger.Parse("-234569234801572348750284328904327528497320482375902323325829755");
            TestEncryption(number, crypter);
        }
    }

    private void TestEncryption(BigInteger data, RSACrypter crypter)
    {
        var keys = crypter.GenerateKeys();
        var encrypted = crypter.Encrypt(data, keys.OpenKey);
        var decrypted = crypter.Decrypt(encrypted, keys.SecretKey);
        decrypted.Should().Be(data);
    }
}