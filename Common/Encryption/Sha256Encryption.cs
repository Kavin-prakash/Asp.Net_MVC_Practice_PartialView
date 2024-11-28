using System.Security.Cryptography;
using System.Text;

namespace Practice_User_Login.Common.Encryption;


public class Sha256Encryption
{
    public static string CreateSha256EncryptedPassword(string password)
    {
        using (HashAlgorithm sha256Hash = SHA256.Create())
        {

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));


            // Convert the bytes array into string

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}