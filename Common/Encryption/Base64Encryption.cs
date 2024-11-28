using System.Text;

namespace Practice_User_Login.Common.Encryption;

public class Base64Encryption 
{
    public static string CreateBase64EncryptionPassword(string rawuserpassword)
    {
        byte[] plaintextbytes = Encoding.UTF8.GetBytes(rawuserpassword);

        return Convert.ToBase64String(plaintextbytes);
    }

}           