using RSAPseRandoCrypter.Models;
using System.Numerics;

namespace RSAPseRandoCrypter.Algorithms.BlumBlumShub;

internal class BlumBlumShubRandom
{
    private readonly BigInteger _modulo;
    private BigInteger _current;

    public BlumBlumShubRandom(BBSKeyPair keys)
    {
        _modulo = keys.ModuloKey;
        _current = keys.InitKey;
    }

    public BigInteger NextBigInt(int? bytesCount = null)
    {
        var bytes = Enumerable.Range(0, bytesCount ?? CommonValues.BytesCount)
            .Select(x => NextByte())
            .ToArray();
        return new BigInteger(bytes);
    }

    public byte NextByte()
    {
        var result = 0;
        for (int i = 0; i < 8; i++)
        {
            result |= NextBit() << i;
        }
        return (byte)result;
    }

    public int NextBit()
    {
        var result = (int)(_current & 1);
        MoveNext();
        return result;
    }

    private void MoveNext()
    {
        _current = BigInteger.ModPow(_current, 2, _modulo);
    }
}