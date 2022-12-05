using RSAPseRandoCrypter;
using RSAPseRandoCrypter.Algorithms;
using RSAPseRandoCrypter.Algorithms.BlumBlumShub;
using RSAPseRandoCrypter.Extensions;
using RSAPseRandoCrypter.Services;

namespace TestRunner;

public enum Action
{
    Encrypt = 1,
    Decrypt = 2,
    GenerateKeys = 3
};

public static class Program
{
    public static void Main(string[] args)
    {
        //TestRandom();
        Console.WriteLine(135.ToHex());
        Console.WriteLine(new Scanner("7B000000").NextInt());
        while (true)
        {
            var action = ReadAction();
            switch (action)
            {
                case Action.Decrypt:
                    Decrypt(new Crypter());
                    break;
                case Action.Encrypt:
                    Encrypt(new Crypter());
                    break;
                case Action.GenerateKeys:
                    GenerateKeys(new Crypter());
                    break;
            }
        }
    }

    private static void TestRandom()
    {
        CommonValues.BytesCount = 32;
        var factory = new NumberFactory(123);
        var keys = new BlumBlumShubKeyGenerator(factory).GenerateKeys();
        var model = new BlumBlumShubRandom(keys);
        var max = 100;
        var counts = Enumerable.Range(0, max).Select(x => 0).ToArray();
        for (int i = 0; i < 10000; i++)
        {
            var random = Math.Abs((int)(model.NextBigInt() % max));
            counts[random]++;
        }
        for (int i = 0; i < max; i++)
        {
            Console.WriteLine($"{i}:\t{counts[i]}");
        }
    }

    private static Action ReadAction()
    {
        Console.WriteLine("Введите действие (1 - зашифровать, 2 - расшифровать, 3 - сгенерировать ключи)");
        return (Action)int.Parse(Console.ReadLine());
    }

    private static void Encrypt(Crypter crypter)
    {
        Console.WriteLine("Введите сообщение");
        var message = Console.ReadLine();
        Console.WriteLine("Введите открытый ключ");
        var key = Console.ReadLine();
        Console.WriteLine(crypter.Encrypt(message, key));
    }

    private static void Decrypt(Crypter crypter)
    {
        Console.WriteLine("Введите зашифрованные данные");
        var data = Console.ReadLine();
        Console.WriteLine("Введите секретный ключ");
        var key = Console.ReadLine();
        Console.WriteLine(crypter.Decrypt(data, key));
    }

    private static void GenerateKeys(Crypter crypter)
    {
        var keys = crypter.GenerateKeys();
        Console.WriteLine($"Open:\n{keys.OpenKey}\nSecret:\n{keys.SecretKey}");
    }
}