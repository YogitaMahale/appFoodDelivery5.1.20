using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class distanceController : Controller
    {
        private readonly IdistanceServices _distanceServices;
        public distanceController(IdistanceServices distanceServices)
        {
            _distanceServices = distanceServices;
        }

        public IActionResult Index()
        {
            var storeowner = _distanceServices.GetById(1);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new distanceEditViewModel()
            {
                id = storeowner.id,
                range = storeowner.range

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(distanceEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _distanceServices.GetById(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.range = model.range;
                await _distanceServices.UpdateAsync(storeobj);
                TempData["success"] = "Record Update successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

    }
}
