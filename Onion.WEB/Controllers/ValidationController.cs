using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onion.Domain.Entities;

namespace OnionArhitectura.Controllers;

public class ValidationController : Controller
{
    private readonly UserManager<MyUser> _userManager;

    public ValidationController(UserManager<MyUser> userManager)
    {
        _userManager = userManager;
    }

    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> CheckUserEmail(string email, int id)
    {
        MyUser user = await _userManager.FindByEmailAsync(email);

        if (user != null && user.Id != id)
        {
            return Json(false);
        }
        return Json(true);
    }


    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> CheckUserName(string username, int id)
    {
        MyUser user = await _userManager.FindByNameAsync(username);

        if (user != null && user.Id != id)
        {
            return Json(false);
        }

        return Json(true);
    }
}