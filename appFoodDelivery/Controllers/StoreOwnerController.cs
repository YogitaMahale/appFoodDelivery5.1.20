using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;
using appFoodDelivery.Models;
using appFoodDelivery.Entity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
//using plathora.pagination;
using System.Runtime.Serialization;
using appFoodDelivery.pagination;
using Microsoft.AspNetCore.Authorization;

namespace appFoodDelivery.Controllers
{
  //  [Authorize(Roles ="Admin")]
    public class StoreOwnerController:Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly Istoreownerservices _storeownerservices;
        public StoreOwnerController(Istoreownerservices storeownerservices, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _storeownerservices = storeownerservices;
        }
        public IActionResult Index(int? PageNumber)
        {
            var storeList = _storeownerservices.GetAll().Select(x => new StoreOwnerIndexViewModel
            {
                id=x.id
                , name=x.name
                , profilephoto=x.profilephoto
                , mobileno=x.mobileno
                , emailid=x.emailid
                , password=x.profilephoto
                , gender=x.gender
                , createddate=x.createddate
                , isactive=x.isactive
            }).ToList();
          //  return View(storeList);
           
            int PageSize = 4;
            return View(StoreOwnerPagination<StoreOwnerIndexViewModel>.Create(storeList, PageNumber ?? 1, PageSize));

        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new StoreOwnerCreateViewModel();
            return View(model);
        }
        public string ValidateMobileNo(string mobileno)
        {

            var emailStatus = _storeownerservices.GetAll().Where(x => x.mobileno == mobileno && x.isdeleted == false).FirstOrDefault();
            if (emailStatus != null)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StoreOwnerCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var store = new storeowner
                {
                    id=model.id
                    , name=model.name
                 //   , profilephoto=model.profilephoto
                    , mobileno=model.mobileno
                    , emailid=model.emailid
                    , password=model.password
                    , gender=model.gender
                    , latitude=""
                    , longitude=""
                    , deviceid=""
                    , createddate=model.createddate
                    , isdeleted=false
                    , isactive=false

                };
                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/storeowner";
                    var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                    var extesion = Path.GetExtension(model.profilephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    store.profilephoto = '/' + uploadDir + '/' + fileName;

                }
                await _storeownerservices.CreateAsync(store);
                 
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
                    
            }
        }


        public IActionResult Edit(int id)
        {
            var storeowner = _storeownerservices.GetById(id);
            if(storeowner==null)
            {
                return NotFound();
            }
            var model = new StoreOwnerEditViewModel()
            {
                id = storeowner.id,
                name = storeowner.name,
                mobileno = storeowner.mobileno,
                emailid=storeowner.emailid,
                password=storeowner.password,
                gender=storeowner.gender                             
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StoreOwnerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _storeownerservices.GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.name = model.name;
                storeobj.mobileno = model.mobileno;
                storeobj.emailid = model.emailid;
                storeobj.password = model.password;
                storeobj.gender  = model.gender;
                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/storeowner";
                    var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                    var extesion = Path.GetExtension(model.profilephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    storeobj.profilephoto = '/' + uploadDir + '/' + fileName;

                }

                await _storeownerservices.UpdateAsync(storeobj);
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
            await _storeownerservices.Delete(id);
            return RedirectToAction(nameof(Index));



        }
    }
}
