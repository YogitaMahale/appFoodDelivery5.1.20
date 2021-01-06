using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Dapper;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = SD.Role_Admin)]
    public class ManagerCollectionController : Controller
    {
        private readonly IAdminCollectionservices _adminCollectionservices;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly ISP_Call _ispcall;
        public ManagerCollectionController(UserManager<ApplicationUser> usermanager, IAdminCollectionservices adminCollectionservices, ISP_Call ispcall)
        {
            _usermanager = usermanager;
            _adminCollectionservices = adminCollectionservices;
            _ispcall = ispcall;
    }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> collect(string mgrId, decimal amount)
        {
            var users = await _usermanager.FindByIdAsync(mgrId);
            var model = new adminCollectionViewModel
            {
                managerid = mgrId
                  ,
                managername = users.name
                  ,
                amount = 0
                  ,
                finalamt = amount
                  ,
                remaining = amount


            };
            return View(model);
           
        }
        [HttpPost]
        public async Task<IActionResult> collect(adminCollectionViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.finalamt < model.amount)
                {

                    ModelState.AddModelError("ModelOnly", "Please Collect Proper Amount");
                    return View(model);
                }
                else
                {
                    //var objcountry = new AdminCollection
                    //{

                    //    id = 0,
                    //    collectManagerId = model.managerid,
                    //    amount = model.amount,
                    //    date1 = DateTime.Now,
                    //    isdeleted = false
                    //};
                    var paramter = new DynamicParameters();
                   
                    paramter.Add("@amount", model.amount);
                    paramter.Add("@managerId", model.managerid);

                    _ispcall.Execute("AdminCollectionFromManager", paramter);

                     
                    TempData["success"] = "Record Saved successfully";
                    return RedirectToAction("ManagerList", "Account", new { roletype = "Manager" });
                }

            }
            else
            {
                return View(model);
            }

            //  return View(model);
        }
    }
}
