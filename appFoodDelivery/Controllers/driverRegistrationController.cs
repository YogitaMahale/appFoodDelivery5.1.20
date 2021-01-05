using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.pagination;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using plathora.pagination;
using System.Runtime.Serialization;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class driverRegistrationController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IdriverRegistrationServices _driverRegistrationServices;
        public driverRegistrationController(IdriverRegistrationServices driverRegistrationServices, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _driverRegistrationServices = driverRegistrationServices;
        }
        public IActionResult Index(int? PageNumber)
        {
            var storeList = _driverRegistrationServices.GetAll().Select(x => new DriverIndexViewModel
            {
                id = x.id
                ,
                name = x.name
                ,
                profilephoto = x.profilephoto
                ,
                mobileno = x.mobileno
                ,

                isactive = x.isactive
            }).ToList();
            //  return View(storeList);

            int PageSize = 10;
            return View(DriverPagination<DriverIndexViewModel>.Create(storeList, PageNumber ?? 1, PageSize));

        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new DriverCreateViewModel();
            return View(model);
        }
        public string ValidateMobileNo(string mobileno)
        {

            var emailStatus = _driverRegistrationServices.GetAll().Where(x => x.mobileno == mobileno && x.isdeleted == false).FirstOrDefault();
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
        public async Task<IActionResult> Create(DriverCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var store = new driverRegistration
                {
                    id = model.id
                    ,
                    name = model.name
                    //   , profilephoto=model.profilephoto
                    ,
                    mobileno = model.mobileno
                    ,
                    emailid = model.emailid
                    ,
                    password = model.password
                    ,
                    gender = model.gender
                    ,
                    latitude = ""
                    ,
                    longitude = ""
                    ,
                    deviceid = ""
                    ,
                    createddate = model.createddate
                    ,
                    isdeleted = false
                    ,
                    isactive = false

                    ,

                    biketype = model.biketype
,
                    manufacturename = model.manufacturename,
                    modelname = model.modelname,
                    modelyear = model.modelyear,
                    vehicleplateno = model.vehicleplateno,

                    accountno = model.accountno,
                    banklocation = model.banklocation,
                    bankname = model.bankname,
                    ifsccode = model.ifsccode,
                    status = model.status,
                    bloodgroup = model.bloodgroup
                    //drivinglicphoto = model.drivinglicphoto,
                    //vehicleinsurancephoto = model.vehicleinsurancephoto,

                };
                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/driver/profilephoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                    var extesion = Path.GetExtension(model.profilephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    store.profilephoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.drivinglicphoto != null && model.drivinglicphoto.Length > 0)
                {
                    var uploadDir = @"uploads/driver/drivingLicence";
                    var fileName = Path.GetFileNameWithoutExtension(model.drivinglicphoto.FileName);
                    var extesion = Path.GetExtension(model.drivinglicphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.drivinglicphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    store.drivinglicphoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.vehicleinsurancephoto != null && model.vehicleinsurancephoto.Length > 0)
                {
                    var uploadDir = @"uploads/driver/vehicleinsurancephoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.vehicleinsurancephoto.FileName);
                    var extesion = Path.GetExtension(model.vehicleinsurancephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.vehicleinsurancephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    store.vehicleinsurancephoto = '/' + uploadDir + '/' + fileName;

                }
                await _driverRegistrationServices.CreateAsync(store);
                TempData["success"] = "Record Save successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }


        public IActionResult Edit(int id)
        {
            var storeowner = _driverRegistrationServices.GetById(id);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new DriverEditViewModel()
            {
                id = storeowner.id,
                name = storeowner.name,
                mobileno = storeowner.mobileno,
                emailid = storeowner.emailid,
                password = storeowner.password,
                gender = storeowner.gender,


                biketype = storeowner.biketype,

                manufacturename = storeowner.manufacturename,
                modelname = storeowner.modelname,
                modelyear = storeowner.modelyear,
                vehicleplateno = storeowner.vehicleplateno,

                accountno = storeowner.accountno,
                bankname = storeowner.bankname,
                banklocation = storeowner.banklocation,
                ifsccode = storeowner.ifsccode,
                status = storeowner.status,
                bloodgroup = storeowner.bloodgroup

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DriverEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _driverRegistrationServices.GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                var chkduplicate = _driverRegistrationServices.GetAll().Where(x => x.mobileno == model.mobileno && x.id != model.id).FirstOrDefault();
                if (chkduplicate != null)
                {
                    ModelState.AddModelError("", "Duplicate Mobile No");
                    return View(model);
                }
                else
                {
                    storeobj.id = model.id;
                    storeobj.name = model.name;
                    storeobj.mobileno = model.mobileno;
                    storeobj.emailid = model.emailid;
                    storeobj.password = model.password;
                    storeobj.gender = model.gender;

                    storeobj.manufacturename = model.manufacturename;
                    storeobj.biketype = model.biketype;
                    storeobj.modelname = model.modelname;
                    storeobj.modelyear = model.modelyear;
                    storeobj.vehicleplateno = model.vehicleplateno;


                    storeobj.accountno = model.accountno;
                    storeobj.banklocation = model.banklocation;
                    storeobj.bankname = model.bankname;
                    storeobj.ifsccode = model.ifsccode;
                    storeobj.status = model.status;
                    storeobj.bloodgroup = model.bloodgroup;
                    if (model.profilephoto != null && model.profilephoto.Length > 0)
                    {
                        var uploadDir = @"uploads/driver/profilephoto";
                        var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                        var extesion = Path.GetExtension(model.profilephoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        storeobj.profilephoto = '/' + uploadDir + '/' + fileName;

                    }
                    if (model.drivinglicphoto != null && model.drivinglicphoto.Length > 0)
                    {
                        var uploadDir = @"uploads/driver/drivingLicence";
                        var fileName = Path.GetFileNameWithoutExtension(model.drivinglicphoto.FileName);
                        var extesion = Path.GetExtension(model.drivinglicphoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.drivinglicphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        storeobj.drivinglicphoto = '/' + uploadDir + '/' + fileName;

                    }
                    if (model.vehicleinsurancephoto != null && model.vehicleinsurancephoto.Length > 0)
                    {
                        var uploadDir = @"uploads/driver/vehicleinsurancephoto";
                        var fileName = Path.GetFileNameWithoutExtension(model.vehicleinsurancephoto.FileName);
                        var extesion = Path.GetExtension(model.vehicleinsurancephoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.vehicleinsurancephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        storeobj.vehicleinsurancephoto = '/' + uploadDir + '/' + fileName;

                    }
                    await _driverRegistrationServices.UpdateAsync(storeobj);
                    TempData["success"] = "Record Updated successfully";
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _driverRegistrationServices.Delete(id);
            TempData["success"] = "Record Delete successfully";
            return RedirectToAction(nameof(Index));



        }
    }
}
