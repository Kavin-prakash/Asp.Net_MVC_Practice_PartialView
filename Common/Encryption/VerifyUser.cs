using Practice_User_Login.Common.Encryption;

public class VerifyUser
{
    public bool VerifyPassword(string password, string salt, string storedHashPassword)
    {
        // Base64 encode the password
        var base64Password = Base64Encryption.CreateBase64EncryptionPassword(password);

        var computedHashPassword = SaltHashEncryption.CreateSaltAndHashPassword(base64Password, salt);

        // Compare the computed hash with the stored hash
        return storedHashPassword == computedHashPassword;
    }
}