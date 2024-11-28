using System.Security.Cryptography;
namespace Practice_User_Login.Common.Encryption;
public class SaltHashEncryption
{
    public static string CreateSaltAndHashPassword(string password, string salt)
    {
        // string concatenation
        string saltedpassword = password + salt;  //128

        //hast the concatenated string to the SHA256
        return Sha256Encryption.CreateSha256EncryptedPassword(saltedpassword);
    }

}