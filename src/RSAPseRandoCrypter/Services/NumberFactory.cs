using RSAPseRandoCrypter.Algorithms;
using System.Numerics;

namespace RSAPseRandoCrypter.Services;

internal class NumberFactory
{
    private readonly Random _random;

    public NumberFactory(int? randomSeed = null)
    {
        _random = new Random(randomSeed ?? (int)(DateTime.Now.Ticks % int.MaxValue));
    }

    public BigInteger GenerateRandom(bool positiveOnly = true)
    {
        var bytes = new byte[CommonValues.BytesCount];
        _random.NextBytes(bytes);
        if (positiveOnly)
        {
            return BigInteger.Abs(new BigInteger(bytes));
        }
        return new BigInteger(bytes);
    }

    public BigInteger GenerateProbablyPrime(int maxTries = 1000000)
    {
        for (int i = 0; i < maxTries; i++)
        {
            var number = GenerateRandom();
            var algo = new MillerRabinTest(this);
            if (algo.TestKTimes(number))
            {
                return number;
            }
        }

        throw new Exception($"Max tries limit exceeded with probably prime number generating. Limit: {maxTries}");
    }
}
