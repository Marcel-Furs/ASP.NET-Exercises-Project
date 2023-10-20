using AutoMapper;
using Strona_Bazy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Strona_Bazy.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public RegisterController(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<IdentityUser>(model);
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.ErrorMessage = result.Errors.First().Description;
                }
            }

            return View(model);
        }
    }
}
