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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class sliderController : Controller
    {

        private readonly IsliderServices _sliderServices;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public sliderController(IsliderServices sliderServices
                               , IWebHostEnvironment hostingEnvironment
                                )
        {
            _hostingEnvironment = hostingEnvironment;
            _sliderServices = sliderServices;

        }
        public async Task<IActionResult> Index()
        {

            var listt = _sliderServices.GetAll().Where(x => x.isdeleted == false).Select(x => new sliderIndexViewModel
            {
                id = x.id
                  ,
                name = x.name

            }).ToList();
            //  return View(storeList);


            return View(listt);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {



            var model = new sliderCreateViewModel();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(sliderCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

                var store = new slider
                {

                    id = model.id,

                    isdeleted = false
                    ,
                    isactive = false


                };
                if (model.name != null && model.name.Length > 0)
                {
                    var uploadDir = @"uploads/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.name.FileName);
                    var extesion = Path.GetExtension(model.name.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    FileStream fs = new FileStream(path, FileMode.Create);

                    await model.name.CopyToAsync(fs);
                    fs.Close();
                    store.name = '/' + uploadDir + '/' + fileName;

                }
                await _sliderServices.CreateAsync(store);
                TempData["success"] = "Record Saved successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }


        public async Task<IActionResult> Edit(int id)
        {



            var prod = _sliderServices.GetById(id);
            if (prod == null)
            {
                return NotFound();
            }
            var model = new sliderCreateViewModel()
            {
                id = prod.id,
                // name = prod.name,


            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(sliderCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _sliderServices.GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                storeobj.id = model.id;


                if (model.name != null && model.name.Length > 0)
                {
                    var uploadDir = @"uploads/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.name.FileName);
                    var extesion = Path.GetExtension(model.name.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;

                    if (storeobj.name != null)
                    {
                        var imagePath = webRootPath + storeobj.name.ToString().Replace("/", "\\");
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                    }
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    FileStream fs = new FileStream(path, FileMode.Create);

                    await model.name.CopyToAsync(fs);
                    fs.Close();
                    storeobj.name = '/' + uploadDir + '/' + fileName;

                }

                await _sliderServices.UpdateAsync(storeobj);
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
            await _sliderServices.Delete(id);
            TempData["success"] = "Record Delete successfully";
            return RedirectToAction(nameof(Index));



        }
    }
}
