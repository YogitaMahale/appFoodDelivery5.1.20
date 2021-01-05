using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = SD.Role_Admin)]
    public class ManagerCollectionController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> collect(int id, string name, decimal amount)
        {
            //var model = new collectAmountViewModel
            //{
            //    deliveryboyid = id
            //      ,
            //    deliveryboyname = name
            //      ,
            //    amount = 0
            //      ,
            //    finalamt = amount
            //      ,
            //    remaining = amount


            //};
            //return View(model);
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> collect(collectAmountViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (model.finalamt < model.amount)
        //        {

        //            ModelState.AddModelError("ModelOnly", "Please Collect Proper Amount");
        //            return View(model);
        //        }
        //        else
        //        {
        //            ApplicationUser usr = await GetCurrentUserAsync();
        //            var user = await _usermanager.FindByIdAsync(usr.Id);


        //            var paramter = new DynamicParameters();
        //            paramter.Add("@deliveryboyid", model.deliveryboyid);
        //            paramter.Add("@amount", model.amount);
        //            paramter.Add("@managerId", user.Id);

        //            _ISP_Call.Execute("insertdeliveryboyamt", paramter);

        //            TempData["success"] = "Amount Updated successfully";
        //            return RedirectToAction(nameof(Index));
        //        }

        //    }
        //    else
        //    {
        //        return View(model);
        //    }

        //    //  return View(model);
        //}
    }
}
