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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
namespace appFoodDelivery.Controllers
{
    public class managerOrderController : Controller
    {
        private readonly ISP_Call _ispcall;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IordersServices _ordersServices;
        private readonly IorderhistoryServices _orderhistoryServices;
        private readonly ICustomerRegistrationservices _CustomerRegistrationservices;
        private readonly ISP_Call _ISP_Call;
        private readonly IdriverRegistrationServices _driverRegistrationServices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IdistanceServices _distanceServices;
        private readonly IdeliveryboyPendingAmtServices _deliveryboyPendingAmtServices;
        public fcmNotification objfcmNotification = new fcmNotification();
        public managerOrderController(UserManager<ApplicationUser> usermanager, ISP_Call ispcall, IordersServices ordersServices, ICustomerRegistrationservices CustomerRegistrationservices, ISP_Call ISP_Call, IdriverRegistrationServices driverRegistrationServices, IstoredetailsServices storedetailsServices, IdistanceServices distanceServices, IdeliveryboyPendingAmtServices deliveryboyPendingAmtServices, IorderhistoryServices orderhistoryServices)
        {
            this._usermanager = usermanager;
            _ISP_Call = ispcall;
            _ispcall = ispcall;
            _ordersServices = ordersServices;
            _CustomerRegistrationservices = CustomerRegistrationservices;
            _driverRegistrationServices = driverRegistrationServices;
            _storedetailsServices = storedetailsServices;
            _distanceServices = distanceServices;
            _deliveryboyPendingAmtServices = deliveryboyPendingAmtServices;
            _orderhistoryServices = orderhistoryServices;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _usermanager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            return View();
        }
        #region API Calls

        public async Task<IActionResult> GetOrderList(string status)
        {

            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();
            IEnumerable<orders> orderheaderList;
            //-------------------------------------------
            orderheaderList = _ordersServices.GetAll();
           
                var paramter = new DynamicParameters();
                paramter.Add("@storeid", usr.Id);
               paramter.Add("@status", status);
                //storedetailsListViewmodel
                var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("ManagerOrderSelectAll", paramter);
                //   orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
                return Json(new { data = orderheaderList1 });
            
           

        }
        #endregion
    }
}
