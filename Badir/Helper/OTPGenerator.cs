using System.Security.Cryptography;
using System.Text;

namespace ReactNative.Helper;

public static class OTPGenerator
{
    public static string GenerateOTP(int length = 11)
    {
        const string digits = "0123456789";
        var otp = new StringBuilder();
        using (var rng = RandomNumberGenerator.Create())
        {
            for (int i = 0; i < length; i++)
            {
                byte[] randomByte = new byte[1];
                rng.GetBytes(randomByte);
                int index = randomByte[0] % digits.Length;
                otp.Append(digits[index]);
            }
        }
        return otp.ToString();
    }
}

