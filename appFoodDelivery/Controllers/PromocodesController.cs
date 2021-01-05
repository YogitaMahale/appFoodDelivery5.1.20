using appFoodDelivery.Entity;
using appFoodDelivery.Models;
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
    public class PromocodesController : Controller
    {
        private readonly IpromocodeServices _promocodeServices;
        public PromocodesController(IpromocodeServices promocodeServices)
        {
            _promocodeServices = promocodeServices;
            //_hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var customer = _promocodeServices.GetAll().Select(x => new promocodeIndexViewModel
            {
                id = x.id
               ,
                promocode = x.promocode
               ,
                promocodeusagelimit = x.promocodeusagelimit
               ,
                discount = x.discount
               ,
                discounttype = x.discounttype
               ,
                expirydate = x.expirydate
               ,
                createddate = x.createddate
               ,
                isdeleted = x.isdeleted
               ,
                isactive = x.isactive


            }).ToList();
            // return View(affilatemaster);

            return View(customer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new promocodeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(promocodeCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var obj = new promocodemaster
                {
                    id = model.id
                    ,
                    promocode = model.promocode
                    ,
                    promocodeusagelimit = model.promocodeusagelimit
                    ,
                    discount = model.discount
                    ,
                    discounttype = model.discounttype
                    ,
                    expirydate = model.expirydate
                    ,
                    createddate = DateTime.Now
                    ,
                    isdeleted = false
                    ,
                    isactive = false
                };

                await _promocodeServices.CreateAsync(obj);
                TempData["success"] = "Record Saved successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            var objcustomer = _promocodeServices.GetById(id);
            if (objcustomer == null)
            {
                return NotFound();
            }
            var model = new promocodeEditViewModel
            {
                id = objcustomer.id
                ,
                promocode = objcustomer.promocode
                // , profilephoto = objcustomer.profilephoto
                ,
                promocodeusagelimit = objcustomer.promocodeusagelimit
                ,
                discount = objcustomer.discount
                ,
                discounttype = objcustomer.discounttype
                ,
                expirydate = objcustomer.expirydate

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(promocodeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customerobj = _promocodeServices.GetById(model.id);
                if (customerobj == null)
                {
                    return NotFound();
                }
                customerobj.id = model.id;
                customerobj.promocode = model.promocode;

                customerobj.promocodeusagelimit = model.promocodeusagelimit;
                //  customerobj.mobileno1 = model.mobileno1;
                customerobj.discount = model.discount;
                customerobj.discounttype = model.discounttype;
                customerobj.expirydate = model.expirydate;



                await _promocodeServices.UpdateAsync(customerobj);
                TempData["success"] = "Record Updated successfully";
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
            await _promocodeServices.Delete(id);
            TempData["success"] = "Record Delete successfully";
            return RedirectToAction(nameof(Index));



        }
    }
}
