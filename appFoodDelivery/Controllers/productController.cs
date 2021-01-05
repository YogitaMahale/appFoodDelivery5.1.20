using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using AspNetCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Store)]
    public class productController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Iproductcuisinemasterservices _productcuisinemasterservices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly Iproductservices _productservices;
        private readonly Imenumasterservices _menumasterservices;
        public productController(Iproductservices productservices
                               , Iproductcuisinemasterservices productcuisinemasterservices
                               , IWebHostEnvironment hostingEnvironment
                                , UserManager<ApplicationUser> userManager
                                , Imenumasterservices menumasterservices)
        {
            _hostingEnvironment = hostingEnvironment;
            _productcuisinemasterservices = productcuisinemasterservices;
            _productservices = productservices;
            _userManager = userManager;
            _menumasterservices = menumasterservices;
        }
        public async Task<IActionResult> Index()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var listt = _productservices.GetAll().Where(x => x.storeid == id&&x.isdeleted==false&& x.fkmenuid!=0).Select(x => new productIndexViewModel
            {
                id = x.id
                   ,
                storeid = x.storeid
                   ,
                productcuisineid = x.productcuisineid
                   ,
                productcuisinemaster = _productcuisinemasterservices.GetById(x.productcuisineid)
                       ,
                name = _menumasterservices.GetById(x.fkmenuid).name
                      ,
                img = _menumasterservices.GetById(x.fkmenuid).img



                   ,
                foodtype = x.foodtype
                   ,
                amount = x.amount
                   ,
                description = x.description
                   ,
                discounttype = x.discounttype
                   ,
                discountamount = x.discountamount

            }).ToList();
            //  return View(storeList);


            return View(listt);

        }

        public IActionResult GetMenuList(int id)
        {


            IList<menumaster> obj = _menumasterservices.GetAll().Where(x => x.productcuisineid == id).ToList();
            obj.Insert(0, new menumaster { id = 0, name = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "name"));


            //ViewBag.productcuisine = _productcuisinemasterservices.GetAll().ToList();
            //ViewBag.MenuList = _menumasterservices.GetAllMenuList(Convert.ToInt16(cusineid));
            //return View("Create");
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //ApplicationUser usr = await GetCurrentUserAsync();
            //var id = usr.Id;

            ViewBag.productcuisine = _productcuisinemasterservices.GetAll().ToList();
            var model = new productCreateViewModel();
            return View(model);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(productCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usr = await GetCurrentUserAsync();
                var id = usr.Id;
                var store = new product
                {
                    //id, productcuisineid, name, img, foodtype, amount, description, discounttype, discountamount,
                    //createddate, isdeleted, isactive, storeid
                    id = model.id,
                    productcuisineid = model.productcuisineid,
                    name = model.fkmenuid.ToString(),
                    fkmenuid = model.fkmenuid,
                    foodtype = model.foodtype,
                    amount = model.amount,
                    description = model.description,
                    discounttype = model.discounttype,
                    discountamount = model.discountamount,
                    createddate = model.createddate
                    ,
                    isdeleted = false
                    ,
                    isactive = false
                    ,
                    storeid = id
                    ,
                    status = model.status


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
                await _productservices.CreateAsync(store);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            //ApplicationUser usr = await GetCurrentUserAsync();
            //var id1 = usr.Id;

            ViewBag.productcuisine = _productcuisinemasterservices.GetAll().ToList();
            var prod = _productservices.GetById(id);
            if (prod == null)
            {
                return NotFound();
            }
            var model = new productEditViewModel()
            {
                id = prod.id,
                name = prod.name,
                productcuisineid = prod.productcuisineid,
                foodtype = prod.foodtype,
                amount = prod.amount,
                description = prod.description,
                discounttype = prod.discounttype,
                discountamount = prod.discountamount,
                status = prod.status,
                fkmenuid = prod.fkmenuid

            };
            ViewBag.Menus = _menumasterservices.GetAllMenuList(model.productcuisineid);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(productEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _productservices.GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.name = model.name;


                storeobj.productcuisineid = model.productcuisineid;
                storeobj.foodtype = model.foodtype;
                storeobj.amount = model.amount;
                storeobj.description = model.description;
                storeobj.discounttype = model.discounttype;
                storeobj.discountamount = model.discountamount;
                storeobj.status = model.status;
                storeobj.fkmenuid = model.fkmenuid;

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
                await _productservices.UpdateAsync(storeobj);
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
            await _productservices.Delete(id);
            return RedirectToAction(nameof(Index));



        }
    }
}
