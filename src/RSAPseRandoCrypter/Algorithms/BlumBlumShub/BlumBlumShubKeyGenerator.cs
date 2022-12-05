using RSAPseRandoCrypter.Models;
using RSAPseRandoCrypter.Services;
using System.Numerics;

namespace RSAPseRandoCrypter.Algorithms.BlumBlumShub;

internal class BlumBlumShubKeyGenerator
{
    private readonly NumberFactory _factory;

    public BlumBlumShubKeyGenerator(NumberFactory factory)
    {
        _factory = factory;
    }

    public BBSKeyPair GenerateKeys()
    {
        var modulo = GenerateModulo();
        return new BBSKeyPair(modulo, GenerateInitKey(modulo));
    }

    private BigInteger GenerateModulo()
    {
        var p = GeneratePrime3Modulo4();
        var q = GeneratePrime3Modulo4();
        return p * q;
    }

    private BigInteger GenerateInitKey(BigInteger modulo)
    {
        var result = modulo;
        while (EuclidExtended.Calculate(result, modulo).GCD > 1)
        {
            result = _factory.GenerateProbablyPrime();
        }
        return result;
    }

    private BigInteger GeneratePrime3Modulo4()
    {
        var result = new BigInteger(0);
        while (result % 4 != 3)
        {
            result = _factory.GenerateProbablyPrime();
        }
        return result;
    }
}
