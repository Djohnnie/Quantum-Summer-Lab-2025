using System.Text;

namespace QuantumSummerLab.Processor.Extensions;

public static class Base64Extensions
{
    public static string ToBase64String(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
        
        var bytes = Encoding.UTF8.GetBytes(input);
        return Convert.ToBase64String(bytes);
    }

    public static string FromBase64String(this string base64Input)
    {
        if (string.IsNullOrEmpty(base64Input))
        {
            return string.Empty;
        }

        var bytes = Convert.FromBase64String(base64Input);
        return Encoding.UTF8.GetString(bytes);
    }
}