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
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Manager)]
    public class collectionController : Controller
    {

        
        private readonly ISP_Call _ispcall;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IordersServices _ordersServices;
        private readonly ICustomerRegistrationservices _CustomerRegistrationservices;
        private readonly ISP_Call _ISP_Call;
        private readonly IdriverRegistrationServices _driverRegistrationServices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IdistanceServices _distanceServices;
        public fcmNotification objfcmNotification = new fcmNotification();
        public collectionController(UserManager<ApplicationUser> usermanager, ISP_Call ispcall, IordersServices ordersServices, ICustomerRegistrationservices CustomerRegistrationservices, ISP_Call ISP_Call, IdriverRegistrationServices driverRegistrationServices, IstoredetailsServices storedetailsServices, IdistanceServices distanceServices)
        {
            this._usermanager = usermanager;
            _ISP_Call = ispcall;
            _ispcall = ispcall;
            _ordersServices = ordersServices;
            _CustomerRegistrationservices = CustomerRegistrationservices;
            _driverRegistrationServices = driverRegistrationServices;
            _storedetailsServices = storedetailsServices;
            _distanceServices = distanceServices;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _usermanager.GetUserAsync(HttpContext.User);

        [HttpGet]
        public async Task<IActionResult> Index(int? PageNumber)
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);


            var paramter = new DynamicParameters();

            paramter.Add("@managerid", user.Id);          
            var orderheaderList1 = _ISP_Call.List<collectionViewModel>("collectionReport", paramter);


           
            int PageSize = 10;
            return View(OrderPagination<collectionViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        
        [HttpGet]
        public async Task<IActionResult> collect(int id,string name,decimal amount)
        {
            var model = new collectAmountViewModel
            {
                deliveryboyid = id
                  ,
                deliveryboyname =name 
                  ,
                amount  = 0
                  ,
                finalamt= amount
                  ,
                remaining = amount


            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> collect(collectAmountViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                if(model.finalamt<model.amount)
                {

                    ModelState.AddModelError("ModelOnly", "Please Collect Proper Amount");
                    return View(model);
                }
                else
                {
                    ApplicationUser usr = await GetCurrentUserAsync();
                    var user = await _usermanager.FindByIdAsync(usr.Id);
                    

                    var paramter = new DynamicParameters();
                    paramter.Add("@deliveryboyid", model.deliveryboyid);
                    paramter.Add("@amount", model.amount);
                    paramter.Add("@managerId", user.Id);
                    
                    _ISP_Call.Execute("insertdeliveryboyamt", paramter);

                    TempData["success"] = "Amount Updated successfully";
                    return RedirectToAction(nameof(Index));
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
