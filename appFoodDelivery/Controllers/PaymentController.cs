using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFoodDelivery.Models;
using appFoodDelivery.pagination;
using appFoodDelivery.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    public class PaymentController : Controller
    {
        private readonly  IdriverRegistrationServices _driverRegistrationServices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly ISP_Call _sP_Call;
        public PaymentController(IdriverRegistrationServices driverRegistrationServices, ISP_Call sP_Call, IstoredetailsServices storedetailsServices)
        {
            _sP_Call = sP_Call;
            _driverRegistrationServices = driverRegistrationServices;
            _storedetailsServices = storedetailsServices;
        }
        // GET: /<controller>/
        
        [HttpGet]
        public IActionResult deliveryboypaymentIndex(int? PageNumber)
        {
            var orderheaderList1 = _driverRegistrationServices.GetAll().Select(x => new driverPaymentViewModel
            {
                id = x.id
               ,
                name = x.name,
                profilephoto  = x.profilephoto,
               mobileno=x.mobileno,
               payamount=x.payamount

            });

            //var orderheaderList1 = _driverRegistrationServices.GetAll().OrderByDescending(x => x.payamount).ToList();

            //var paramter = new DynamicParameters();
            ////paramter.Add("@from", from1);          
            //var orderheaderList1 = _ISP_Call.List<collectionViewModel>("collectionReport", null);
            int PageSize = 10;
            return View(driverPaginational<driverPaymentViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));
        }
        [HttpGet]
        public async Task<IActionResult> deliveryboypayment(int id, string name, decimal amount)
        {
            var model = new driverAmountViewModel
            {
                id = id
                  ,
                drivername = name
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
        public async Task<IActionResult> deliveryboypayment(driverAmountViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.finalamt < model.amount)
                {

                    ModelState.AddModelError("ModelOnly", "Please Pay Proper Amount");
                    return View(model);
                }
                else
                {
                    var paramter = new DynamicParameters();
                    paramter.Add("@deliveryboyid", model.id);
                    paramter.Add("@amount", model.amount);
                    _sP_Call.Execute("insertdeliveryboypayamt", paramter);

                    TempData["success"] = "Amount Pay to Deliveryboy successfully";
                    return RedirectToAction(nameof(deliveryboypaymentIndex));
                }

            }
            else
            {
                return View(model);
            }

            //  return View(model);
        }

        [HttpGet]
        public IActionResult storepaymentIndex(int? PageNumber)
        {
           // var orderheaderList1 = _storedetailsServices.GetAll().ToList();
            var orderheaderList1 = _storedetailsServices.GetAll().Select(x => new storePaymentViewModel
            {
                id = x.id
              ,
                payamount = x.payamount,
                storeid = x.storeid,
                storename = x.storename 

            });

           // var paramter = new DynamicParameters();
            //paramter.Add("@from", from1);          
            //  var orderheaderList1 = _sP_Call.List<collectionViewModel>("storedetailsSelectAll", null);

            int PageSize = 10;
            return View(storepaymentPagination<storePaymentViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));
        }
        [HttpGet]
        public async Task<IActionResult> storepayment(string  id, string name, decimal amount)
        {
            var model = new storePayAmountViewModel
            {
                storeid = id
                  ,
                storename = name
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
        public async Task<IActionResult> storepayment(storePayAmountViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.finalamt < model.amount)
                {

                    ModelState.AddModelError("ModelOnly", "Please Pay Proper Amount");
                    return View(model);
                }
                else
                {
                    var paramter = new DynamicParameters();
                    paramter.Add("@storeid", model.storeid);
                    paramter.Add("@amount", model.amount);
                    _sP_Call.Execute("insertStorePaymentamt", paramter);

                    TempData["success"] = "Amount Pay to Store successfully";
                    return RedirectToAction(nameof(storepaymentIndex));
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


/*
 select
id,payamount, name, profilephoto, mobileno, emailid, password, gender, latitude, longitude, deviceid, createddate, biketype,
 manufacturename, modelname, modelyear, vehicleplateno, drivinglicphoto, vehicleinsurancephoto, isdeleted, isactive,
  accountno, banklocation, bankname, ifsccode, status, bloodgroup, payamount
from [admin_appFoodDelivery].[driverRegistration] order by id desc



select  
 id, deliveryboyid, amount, paydate, oid
 from  [admin_appFoodDelivery].[DriverPayamount]

 --truncate table DriverPayamount


 select id, customerid, amount, placedate, deliveryboyid, paymentstatus, orderstatus, isdeleted, discount, storeid
 , deliveryaddress, paymenttype, promocode, transactionid, instructions, customerdeliverylatitude, 
 customerdeliverylongitude, deliveryboylatitude, deliveryboylongitude, storelatitude, storelongitude, 
 deliveryboyCheckStaus, storeCheckStaus
 from [admin_appFoodDelivery].[orders] where id=3258 order by id desc


select id, storeid, contactpersonname, emailaddress, contactno, gender, fooddelivery, storename, radiusid, deliverytimeid,
 orderMinAmount, packagingCharges, storeBannerPhoto, address, description, storetime, licPhoto, isdeleted, cityid, latitude, 
 longitude, discount, promocode, accountno, banklocation, bankname, ifsccode, status, adminCommissionPer, taxstatus, taxstatusPer,
  payamount
  from [admin_appFoodDelivery].[storedetails]

  select 
  id, storeid, amount, paydate, oid
   from [admin_appFoodDelivery].[StoredPayamount]
 * */
