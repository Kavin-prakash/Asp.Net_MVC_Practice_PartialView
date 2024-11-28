using Microsoft.AspNetCore.Mvc;
using Practice_User_Login.Common.Encryption;
using Practice_User_Login.Data;
using Practice_User_Login.Models;

public class RegistrationController : Controller
{
    private readonly PracticeLoginContext _practiceLoginContext;

    public RegistrationController(PracticeLoginContext practiceLoginContext)
    {
        _practiceLoginContext = practiceLoginContext;
    }
    public ActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Register(CreateUserModel createUserModel)
    {
        if (ModelState.IsValid)
        {
            // Generate Salt  [s1]
            var saltgenerated = GenerateSalt.CreateSalt();  // 64

            var base64hashedpassword = Base64Encryption.CreateBase64EncryptionPassword(createUserModel.UserPassword); //64

            // var encrypedpassword = Sha256Encryption.Sha256EncryptionPassword(base64hashedpassword);

            // combine [base64 and salt password] and compute hash
            var saltedHash = SaltHashEncryption.CreateSaltAndHashPassword(base64hashedpassword, saltgenerated);

            var user = new User()
            {
                Username = createUserModel.UserName,
                UserMobileNumber = createUserModel.UserMobileNumber,
                UserEmail = createUserModel.UserEmail,
                UserPasswordHash = saltedHash,
                Salt = saltgenerated,
                UserRegisteredDateTime = DateTime.Now,
                UserLastActionDateTime = DateTime.Now,
                IsActive = true
            };

            _practiceLoginContext.Users.Add(user);
            _practiceLoginContext.SaveChanges();
            // return Json(new { success = true, message = "Registration Successfull" });
            return RedirectToAction("Login", "Account");


        }
        else
        {
        }
        return Json(new { success = false, message = "Registration failed. Please correct the errors and try again." });
    }
}


