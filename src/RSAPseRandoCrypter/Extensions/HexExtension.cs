using System.Numerics;

namespace RSAPseRandoCrypter.Extensions;

internal static class HexExtension
{
    public static string ToHex(this BigInteger source)
    {
        var sourceBytes = source.ToByteArray();
        var bytes = new List<byte>() { (byte)sourceBytes.Length };
        bytes.AddRange(sourceBytes);
        return bytes.ToArray().ToHex();
    }

    public static string ToHex(this byte[] source)
    {
        return BitConverter.ToString(source.ToArray()).Replace("-", "");
    }

    public static string ToHex(this int source)
    {
        var mask = (1 << 8) - 1;
        var bytes = Enumerable.Range(0, 4)
            .Select(x => (byte)((source >> (8 * x)) & (mask)))
            .ToArray();
        return bytes.ToHex();
    }

    public static byte[] ToBytes(this string source)
    {
        return Enumerable.Range(0, source.Length)
            .Where(x => x % 2 == 0)
            .Select(x => Convert.ToByte(source.Substring(x, 2), 16))
            .ToArray();
    }

    
}
