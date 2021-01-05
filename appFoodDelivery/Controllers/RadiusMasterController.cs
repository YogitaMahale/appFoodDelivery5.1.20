using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.pagination;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using plathora.pagination;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class RadiusMasterController : Controller
    {

        private readonly IRadiusMasterServices _RadiusMasterServices;
        public RadiusMasterController(IRadiusMasterServices RadiusMasterServices)
        {

            _RadiusMasterServices = RadiusMasterServices;
        }
        public IActionResult Index()
        {
            var listt = _RadiusMasterServices.GetAll().Select(x => new RadiusMasterIndexViewModel
            {
                id = x.id
                ,
                name = x.name

            }).ToList();
            //  return View(storeList);


            return View(listt);

        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new RadiusMasterCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RadiusMasterCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var store = new radiusmaster
                {
                    id = model.id
                    ,
                    name = model.name
                    //   , profilephoto=model.profilephoto
                   ,
                    isdeleted = false
                    ,
                    isactive = false

                };

                await _RadiusMasterServices.CreateAsync(store);
                TempData["success"] = "Record Saved successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }


        public IActionResult Edit(int id)
        {
            var storeowner = _RadiusMasterServices.GetById(id);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new RadiusMasterEditViewModel()
            {
                id = storeowner.id,
                name = storeowner.name,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RadiusMasterEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _RadiusMasterServices.GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.name = model.name;

                await _RadiusMasterServices.UpdateAsync(storeobj);
                TempData["success"] = "Record Updated successfully";
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
            await _RadiusMasterServices.Delete(id);
            TempData["success"] = "Record Delete successfully";
            return RedirectToAction(nameof(Index));



        }
    }
}
