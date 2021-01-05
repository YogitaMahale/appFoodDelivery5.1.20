using appFoodDelivery;
using appFoodDelivery.Entity;
using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Models;
using appFoodDelivery.pagination;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using plathora.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class CountryRegistrationController : Controller
    {

        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        public CountryRegistrationController(ICountryRegistrationservices CountryRegistrationservices)
        {
            _CountryRegistrationservices = CountryRegistrationservices;

        }

        public IActionResult Index()
        {
            var countrydetails = _CountryRegistrationservices.GetAll().Select(x => new CountryIndexViewModel
            {
                id = x.id,
                countrycode = x.countrycode,
                countryname = x.countryname

            }).ToList();
            return View(countrydetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CountryCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new CountryRegistration
                {
                    id = model.id,
                    countryname = model.countryname,
                    countrycode = "",
                    isdeleted = false,
                    isactive = false
                };

                await _CountryRegistrationservices.CreateAsync(objcountry);
                TempData["success"] = "Record Saved successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var objcountry = _CountryRegistrationservices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new CountryEditViewModel
            {
                id = objcountry.id,
                countryname = objcountry.countryname,

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CountryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _CountryRegistrationservices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.countryname = model.countryname;


                await _CountryRegistrationservices.UpdateAsync(objcountry);
                TempData["success"] = "Record Updated successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }


        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var emp = _AffiltateRegistrationService.GetById(id);
        //    if (emp == null)
        //    {
        //        return NotFound();

        //    }
        //    AffiltateRegistrationDeleteViewModel model = new AffiltateRegistrationDeleteViewModel()
        //    {
        //        id = emp.id,
        //        name = emp.name
        //    };


        //    return View(model);
        //}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _CountryRegistrationservices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
