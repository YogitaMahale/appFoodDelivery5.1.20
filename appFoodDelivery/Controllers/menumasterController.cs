using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class menumasterController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Imenumasterservices _menumasterservices;
        private readonly Iproductcuisinemasterservices _productcuisinemasterservices;

        public menumasterController(Imenumasterservices menumasterservices, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment, Iproductcuisinemasterservices productcuisinemasterservices)
        {
            _userManager = userManager;
            _menumasterservices = menumasterservices;
            _hostingEnvironment = hostingEnvironment;
            _productcuisinemasterservices = productcuisinemasterservices;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public async Task<IActionResult> Index()
        {
            //ApplicationUser usr = await GetCurrentUserAsync();
            //var id = usr.Id;
            var listt = _menumasterservices.GetAll().Select(x => new MenumasterIndexViewModel
            {
                id = x.id
                ,
                name = x.name,
                img = x.img,
                cusinename = _productcuisinemasterservices.GetById(x.productcuisineid).name


            });
            //  return View(storeList);


            return View(listt);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.productcuisine = _productcuisinemasterservices.GetAll().ToList();
            var model = new MenumasterCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenumasterCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //ApplicationUser usr = await GetCurrentUserAsync();
                //var id = usr.Id;
                var store = new menumaster
                {
                    id = model.id
                    ,
                    name = model.name
                   //   , profilephoto=model.profilephoto
                   ,
                    isdeleted = false
                    ,
                    isactive = false,
                    productcuisineid = model.productcuisineid


                };
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/product";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    store.img = '/' + uploadDir + '/' + fileName;

                }
                await _menumasterservices.CreateAsync(store);
                TempData["success"] = "Record Save successfully";
                return RedirectToAction(nameof(test));
            }
            else
            {
                return View();

            }
        }


        public IActionResult Edit(int id)
        {
            ViewBag.productcuisine = _productcuisinemasterservices.GetAll().ToList();
            var storeowner = _menumasterservices.GetById(id);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new MenumasterEditViewModel()
            {
                id = storeowner.id,
                name = storeowner.name,
                productcuisineid = storeowner.productcuisineid

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MenumasterEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _menumasterservices.GetById(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.name = model.name;
                storeobj.productcuisineid = model.productcuisineid;
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/product";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    storeobj.img = '/' + uploadDir + '/' + fileName;

                }
                await _menumasterservices.UpdateAsync(storeobj);
                TempData["success"] = "Record Update successfully";
                return RedirectToAction(nameof(test));
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            await _menumasterservices.Delete(id);
            TempData["success"] = "Menu Deleted Successfully";
            return RedirectToAction(nameof(test));



        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var obj = _menumasterservices.GetById(id);
        //    if (obj == null)
        //    {
        //        return Json(new { success = false, message = "Error while Deleting" });

        //    }
        //    await _menumasterservices.Delete(id);

        //    return Json(new { success = false, message = "Delete Successfuklly" });



        //}


        public IActionResult test()
        {
            ViewBag.cusineList = _productcuisinemasterservices.GetAll().ToList();
            return View();
        }

        #region "API CALL"
        [HttpGet]
        public IActionResult GetALL(int id)
        {
            //var listt = _menumasterservices.GetAll().Select(x => new MenumasterIndexViewModel
            //{
            //    id = x.id
            //     ,
            //    name = x.name,
            //    img = x.img,
            //    productcuisineid=x.productcuisineid,
            //    cusinename = _productcuisinemasterservices.GetById(x.productcuisineid).name


            //});
            var obj = _menumasterservices.GetAll().Where(x => x.productcuisineid == id);
            return Json(new { data = obj });
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var obj = _unitofWork.category.Get(id);
        //    if (obj == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleteing" });
        //    }
        //    _unitofWork.category.Remove(obj);
        //    _unitofWork.Save();
        //    return Json(new { success = true, message = "Delete Successfuly" });
        //}
        #endregion
    }
}
