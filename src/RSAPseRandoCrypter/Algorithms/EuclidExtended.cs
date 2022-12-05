using System.Numerics;

namespace RSAPseRandoCrypter.Algorithms;

internal class EuclidExtendedResult
{
    public BigInteger GCD { get; set; }
    public BigInteger ACofficient { get; set; }
    public BigInteger BCofficient { get; set; }

    public EuclidExtendedResult(BigInteger r, BigInteger s, BigInteger t)
    {
        GCD = r;
        ACofficient = s;
        BCofficient = t;
    }
}

internal class EuclidExtended
{
    public static EuclidExtendedResult Calculate(BigInteger a, BigInteger b)
    {
        var prev = new EuclidExtendedResult(a, 1, 0);
        var curr = new EuclidExtendedResult(b, 0, 1);

        while (curr.GCD != 0)
        {
            var q = prev.GCD / curr.GCD;
            var next = new EuclidExtendedResult(
                prev.GCD - q * curr.GCD, 
                prev.ACofficient - q * curr.ACofficient, 
                prev.BCofficient - q * curr.BCofficient);
            prev = curr;
            curr = next;
        }

        return prev;
    }
}
