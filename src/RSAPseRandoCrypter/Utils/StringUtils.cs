using System.Text;

namespace RSAPseRandoCrypter.Utils;

internal class StringUtils
{
    public static string BuildString(params string[] strings)
    {
        var result = new StringBuilder();
        strings.ToList().ForEach(x => result.Append(x));
        return result.ToString();
    }
}
