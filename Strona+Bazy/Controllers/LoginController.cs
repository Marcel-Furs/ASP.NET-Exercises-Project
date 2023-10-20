using AutoMapper;
using Strona_Bazy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Strona_Bazy.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;

        public LoginController(SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {

            Console.WriteLine("test");
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
                if (!result.Succeeded)
                {
                    ViewBag.ErrorMessage = "Niepoprawne dane logowania";
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "login");
        }
    }
}
