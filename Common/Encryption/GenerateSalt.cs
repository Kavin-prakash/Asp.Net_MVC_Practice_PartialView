using System.Security.Cryptography;

namespace Practice_User_Login.Common.Encryption;

public class GenerateSalt
{
    public static string CreateSalt()
    {
        // Create Byte

        byte[] saltbytes = new byte[16];

        using (var rng = new RNGCryptoServiceProvider())
        {

            rng.GetBytes(saltbytes);
        }

        // Implicit Type conversion
        return Convert.ToBase64String(saltbytes);
    }
}