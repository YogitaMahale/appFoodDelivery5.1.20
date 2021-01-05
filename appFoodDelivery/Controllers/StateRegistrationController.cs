using appFoodDelivery;
using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using plathora.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class StateRegistrationController : Controller
    {

        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        public StateRegistrationController(IStateRegistrationService StateRegistrationService, ICountryRegistrationservices CountryRegistrationservices)
        {
            _StateRegistrationService = StateRegistrationService;
            _CountryRegistrationservices = CountryRegistrationservices;

        }

        public IActionResult Index()
        {
            var statedetails = _StateRegistrationService.GetAll().Select(x => new StateIndexViewModel
            {
                id = x.id,
                countryid = x.countryid,
                StateName = x.StateName,
                CountryRegistration = _CountryRegistrationservices.GetById(x.countryid)

            }).ToList();
            return View(statedetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Allcountry = _CountryRegistrationservices.GetAllCountry();
            var model = new StateCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StateCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new StateRegistration
                {
                    id = model.id,
                    countryid = model.countryid,
                    StateName = model.StateName,
                    isdeleted = false,
                    isactive = false
                };

                await _StateRegistrationService.CreateAsync(objcountry);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Allcountry = _CountryRegistrationservices.GetAllCountry();
            var objcountry = _StateRegistrationService.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new StateEditViewModel
            {
                id = objcountry.id,
                countryid = objcountry.countryid,
                StateName = objcountry.StateName

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _StateRegistrationService.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.countryid = model.countryid;
                objcountry.StateName = model.StateName;


                await _StateRegistrationService.UpdateAsync(objcountry);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _StateRegistrationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
