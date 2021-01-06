using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ISP_Call _sP_Call;

        public FeedbackController(ISP_Call sP_Call)
        {
            _sP_Call = sP_Call;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult customerTodeliveryboyFeedback()
        {
          
            return View();
        }
        [HttpGet]
        public IActionResult customerToStoreFeedback()
        {
            return View();
        }
        [HttpGet]
        public IActionResult deliveryboyCustomerFeedback()
        {
            return View();
        }

        #region API Calls
        public async Task<IActionResult> customerTodeliveryboyFeedbackJson(string status)
        {
            var listt = _sP_Call.List<customerTodeliveryboyFeedback>("customerTodeliveryboyFeedback", null);
            return Json(new { data = listt });


        }
        public async Task<IActionResult> customerToStoreFeedbackJson(string status)
        {
            var listt = _sP_Call.List<customerToStoreFeedback>("customerToStoreFeedback", null);
            return Json(new { data = listt });

        }
        public async Task<IActionResult> deliveryboyCustomerFeedbackJson(string status)
        {
            var listt = _sP_Call.List<deliveryboyCustomerFeedback>("deliveryboyCustomerFeedback", null);
            return Json(new { data = listt });

        }
        #endregion
    }
}
