using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Notification;
using appFoodDelivery.pagination;
using appFoodDelivery.Services;
using appFoodDelivery.Services.Implementation;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Controllers
{
    public class AssignDeliveryboyToManagerController : Controller
    {
        private readonly IAssignDeliveryboyToManagerServices _assignDeliveryboyToManagerServices;
        private readonly IdriverRegistrationServices _driverRegistrationServices;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly ISP_Call _ispcall;
        public AssignDeliveryboyToManagerController(IAssignDeliveryboyToManagerServices assignDeliveryboyToManagerServices, IdriverRegistrationServices driverRegistrationServices, UserManager<ApplicationUser> usermanager, ISP_Call ispcall)
        {
            _assignDeliveryboyToManagerServices = assignDeliveryboyToManagerServices;
            _driverRegistrationServices = driverRegistrationServices;
            _usermanager = usermanager;
            _ispcall = ispcall;

        }
        public async Task<IActionResult> Index()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
 
            var countrydetails = _assignDeliveryboyToManagerServices.GetAll().Where(x=>x.managerId==user.Id).Select(x => new AssignDeliveryboyToManagerViewModel
            {
                Id = x.Id,
                managerId = x.managerId,
                deliveryboyid = x.deliveryboyid,
                deliveryboyname = _driverRegistrationServices.GetById(x.deliveryboyid).name

            }).ToList();
            return View(countrydetails);
            //IEnumerable<SelectListItem> obj = _driverRegistrationServices.GetAlldriver();
            //ViewData["deliveryboylist"] = obj;
             
        }
        [HttpGet]
        public IActionResult Create()
        {
            var parameter = new DynamicParameters();
            var listt = _ispcall.List<driverListModel>("getNotAssignDeliveryBoy", null);

            //var deliveryboyidd = _assignDeliveryboyToManagerServices.GetAll().Select(x => x.deliveryboyid);


            //var query = _driverRegistrationServices.GetAll().Select(x => new { x.id, x.name }).Except(deliveryboyidd);
            ViewBag.deliveryboy = listt;
            // ViewBag.deliveryboy = _driverRegistrationServices.GetAll().Select(x=>x.id).Except(deliveryboyidd);
            var model = new AssignDeliveryboyToManagerViewModel();
            return View(model);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _usermanager.GetUserAsync(HttpContext.User);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssignDeliveryboyToManagerViewModel model)
        {

            if (ModelState.IsValid)
            {

                ApplicationUser usr = await GetCurrentUserAsync();
                var user = await _usermanager.FindByIdAsync(usr.Id);

                var obj = _assignDeliveryboyToManagerServices.GetAll().Where(x => x.managerId == user.Id && x.deliveryboyid == model.deliveryboyid).FirstOrDefault();
                if(obj!=null)
                {
                    TempData["error"] = "Duplicate Deliveryboy";
                }
                else
                {
                var objcountry = new AssignDeliveryboyToManager
                {
                    Id = model.Id,
                    deliveryboyid = model.deliveryboyid,
                    managerId = user.Id

                };
                await _assignDeliveryboyToManagerServices.CreateAsync(objcountry);
                TempData["success"] = "Record Saved successfully";
                }
                

               
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
            await _assignDeliveryboyToManagerServices.Delete(id);
            TempData["success"] = "Record Deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}