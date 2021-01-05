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
    public class versionsController : Controller
    {
        private readonly IversionsServices _versionsServices;
        public versionsController(IversionsServices versionsServices)
        {
            _versionsServices = versionsServices;
        }

        public IActionResult Index()
        {
            var storeowner = _versionsServices.GetById(1);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new VersionEditViewModel()
            {
                id = storeowner.id,
                storeVersion = storeowner.storeVersion,
                customerVersion = storeowner.customerVersion,
                deliveryboyVersion = storeowner.deliveryboyVersion


            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(VersionEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _versionsServices.GetById(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.customerVersion = model.customerVersion;
                storeobj.deliveryboyVersion = model.deliveryboyVersion;
                storeobj.storeVersion = model.storeVersion;

                await _versionsServices.UpdateAsync(storeobj);
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
