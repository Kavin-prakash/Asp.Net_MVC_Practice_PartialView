using Microsoft.AspNetCore.Mvc;
using Practice_User_Login.Common.Encryption;
using Practice_User_Login.Data;
using Practice_User_Login.Models;
using System.Linq;
public class AccountController : Controller
{
    private readonly PracticeLoginContext _context;
    private readonly VerifyUser _verifyUser;
    public AccountController(PracticeLoginContext practiceLoginContext, VerifyUser verifyUser)
    {
        _context = practiceLoginContext;
        _verifyUser = verifyUser;
    }


    public ActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public ActionResult Login(UserViewModel userViewModel)
    {

        if (ModelState.IsValid)
        {
            var userlogin = _context.Users
                .FirstOrDefault(u => u.UserEmail == userViewModel.Email);

            if (userlogin != null)
            {
                // Check if the password is correct
                var isValid = _verifyUser.VerifyPassword(userViewModel.Password, userlogin.Salt, userlogin.UserPasswordHash);

                if (!isValid)
                {
                    return Unauthorized("Invalid User");
                }
                else
                {
                    userlogin.UserLastActionDateTime = DateTime.Now;
                    _context.Users.Update(userlogin);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");

                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password");
            }
        }
        return View(userViewModel);
    }
}
