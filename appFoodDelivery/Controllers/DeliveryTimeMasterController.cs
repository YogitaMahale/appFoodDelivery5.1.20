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
    // [Authorize(Roles = "Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DeliveryTimeMasterController : Controller
    {
        private readonly IDeliveryTimeMasterServices _DeliveryTimeMasterServices;
        public DeliveryTimeMasterController(IDeliveryTimeMasterServices DeliveryTimeMasterServices)
        {

            _DeliveryTimeMasterServices = DeliveryTimeMasterServices;
        }
        public IActionResult Index()
        {
            var listt = _DeliveryTimeMasterServices.GetAll().Select(x => new DeliveryTimeIndexViewModel
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
            var model = new DeliveryTimeCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeliveryTimeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var store = new deliverytimemaster
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

                await _DeliveryTimeMasterServices.CreateAsync(store);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }


        public IActionResult Edit(int id)
        {
            var storeowner = _DeliveryTimeMasterServices.GetById(id);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new DeliveryTimeEditViewModel()
            {
                id = storeowner.id,
                name = storeowner.name,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DeliveryTimeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _DeliveryTimeMasterServices.GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.name = model.name;

                await _DeliveryTimeMasterServices.UpdateAsync(storeobj);
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
            await _DeliveryTimeMasterServices.Delete(id);
            return RedirectToAction(nameof(Index));



        }
    }
}
