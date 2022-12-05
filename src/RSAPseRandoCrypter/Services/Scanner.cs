using RSAPseRandoCrypter.Extensions;
using System.Numerics;

namespace RSAPseRandoCrypter.Services;

internal class Scanner
{
    private readonly byte[] _source;
    private int _targetPosition;

    public Scanner(string source)
    {
        _source = source.ToBytes();
        _targetPosition = 0;
    }

    public BigInteger NextBigInt()
    {
        var length = NextByte();
        var data = Enumerable.Range(0, length)
            .Select(x => NextByte())
            .ToArray();
        return new BigInteger(data);
    }

    public byte[] BytesToEnd()
    {
        var result = new List<byte>();
        while (HasNextByte())
        {
            result.Add(NextByte());
        }
        return result.ToArray();
    }

    public byte[] NextBytes(int bytesCount)
    {
        return Enumerable.Range(0, bytesCount)
            .Select(x => NextByte())
            .ToArray();
    }

    public int NextInt()
    {
        var result = 0;
        var bytes = NextBytes(4);
        Enumerable.Range(0, 4)
            .ToList()
            .ForEach(x => result |= bytes[x] << (8 * x));
        return result;
    }

    public byte NextByte()
    {
        if (!HasNextByte())
        {
            throw new Exception("Sequence has not next byte");
        }
        return _source[_targetPosition++];
    }

    public bool HasNextByte()
    {
        return _targetPosition < _source.Length;
    }
}