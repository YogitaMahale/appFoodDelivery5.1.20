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
using System.Threading.Tasks;

namespace appFoodDelivery.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class CustomerRegistrationController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICustomerRegistrationservices _CustomerRegistrationservices;
        public CustomerRegistrationController(ICustomerRegistrationservices CustomerRegistrationservices, IWebHostEnvironment hostingEnvironment)
        {
            _CustomerRegistrationservices = CustomerRegistrationservices;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(int? PageNumber)
        {
            var customer = _CustomerRegistrationservices.GetAll().Select(x => new CustomerRegistrationIndexViewModel
            {
                id = x.id,
                name = x.name,
                profilephoto = x.profilephoto,
                mobileno1 = x.mobileno1,
                address = x.address,
                gender = x.gender,
                DOB = x.DOB,
                createddate = x.createddate,

            }).OrderByDescending(x=>x.id).ToList();
            // return View(affilatemaster);
            int PageSize = 30;
            return View(CustomerRegPagination<CustomerRegistrationIndexViewModel>.Create(customer, PageNumber ?? 1, PageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerRegistrationCreateViewModel();
            return View(model);
        }

        public string ValidateMobileNo(string mobileno)
        {

            var emailStatus = _CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
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
        public async Task<IActionResult> Create(CustomerRegistrationCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var cust = _CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == model.mobileno1).FirstOrDefault();
                if (cust == null)
                {
                    var objcustomerRegistration = new CustomerRegistration
                    {
                        id = model.id
                        ,
                        name = model.name
                        ,
                        address = model.address
                        ,
                        mobileno1 = model.mobileno1
                        ,
                        mobileno2 = model.mobileno2
                        ,
                        emailid1 = model.emailid1
                        ,
                        latitude = model.latitude
                        ,
                        longitude = model.longitude
                        ,
                        password = model.password
                        ,
                        gender = model.gender
                        ,
                        DOB = model.DOB
                        ,
                        createddate = model.createddate
                        ,
                        isdeleted = false
                        ,
                        isactive = false
                    };

                    if (model.profilephoto != null && model.profilephoto.Length > 0)
                    {
                        var uploadDir = @"uploads/customer";
                        var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                        var extesion = Path.GetExtension(model.profilephoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        // await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        FileStream fs = new FileStream(path, FileMode.Create);
                        await model.profilephoto.CopyToAsync(fs);
                        fs.Close();

                        objcustomerRegistration.profilephoto = '/' + uploadDir + '/' + fileName;

                    }
                    await _CustomerRegistrationservices.CreateAsync(objcustomerRegistration);
                    //var postId = await _CustomerRegistrationservices.CreateAsync(objcustomerRegistration);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var objcustomer = _CustomerRegistrationservices.GetById(id);
            if (objcustomer == null)
            {
                return NotFound();
            }
            var model = new CustomerRegistrationEditViewModel
            {
                id = objcustomer.id
                ,
                name = objcustomer.name
                // , profilephoto = objcustomer.profilephoto
                ,
                address = objcustomer.address
                ,
                mobileno1 = objcustomer.mobileno1
                ,
                mobileno2 = objcustomer.mobileno2
                ,
                emailid1 = objcustomer.emailid1
                ,
                latitude = objcustomer.latitude
                ,
                longitude = objcustomer.longitude
                ,
                password = objcustomer.password
                ,
                gender = objcustomer.gender
                ,
                DOB = objcustomer.DOB
            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerRegistrationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customerobj = _CustomerRegistrationservices.GetById(model.id);
                if (customerobj == null)
                {
                    return NotFound();
                }
                customerobj.id = model.id;
                customerobj.name = model.name;

                customerobj.address = model.address;
                //  customerobj.mobileno1 = model.mobileno1;
                customerobj.mobileno2 = model.mobileno2;
                customerobj.emailid1 = model.emailid1;
                customerobj.latitude = model.latitude;
                customerobj.longitude = model.longitude;
                customerobj.password = model.password;
                customerobj.gender = model.gender;
                customerobj.DOB = model.DOB;

                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/customer";
                    var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                    var extesion = Path.GetExtension(model.profilephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;

                    if (customerobj.profilephoto != null)
                    {
                        var imagePath = webRootPath + customerobj.profilephoto.ToString().Replace("/", "\\");
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                    }


                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    //  await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    FileStream fs = new FileStream(path, FileMode.Create);
                    await model.profilephoto.CopyToAsync(fs);
                    fs.Close();

                    customerobj.profilephoto = '/' + uploadDir + '/' + fileName;

                }

                await _CustomerRegistrationservices.UpdateAsync(customerobj);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        //[HttpGet]
        //public IActionResult Details(int id)
        //{
        //    var model = _AffiltateRegistrationService.GetById(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    AffiltateRegistrationDetailsViewModel obj = new AffiltateRegistrationDetailsViewModel()
        //    {
        //        id = model.id,
        //        name = model.name,
        //        profilephoto = model.profilephoto,
        //        mobileno1 = model.mobileno1,
        //        mobileno2 = model.mobileno2,
        //        emailid1 = model.emailid1,
        //        emailid2 = model.emailid2,
        //        adharcardno = model.adharcardno,
        //        adharcardphoto = model.adharcardphoto,
        //        pancardno = model.pancardno,
        //        pancardphoto = model.pancardphoto,
        //        password = model.password,
        //        gender = model.gender,
        //        DOB = model.DOB,
        //        createddate = model.createddate

        //    };
        //    return View(obj);
        //}


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _CustomerRegistrationservices.Delete(id);
            return RedirectToAction(nameof(Index));



        }
        [HttpPost]
        public IActionResult Index1(string selectedDate)
        {
            ViewBag.Message = "Selected Date: " + selectedDate;
            return View();
        }
    }
}
