using appFoodDelivery.Models;
using appFoodDelivery.Notification;
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
    public class customerNotificationController : Controller
    {
        public fcmNotification objfcmNotification = new fcmNotification();
        private readonly ICustomerRegistrationservices _customerRegistrationservices;
        public customerNotificationController(ICustomerRegistrationservices customerRegistrationservices)
        {
            _customerRegistrationservices = customerRegistrationservices;
        }

        public IActionResult Index()
        {

            var obj = new CustomerNotification();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CustomerNotification model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string message = model.description;
                    string title = model.title;
                    //var storeobj = _customerRegistrationservices.GetAll().Where(x => x.isdeleted == false && x.deviceid != null&&x.mobileno1=="9021517586").Select(x=>x.deviceid).ToList();
                    var storeobj = _customerRegistrationservices.GetAll().Where(x => x.isdeleted == false && x.deviceid != null).Select(x => x.deviceid).ToList();
                    //foreach (var item in storeobj)
                    //{
                    //    if (item.deviceid.Trim() == "" || item.deviceid == null)
                    //    { }
                    //    else
                    //    {


                    //        objfcmNotification.customerNotification(item.deviceid, message, "", title);

                    //    }



                    //}
                    objfcmNotification.BulkCustomerSendNotification(storeobj,message,"",title);
                    // objfcmNotification.BulkCustomerSendNotification(Enumerable.Repeat("test", 1010).ToList(), "tickerText", "contentTitle", "message");
                }
                catch { }

                TempData["success"] = "Notification Sent Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }
    }
}
