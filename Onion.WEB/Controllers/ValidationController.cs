using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Infrastructure.Data;

namespace OnionArhitectura.Controllers;

public class ValidationController : Controller
{
    private readonly UserManager<MyUser> _userManager;
    private readonly Context _context;

    public ValidationController(UserManager<MyUser> userManager, Context context)
    {
        _userManager = userManager;
        _context = context;
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

    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> CheckBranchName(string name, int id)
    {
        Branch branch = await _context.Branches.FirstOrDefaultAsync(b => b.Name == name);
        if (branch != null && branch.Id != id)
        {
            return Json(false);
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> CheckBranchLocation(string location, int id)
    {
        Branch branch = await _context.Branches.FirstOrDefaultAsync(b => b.Location == location);
        if (branch != null && branch.Id != id)
        {
            return Json(false);
        }

        return Json(false);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult FirstnameIsNull(string firstname)
    {
        if (firstname == null)
        {
            return Json(new { success = false });
        }
        else
        {
            return Json(new { success = true });
        }
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult LastnameIsNull(string lastname)
    {
        if (lastname == null)
        {
            return Json(new { success = false });
        }
        else
        {
            return Json(new { success = true });
        }
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult PhoneIsNull(string phone)
    {
        if (phone == null)
        {
            return Json(new { success = false });
        }
        else
        {
            return Json(new { success = true });
        }
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult DescriptionIsNull(string description)
    {
        if (description == null)
        {
            return Json(new { success = false });
        }
        else
        {
            return Json(new { success = true });
        }
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult StudyPriceIsNull(string studyPrice)
    {
        if (studyPrice == null)
        {
            return Json(new { success = false });
        }

        return Json(new { success = true });
    }
}