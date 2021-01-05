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
                    var storeobj = _customerRegistrationservices.GetAll().Where(x => x.isdeleted == false && x.deviceid != null).ToList();
                    foreach (var item in storeobj)
                    {
                        if (item.deviceid.Trim() == "" || item.deviceid == null)
                        { }
                        else
                        {
                            string message = model.description;
                            string title = model.title;

                            objfcmNotification.customerNotification(item.deviceid, message, "", title);

                        }



                    }

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
