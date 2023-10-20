using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Strona_Bazy.Data.Models;
using Strona_Bazy.Models;
using Strona_Bazy.Repositories;

namespace Strona_Bazy.Controllers
{
    [Authorize]
    public class CharakterController : Controller
    {
        private readonly ICharakterRepository charakterRepository;
        private readonly IMapper mapper;

        public CharakterController(ICharakterRepository charakterRepository, IMapper mapper)
        {
            this.charakterRepository = charakterRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<List<CharakterViewModel>>(charakterRepository.GetAll()));

            //return View(context.Charakter.Select(x => new CharakterViewModel
            //{
            //    Id = x.Id,
            //    Type = x.Type,
            //    Weapon = x.Weapon,
            //    Damage = x.Damage,
            //}).ToList());
        }

        public IActionResult Create()
        {
            return View(new CharakterViewModel());
        }

        [HttpPost]
        public IActionResult Create(CharakterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var charakter = mapper.Map<Charakter>(model);
                charakterRepository.Create(charakter);
                return RedirectToAction("Index");

                //var charakter = new Charakter
                //{
                //    Type = model.Type,
                //    Weapon = model.Weapon,
                //    Damage = model.Damage
                //};
                //context.Charakter.Add(charakter);
                //context.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Update(int id)
        {
            var charakter = charakterRepository.Get(id);
            if(charakter == null)
            {
                return NotFound("Nie istnieje taka postać");
            }
            return View(mapper.Map<CharakterViewModel>(charakter));
            //var charakter = context.Charakter.FirstOrDefault(x => x.Id == id);
            //if (charakter == null)
            //{
            //    return NotFound("Nie istnieje taka postać");
            //}

            //var model = new CharakterViewModel
            //{
            //    Type = charakter.Type,
            //    Weapon = charakter.Weapon,
            //    Damage = charakter.Damage,
            //    Id = charakter.Id
            //};
            //return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, CharakterViewModel model)
        {

            var charakter = charakterRepository.Get(id);
            if(charakter == null)
            {
                return NotFound("Nie istnieje taka postać");
            }

            mapper.Map(model, charakter);
            charakterRepository.Update(charakter);
            return RedirectToAction("Index");

            //var charakter = context.Charakter.FirstOrDefault(x => x.Id == id);
            //if (charakter == null)
            //{
            //    return NotFound("Nie istnieje taka postać");
            //}

            //charakter.Type = model.Type;
            //charakter.Weapon = model.Weapon;
            //charakter.Damage = model.Damage;
            //context.SaveChanges();
            //return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var charakter = charakterRepository.Get(id);
            if (charakter == null)
            {
                return NotFound("Nie istnieje taka postać");
            }
            charakterRepository.Delete(id);
            return RedirectToAction("Index");

            //var charakter = context.Charakter.FirstOrDefault(x => x.Id == id);
            //if (charakter == null)
            //{
            //    return NotFound("Nie istnieje taka postać");
            //}
            //context.Remove(charakter);
            //context.SaveChanges();
            //return RedirectToAction("Index");
        }
    }
}
