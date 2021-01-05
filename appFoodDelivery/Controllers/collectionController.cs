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
           

            var paramter = new DynamicParameters();          

            //paramter.Add("@from", from1);          
            var orderheaderList1 = _ISP_Call.List<collectionViewModel>("collectionReport", null);


           
            int PageSize = 10;
            return View(OrderPagination<collectionViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        //[HttpPost]
        //public async Task<IActionResult> Index(int? PageNumber, string from1, string search)
        //{
        //  //  IEnumerable<SelectListItem> obj = _driverRegistrationServices.GetAlldriver();
        //  //  ViewData["deliveryboylist"] = obj;
        //    //---------------------------------------------
        //    ViewBag.from1 = from1;
        //  //  ViewBag.to1 = to1;
        //   // ViewBag.status1 = status;
        //   // ViewBag.deliveryboyid1 = deliveryboyid;

        //    //ApplicationUser usr = await GetCurrentUserAsync();
        //    //var user = await _usermanager.FindByIdAsync(usr.Id);
        //    //var role = await _usermanager.GetRolesAsync(user);
        //    //string roles = role[0].ToString();

        //    if (search != null)
        //    {

        //        var paramter = new DynamicParameters();
        //        //if (roles == "Admin")
        //        //{
        //        //    paramter.Add("@storeid", "");
        //        //}
        //        //else
        //        //{
        //        //    paramter.Add("@storeid", usr.Id);
        //        //}

        //        DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //       // DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //      //  paramter.Add("@status", status);
        //        paramter.Add("@from", l1);
        //     //   paramter.Add("@to", l2);
        //       // paramter.Add("@deliveryboyid", deliveryboyid);
        //        var orderheaderList1 = _ISP_Call.List<collectionViewModel>("collectionReport", paramter);

        //        //  return View(orderheaderList1.ToList());
        //        int PageSize = 10;

        //        return View(OrderPagination<collectionViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

        //    }
        //    //else if (ExcelFileDownload != null)
        //    //{

        //    //    var paramter = new DynamicParameters();
        //    //    if (roles == "Admin")
        //    //    {
        //    //        paramter.Add("@storeid", "");
        //    //    }
        //    //    else
        //    //    {
        //    //        paramter.Add("@storeid", usr.Id);
        //    //    }
        //    //    DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    //    DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //    //    paramter.Add("@status", status);
        //    //    paramter.Add("@from", l1);
        //    //    paramter.Add("@to", l2);
        //    //    paramter.Add("@deliveryboyid", deliveryboyid);
        //    //    var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport", paramter);

        //    //    string deliveryname = _driverRegistrationServices.GetById(deliveryboyid).name;


        //    //    var builder = new StringBuilder();
        //    //    builder.AppendLine("Order ID,Store ,Customer,Fianl Amount,Customer Amount,Customer Delivery Charges,Delivery boy Charges,Order Status,Deliveryboy ,Date");
        //    //    decimal tot_finalamt = 0;
        //    //    decimal tot_customeramt = 0;
        //    //    decimal tot_customerdeliverycharges = 0;
        //    //    decimal tot_deliveryboycharges = 0;
        //    //    foreach (var item in orderheaderList1)
        //    //    {
        //    //        tot_finalamt += item.finalamt;
        //    //        tot_customeramt += item.customeramt;
        //    //        tot_customerdeliverycharges += item.customerdeliverycharges;
        //    //        tot_deliveryboycharges += item.deliveryboycharges;
        //    //        builder.AppendLine($"{item.id},{item.storename},{item.customerName},{item.finalamt },{item.customeramt},{item.customerdeliverycharges},{item.deliveryboycharges},{item.orderstatus },{item.deliveryboyName},{item.placedate }");
        //    //    }
        //    //    builder.AppendLine($"{""},{""},{"Total :"},{tot_finalamt },{tot_customeramt},{tot_customerdeliverycharges},{tot_deliveryboycharges},{"" },{""},{"" }");
        //    //    string namee = deliveryname + "_OrderHistory.csv";
        //    //    return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", namee);
        //    //}


        //    else
        //    {
        //        return View();
        //    }



        //}
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
                    var paramter = new DynamicParameters();
                    paramter.Add("@deliveryboyid", model.deliveryboyid);
                    paramter.Add("@amount", model.amount);
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
