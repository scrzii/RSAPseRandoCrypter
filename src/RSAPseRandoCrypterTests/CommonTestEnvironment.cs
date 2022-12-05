using RSAPseRandoCrypter;
using System;
using System.Linq;
using System.Numerics;

namespace RSAPseRandoCrypterTests;

public abstract class CommonTestEnvironment
{
    private readonly Random _random;
    protected CommonTestEnvironment(int randomSeed)
    {
        _random = new Random(randomSeed);
        CommonValues.BytesCount = 32;
    }

    protected BigInteger NextBigInt()
    {
        var bytes = new byte[CommonValues.BytesCount];
        _random.NextBytes(bytes);
        return new BigInteger(bytes);
    }

    protected byte NextByte()
    {
        var bytes = new byte[1];
        _random.NextBytes(bytes);
        return bytes.First();
    }

    protected int NextInt()
    {
        return _random.Next();
    }
}
