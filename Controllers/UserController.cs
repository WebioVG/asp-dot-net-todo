using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tp_todo_list.Models;

namespace tp_todo_list.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<UserController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }
        
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var user = new User { UserName = model.Email, Email = model.Email, FullName = "default"};
        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                // Add each error to ModelState
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model); // Return the view with validation errors
        }
        
        return RedirectToAction("Index", "Todo");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        // Ensure the model is valid
        if (!ModelState.IsValid)
        {
            ViewBag.Message = "Veuillez remplir tous les champs correctement.";
            return View(model);
        }
        
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Todo");
        }

        ViewBag.Message = "Identifiants incorrects.";
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();        
        return RedirectToAction("Login");
    }
}