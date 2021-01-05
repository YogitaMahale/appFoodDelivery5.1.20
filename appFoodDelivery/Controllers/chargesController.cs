using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class chargesController : Controller
    {

        private readonly IchargesServices _chargesServices;
        public chargesController(IchargesServices chargesServices)
        {
            _chargesServices = chargesServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            var storeowner = _chargesServices.GetById(1);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new chargesEditViewModel()
            {
                id = storeowner.id,
                customer1Km = storeowner.customer1Km,
                customer2K = storeowner.customer2K,
                deliveryboy1Km = storeowner.deliveryboy1Km,
                deliveryboy2Km = storeowner.deliveryboy2Km

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(chargesEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _chargesServices.GetById(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.customer1Km = model.customer1Km;
                storeobj.deliveryboy2Km = model.deliveryboy2Km;
                storeobj.customer2K = model.customer2K;
                storeobj.deliveryboy1Km = model.deliveryboy1Km;
                //id, customer1Km, customer2K, deliveryboy1Km, deliveryboy2Km
                await _chargesServices.UpdateAsync(storeobj);
                TempData["success"] = "Record Update successfully";
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                return View();
            }

        }

    }
}
