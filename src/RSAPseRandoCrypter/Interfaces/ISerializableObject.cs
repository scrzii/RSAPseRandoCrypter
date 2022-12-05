using RSAPseRandoCrypter.Services;
using System.Text;

namespace RSAPseRandoCrypter.Interfaces;

internal interface ISerializableObject<T>
{
    static abstract T CreateObject(Scanner scanner);
    string CreateString();

    public string BuildString(params string[] args)
    {
        var result = new StringBuilder();
        args.ToList().ForEach(x => result.Append(x));
        return result.ToString();
    }
}