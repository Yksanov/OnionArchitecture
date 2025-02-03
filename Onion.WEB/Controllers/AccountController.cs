using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace OnionArhitectura.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<MyUser> _userManager;
    private readonly SignInManager<MyUser> _signInManager;

    public AccountController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [Authorize(Roles = "director")]
    public async Task<IActionResult> AllUsers()
    {
        var users = _userManager.Users.ToList();
        var userRoles = new Dictionary<int, string>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            userRoles[user.Id] = string.Join(", ", roles);
        }
        
        ViewBag.UsersRoles = userRoles;
        return View();
    }


    [HttpPost]
    [Authorize(Roles = "director")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        await _userManager.DeleteAsync(user);
        return RedirectToAction("AllUsers");
    }


    [HttpPost]
    [Authorize(Roles = "director")]
    public async Task<IActionResult> BlockUser(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        user.LockoutEnd = DateTimeOffset.MaxValue;
        await _userManager.UpdateAsync(user);
        return RedirectToAction("AllUsers");
    }


    [HttpPost]
    [Authorize(Roles = "director")]
    public async Task<IActionResult> UnblockUser(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        if (user.LockoutEnd == null)
        {
            return RedirectToAction("AllUsers", "Account");
        }

        user.LockoutEnd = null;
        await _userManager.UpdateAsync(user);
        return RedirectToAction("AllUsers");
    }
    

    [HttpGet]
    public IActionResult Login(string returnUrl = "")
    {
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            MyUser user = await _userManager.FindByEmailAsync(model.UserNameOrEmail) ?? await _userManager.FindByNameAsync(model.UserNameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь не найден");
                return View(model);
            }

            SignInResult result =
                await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Login");
            }

            ModelState.AddModelError(string.Empty, "Неправильные логин или пароль");
        }
        return View(model);
    }

    [HttpGet]
    [Authorize(Roles = "director")]
    public IActionResult CreateUser()
    {
        List<KeyValuePair<string, string>> roles = new List<KeyValuePair<string, string>>();
        roles.Add(new KeyValuePair<string, string>("admin", "Администратор"));
        roles.Add(new KeyValuePair<string, string>("director", "Директор"));
        ViewBag.Roles = roles;
        
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUser(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            MyUser admin = new MyUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
            
            IdentityResult result = await _userManager.CreateAsync(admin, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, model.Role);
                return RedirectToAction("Login");
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        List<KeyValuePair<string, string>> roles = new List<KeyValuePair<string, string>>();
        roles.Add(new KeyValuePair<string, string>("admin", "Администратор"));
        roles.Add(new KeyValuePair<string, string>("director", "Директор"));
        ViewBag.Roles = roles;
        
        return View(model);
    }

    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}