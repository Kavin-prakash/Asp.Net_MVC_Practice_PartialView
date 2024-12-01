using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practice_User_Login.Data;
using Practice_User_Login.Models;


public class UserListController : Controller
{
    private readonly PracticeLoginContext _context;


    public UserListController(PracticeLoginContext practiceLoginContext)
    {
        _context = practiceLoginContext;
    }

    // [HttpGet]
    public ActionResult GetUsers()
    {
        var userslist = _context.Users.ToList();

        return View(userslist);
    }


    [HttpGet]
    public ActionResult GetUserById(int userId)
    {
        var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
        if (user != null)
        {
            return PartialView("_UserPartialView", user);
        }
        return Json(null);
    }


    // [HttpPut]
    // public ActionResult UpdateUserDetail(User user)
    // {
    //     try
    //     {
    //         // if (user == null || userId != user.UserId)
    //         // {
    //         //     return BadRequest("Invalid data or user ID mismatch.");
    //         // }

    //         var existingUser = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
    //         if (existingUser != null)
    //         {
    //             existingUser.UserMobileNumber = user.UserMobileNumber;
    //             _context.Users.Update(existingUser);
    //             _context.SaveChanges();
    //             return Json(new { success = true, user = existingUser });
    //         }
    //         else
    //         {
    //             return NotFound("User not found.");
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, $"Internal server error: {ex.Message}");
    //     }
    // }

    [HttpPut]
    public IActionResult UpdateUserDetail([FromQuery] int userid, [FromBody] User user)
    {
        try
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            var existingUser = _context.Users.FirstOrDefault(x => x.UserId == userid);

            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            // Update the fields that can be modified
            existingUser.UserMobileNumber = user.UserMobileNumber;

            _context.Users.Update(existingUser);
            _context.SaveChanges();

            return Json(new { success = true, user = existingUser });
        }
        catch (Exception ex)
        {
            // Log the exception (use a logger in production)
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


}

