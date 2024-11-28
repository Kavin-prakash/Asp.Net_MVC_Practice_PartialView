using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Practice_User_Login.Data;
using Practice_User_Login.Models;

public class GetAllUsersController : Controller
{

    // Dependency Inject

    private readonly PracticeLoginContext _context;

    // private readonly ILogger _logger;

    public GetAllUsersController(PracticeLoginContext practiceLoginContext)
    {
        _context = practiceLoginContext;
    }

    public ActionResult ShowUsers()
    {
        return View();
    }

    // <Summay> 
    // Method is used to get all users from database
    // </Summary>

    [HttpGet]
    public ActionResult GetAllUserList()
    {
        var userslist = _context.Users.ToList();

        return Json(userslist);
    }


    [HttpGet]
    public ActionResult GetUserById(int userId)
    {
        var userbyid = _context.Users.FirstOrDefault(x => x.UserId == userId);

        if (userbyid != null)
        {
            return Json(userbyid);
            // return PartialView("_UserPartialview", userbyid);
        }
        else
        {
            return Json(null);
        }
    }


    [HttpPut]
    public IActionResult UpdateUserDetail([FromQuery] int userId, [FromBody] User user)
    {
        try
        {
            if (user == null || userId != user.UserId)
            {
                return BadRequest("Invalid data or user ID mismatch.");
            }

            var existingUser = _context.Users.FirstOrDefault(x => x.UserId == userId);
            if (existingUser != null)
            {
                existingUser.UserMobileNumber = user.UserMobileNumber;
                _context.Users.Update(existingUser);
                _context.SaveChanges();
                return Json(new { success = true, user = existingUser });
            }
            else
            {
                return NotFound("User not found.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}

