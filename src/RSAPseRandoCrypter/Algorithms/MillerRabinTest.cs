using RSAPseRandoCrypter.Services;
using System.Numerics;

namespace RSAPseRandoCrypter.Algorithms;

internal class MillerRabinTest
{
    private readonly NumberFactory _factory;

    public MillerRabinTest(NumberFactory factory)
    {
        _factory = factory;
    }

    public bool TestKTimes(BigInteger number, int k = 100)
    {
        if (number == 1)
        {
            return false;
        }
        var exp = 0;
        var buffer = number - 1;
        while (buffer % 2 == 0)
        {
            exp++;
            buffer /= 2;
        }
        return Enumerable.Range(0, k).All(x => Test(number, exp, buffer));
    }

    private bool Test(BigInteger n, int s, BigInteger d)
    {
        var a = _factory.GenerateRandom();
        if (BigInteger.ModPow(a, d, n) == 1)
        {
            return true;
        }

        for (int i = 0; i < s; i++)
        {
            if (BigInteger.ModPow(a, BigInteger.Pow(2, i) * d, n) == n - 1)
            {
                return true;
            }
        }

        return false;
    }
}
