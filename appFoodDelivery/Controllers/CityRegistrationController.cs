using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Controllers
{
    //[Authorize(Roles = SD.Role_Admin)]
    public class CityRegistrationController : Controller
    {
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        public CityRegistrationController(IStateRegistrationService StateRegistrationService, ICountryRegistrationservices CountryRegistrationservices, ICityRegistrationservices CityRegistrationservices)
        {

            _StateRegistrationService = StateRegistrationService;
            _CountryRegistrationservices = CountryRegistrationservices;
            _CityRegistrationservices = CityRegistrationservices;

        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult index()
        {
            var citydetails = _CityRegistrationservices.GetAll().Select(x => new CityIndexViewModel
            {


                id = x.id,
                stateid = x.stateid,
                cityName = x.cityName,
                StateRegistration = _StateRegistrationService.GetById(x.stateid),
                CountryRegistration = _CountryRegistrationservices.GetById(_StateRegistrationService.GetById(x.stateid).countryid)

            }).ToList();
            return View(citydetails);


        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult test()
        {
            ViewBag.Countrieslist = _CountryRegistrationservices.GetAll().ToList();
            //ViewBag.States = _StateRegistrationService.GetAllState(Convert.ToInt16(countryid));
            return View("test");

        }

        public JsonResult getstatebyid(int id)
        {

            IList<StateRegistration> obj = _StateRegistrationService.GetAll().Where(x => x.countryid == id).ToList();
            //obj.Insert(0, new StateRegistration { id = 0, StateName = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "StateName"));
        }
        public JsonResult getCitybyStateid(int stateid)
        {

            IList<CityRegistration> obj = _CityRegistrationservices.GetAll().Where(x => x.stateid  == stateid).ToList();
         //   obj.Insert(0, new CityRegistration { id = 0, cityName = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "cityName"));
        }

        public IActionResult GetStates(string countryid)
        {
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            ViewBag.States = _StateRegistrationService.GetAllState(Convert.ToInt16(countryid));
            return View("Create");
        }

        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create()
        {
            // ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            ViewBag.Countries = _CountryRegistrationservices.GetAll().ToList();
            //  ViewBag.StateEnabled = false;
            var model = new CityCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Create(CityCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new CityRegistration
                {

                    id = model.id,
                    stateid = model.stateid,
                    cityName = model.cityName,
                    isdeleted = false,
                    isactive = false
                };

                await _CityRegistrationservices.CreateAsync(objcountry);
                TempData["success"] = "Record Saved successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
        //    var objcountry = _CityRegistrationservices.GetById(id);
        //    if (objcountry == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new CityEditViewModel
        //    {
        //        id = objcountry.id
        //        ,
        //        stateid = objcountry.stateid
        //        ,
        //        cityName = objcountry.cityName
        //        ,
        //        countryid = _StateRegistrationService.GetById(objcountry.stateid).countryid

        //    };
        //    // ViewBag.StateEnabled = false  ;
        // //   ViewBag.States = _StateRegistrationService.GetAllState(model.countryid);
        //    return View(model);


        //}
        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Edit(int id)
        {
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            var objcountry = _CityRegistrationservices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new CityEditViewModel
            {
                id = objcountry.id
                ,
                stateid = objcountry.stateid
                ,
                cityName = objcountry.cityName
                ,
                countryid = _StateRegistrationService.GetById(objcountry.stateid).countryid

            };
            // ViewBag.StateEnabled = false  ;
            ViewBag.States = _StateRegistrationService.GetAllState(model.countryid);
            return View(model);


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Edit(CityEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _CityRegistrationservices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.stateid = model.stateid;
                objcountry.cityName = model.cityName;


                await _CityRegistrationservices.UpdateAsync(objcountry);
                TempData["success"] = "Record Updated successfully";
                return RedirectToAction(nameof(index));
            }
            else
            {
                return View(model);
            }

        }


        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await _CityRegistrationservices.Delete(id);
            TempData["success"] = "Record Delete successfully";
            return RedirectToAction(nameof(Index));
        }



    }
}
