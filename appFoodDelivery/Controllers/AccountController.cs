﻿using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Models.dtos;
using appFoodDelivery.pagination;
using appFoodDelivery.Services;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Controllers
{

    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signinmanager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IRadiusMasterServices _RadiusMasterServices;
        private readonly IDeliveryTimeMasterServices _DeliveryTimeMasterServices;
        private readonly Iproductservices _productservices;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICityRegistrationservices _cityRegistrationservices;
        private readonly Iproductcuisinemasterservices _productcuisinemasterservices;
        private readonly ISP_Call _sP_Call;





        public AccountController(UserManager<ApplicationUser> usermanager,
                                    SignInManager<ApplicationUser> signinmanager,
                                    RoleManager<IdentityRole> roleManager
                                    , IWebHostEnvironment hostingEnvironment
                                    , IstoredetailsServices storedetailsServices
                                    , IRadiusMasterServices RadiusMasterServices
                                    , IDeliveryTimeMasterServices DeliveryTimeMasterServices
                                    , ICountryRegistrationservices CountryRegistrationservices
                                     , IStateRegistrationService StateRegistrationService
                                    , ICityRegistrationservices cityRegistrationservices
                                    , Iproductservices productservices
                                    , Iproductcuisinemasterservices productcuisinemasterservices
                                    , ISP_Call sP_Call
            )
        {
            this.usermanager = usermanager;
            this.signinmanager = signinmanager;
            this.roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
            _storedetailsServices = storedetailsServices;
            _RadiusMasterServices = RadiusMasterServices;
            _DeliveryTimeMasterServices = DeliveryTimeMasterServices;
            _productservices = productservices;
            _CountryRegistrationservices = CountryRegistrationservices;
            _StateRegistrationService = StateRegistrationService;
            _cityRegistrationservices = cityRegistrationservices;
            _productcuisinemasterservices = productcuisinemasterservices;
            _sP_Call = sP_Call;
        }
        [HttpGet]
        public IActionResult Register()
        {
            var RegisterViewModelobj = new RegisterViewModel();
            RegisterViewModelobj.roleList = roleManager.Roles.Where(u => u.Name != SD.Role_Admin).Select(x => x.Name).Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });

            //RegisterViewModelobj.countryList = _CountryRegistrationservices.GetAll().Select(i => new SelectListItem
            //{
            //    Text = i.countryname,
            //    Value = i.id.ToString()
            //});
            return View(RegisterViewModelobj);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {



            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    name = model.name,
                    mobileno = model.mobileno
                };
                var result = await usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //-------------------------------------

                    if (!await roleManager.RoleExistsAsync(SD.Role_Admin))
                    {
                        await roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                    }

                    if (!await roleManager.RoleExistsAsync(SD.Role_Employee))
                    {
                        await roleManager.CreateAsync(new IdentityRole(SD.Role_Employee));
                    }
                    if (!await roleManager.RoleExistsAsync(SD.Role_Store))
                    {
                        await roleManager.CreateAsync(new IdentityRole(SD.Role_Store));
                    }
                    if (!await roleManager.RoleExistsAsync(SD.Role_Manager))
                    {
                        await roleManager.CreateAsync(new IdentityRole(SD.Role_Manager));
                    }
                    //----------------------------------
                    //  usermanager.AddToRoleAsync(user, "Store").Wait();
                    if (model.Role == null)
                    {
                        await usermanager.AddToRoleAsync(user, SD.Role_Store);
                    }
                    else
                    {

                        await usermanager.AddToRoleAsync(user, model.Role);
                    }

                    if (signinmanager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Account");
                    }
                    await signinmanager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            model.roleList = roleManager.Roles.Where(u => u.Name != SD.Role_Admin).Select(x => x.Name).Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var result = await signinmanager.PasswordSignInAsync(model.Email, model.Password,
                       model.RememberMe, false);
                //   return RedirectToAction("Index", "Home");
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");


            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> CreateRole(CreateRoleViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var roleExist = await roleManager.RoleExistsAsync(model.RoleName);
                if (!roleExist)
                {
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = model.RoleName
                    };

                    IdentityResult result = await roleManager.CreateAsync(identityRole);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult ListUsers(int? PageNumber)
        {
            var storeDetails = _sP_Call.List<storedetailsList>("selectallstoreDetails", null);
            //var users = usermanager.Users;
            return View(storeDetails);


        }

        #region StoreList Paging
        public IActionResult StoreListDetails()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetStoreListDetails()
        {

            var storeDetails = _sP_Call.List<storedetailsList>("selectallstoreDetails", null);
            return Json(new { data = storeDetails });
        }

        [HttpGet]
        public IActionResult EmployeeList(string roletype)
        {
            TempData["roletype"] = roletype;
            TempData.Keep("roletype");
            return View();
        }
        [HttpGet]
        public IActionResult ManagerList(string roletype)
        {
            TempData["roletype"] = roletype;
            TempData.Keep("roletype");
            return View();
        }


        [HttpGet]
        public IActionResult GetUserDetails()
        {
            var obj = new DynamicParameters();
            if (TempData["roletype"] != null)
            {
                if (TempData["roletype"].ToString() == "Employee")
                {
                    obj.Add("@role", "Employee");
                }
                else if (TempData["roletype"].ToString() == "Manager")
                {
                    obj.Add("@role", "Manager");
                }
                else
                {
                    obj.Add("@role", "");
                }
            }


            var storeDetails = _sP_Call.List<GetUserDetailsViewModel>("getUserList", obj);
            return Json(new { data = storeDetails });
        }

        #endregion


        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> EditListUsers(string id)
        {


            var users = await usermanager.FindByIdAsync(id);

            ViewBag.Countries = _CountryRegistrationservices.GetAll().Select(x => new SelectListItem()
            {
                Text = x.countryname,
                Value = x.id.ToString()
            });

            int countryiddd = 0, stateid = 0, countryid = 0;

            if (users.managerCity != null)
            {
                string  cityiddd = users.managerCity;
                var paramter = new DynamicParameters();
                paramter.Add("@cityId", cityiddd);               
                var stateobj = _sP_Call.OneRecord<GetStatebyCityIdViewModel>("GetStatebyCityId", paramter);
                if (stateobj != null)
                {
                    stateid = stateobj.stateid;

                }
                else
                {
                    stateid = 0;
                }                
                countryid = _StateRegistrationService.GetById(stateid).countryid;
            }

            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + id + "cannot be found";
                return View("NotFound");
            }
            var model = new EditRegisterViewModel()
            {
                Id = users.Id,
                Email = users.Email,
                name = users.name,
                mobileno = users.mobileno,
                gender = users.gender,
                UserName = users.UserName,
                managerCity = users.managerCity,
                multipleManagerCity =users.managerCity

            };
            if (users.managerCity != null)
            {
                model.countryid = countryid;
                model.stateid = stateid;
                model.managerCity = users.managerCity;

                ViewBag.States = _StateRegistrationService.GetAll().Where(x => x.isdeleted == false && x.countryid == model.countryid).Select(x => new SelectListItem()
                {
                    Text = x.StateName,
                    Value = x.id.ToString()
                });
            //    ViewBag.Cities = _cityRegistrationservices.GetAll().Where(x => x.isdeleted == false && x.stateid == model.stateid).Select(x => new SelectListItem()
            //    {
            //        Text = x.cityName,
            //        Value = x.id.ToString()
            //    });
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> EditListUsers(EditRegisterViewModel model1)
        {
            var users = await usermanager.FindByIdAsync(model1.Id);
            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + model1.Id + "cannot be found";
                return View("NotFound");
            }
            else
            {
                users.name = model1.name;
                users.gender = model1.gender;
                users.mobileno = model1.mobileno;
                users.Email = model1.Email;
                users.UserName = model1.UserName;
                users.managerCity = model1.multipleManagerCity;
                if (model1.profilephoto != null && model1.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/storeowner";
                    var fileName = Path.GetFileNameWithoutExtension(model1.profilephoto.FileName);
                    var extesion = Path.GetExtension(model1.profilephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    if (users.profilephoto != null)
                    {
                        var imagePath = webRootPath + users.profilephoto.ToString().Replace("/", "\\");
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                    }


                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    FileStream fs = new FileStream(path, FileMode.Create);

                    await model1.profilephoto.CopyToAsync(fs);
                    fs.Close();
                    users.profilephoto = '/' + uploadDir + '/' + fileName;

                }
                var res = await usermanager.UpdateAsync(users);
                if (res.Succeeded)
                {
                    TempData["success"] = "Record Update successfully";
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("ListUsers");

                    // TempData["roletype"]

                    //if (TempData["roletype"]!=null)
                    //{
                    //    if (TempData["roletype"].ToString()== "Store")
                    //    {
                    //        return RedirectToAction(nameof(StoreListDetails));
                    //    }
                    //    else if (TempData["roletype"].ToString() == "Employee")
                    //    {
                    //        return RedirectToAction(nameof(EmployeeList));
                    //    }
                    //    else if (TempData["roletype"].ToString() == "Manager")
                    //    {
                    //        return RedirectToAction(nameof(ManagerList));
                    //    }
                    //}

                }
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model1);
        }

        public async Task<IActionResult> deleteListUsers(string id)
        {
            var users = await usermanager.FindByIdAsync(id);
            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + id + "cannot be found";
                return View("NotFound");
            }
            else
            {
                // users.isdeleted = true;
                //var result= await usermanager.UpdateAsync (users);

                var result = await usermanager.DeleteAsync(users);
                if (result.Succeeded)
                {
                    // return RedirectToAction("ListUsers");
                    return RedirectToAction(nameof(StoreListDetails));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }

        [HttpGet]
       // [Authorize(Roles = SD.Role_Admin)]
        public IActionResult forgetpassword()
        {
            var model = new storeForgetPasswordViewModel();
            return View(model);
        }
        [HttpPost]
       // [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> forgetpassword(storeForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await usermanager.FindByEmailAsync(model.Email);
                //if (user != null && await usermanager.IsEmailConfirmedAsync(user))
                //{
                //    var token = await usermanager.GeneratePasswordResetTokenAsync(user);
                //    var passwordresetLink = Url.Action("ResetPassword", "Account",
                //        new { email = model.Email, token = token }, Request.Scheme);
                //    bool send = SendMail(model.Email,passwordresetLink);
                //    return View("storeForgotPasswordConfimation");
                //}
                if (user != null)
                {
                    var token = await usermanager.GeneratePasswordResetTokenAsync(user);
                    var passwordresetLink = Url.Action("ResetPassword", "Account",
                        new { email = model.Email, token = token }, Request.Scheme);
                    bool send = SendConfirmationMail(model.Email, passwordresetLink, token);

                    return View("storeForgotPasswordConfimation");
                }
                return View("storeForgotPasswordConfimation");
            }
            return View();
        }
        private bool SendConfirmationMail(string email, string link, string token)
        {
            //----  msg--
            string oSB = string.Empty;
            oSB += "<br/>";
            oSB += "<div>Forgot Password </div>";
            oSB += "<br/>";
            oSB += "<div>Dear Member,  </div>";
            oSB += "<br/>";
            oSB += "<div>As per your request, we have sent you the password reset link. Click on the following link to reset your password: </div>";
            oSB += "<br/>";
            oSB += "<table><tr><td>'" + link + "'</td> </tr> </table>";

            oSB += "<hr/>";
            oSB += "<div>Thank you,</div>";
            oSB += "<div>Food Delivery- Support Team.</div>";
            //----------------
            // common ocommon = new common();
            //   string oSB = string.Empty;
            bool send = false;
            MailMessage mail = new MailMessage();

            if (email.ToString().Trim() == "".Trim())
            {
            }
            else
            {
                mail.To.Add(new MailAddress(email.ToString().Trim()));
            }





            mail.From = new MailAddress("support@picindia.in", "Food Delivery");
            //mail.From = new MailAddress("info@all-stationery.com", "Stationery Registration");

            mail.Subject = "Forgot Password";
            mail.Body = oSB.ToString();
            //string Filepath = Server.MapPath("~\\PDF\\") + "Invoice" + count + ".pdf";

            //string PdfFile = Request.PhysicalApplicationPath + "1.pdf";
            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment(Filepath);
            //mail.Attachments.Add(attachment);

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "103.250.184.62";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("accounts@all-stationery.com", "kiran@123");
            //smtp.Credentials = new System.Net.NetworkCredential("info@all-stationery.com", "8^75uttA");
            smtp.Credentials = new System.Net.NetworkCredential("support@picindia.in", "0crq*7I8");
            //info@all-stationery.com
            try
            {
                smtp.Send(mail);
                send = true;
            }
            catch (Exception ex)
            {
                send = false;
                // ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + ex.Message + "," + ex.StackTrace + "')", true);
                // ErrHandler.writeError(ex.Message, ex.StackTrace);
            }
            return send;
        }

        //private bool SendConfirmationMail(string email,string link,string token)
        //{

        //    string CustomerName = string.Empty;


        //    string oSB = string.Empty;
        //    bool send = false;
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(email);


        //    mail.From = new MailAddress("info@picindia.in", CustomerName);
        //    mail.Subject = "Customer Generate New Order - InvoiceNo - " + email ;
        //    mail.Body = link;
        //    mail.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "103.250.184.62";
        //    smtp.Port = 25;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new System.Net.NetworkCredential("info@picindia.in", "sumit@2020");
        //    try
        //    {
        //        smtp.Send(mail);
        //        send = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        send = false;
        //        //ErrHandler.writeError(ex.Message, ex.StackTrace);
        //    }
        //    return send;
        //}

        //private string OrderMailCreate(Int64 OrderId)
        //{
        //    common ocommon = new common();
        //    string OrderLink = "http://moryaapp.moryatools.com/orderinvoice.aspx?oid=" + ocommon.Encrypt(OrderId.ToString(), true);
        //    string oSB = string.Empty;
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        //cmd.CommandText = "order_invoice";
        //        cmd.CommandText = "Customer_order_invoice";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@oid", OrderId);
        //        cmd.Connection = con;
        //        con.Open();
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);
        //        oSB += "<div>Hello Admin,</div";
        //        if (ds.Tables != null)
        //        {
        //            if (ds.Tables[2].Rows.Count > 0)
        //            {
        //                oSB += "<br/>";
        //                oSB += "<table><tr><td><b><u>Customer Details - </u></b></td></tr><tr><td> Name - " + ds.Tables[2].Rows[0]["name"].ToString() + "</td></tr><tr><td>Phone: <span>" + ds.Tables[2].Rows[0]["phone"].ToString() + "</span></td></tr><tr><td>GST NO: <span>" + ds.Tables[2].Rows[0]["gstno"].ToString() + "</span></td></tr><tr><td>Address: <span>" + ds.Tables[2].Rows[0]["address"].ToString() + "</span></td></tr><tr><td>Email: <span>" + ds.Tables[2].Rows[0]["email"].ToString() + "</span></td></tr></table>";
        //                oSB += "<hr/>";
        //            }

        //            if (ds.Tables[0] != null)
        //            {
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    oSB += "<br/>";
        //                    oSB += "<table><tr><td><b><u>Order Details -</u></b></td></tr><tr><td> Invoice No - #" + ds.Tables[0].Rows[0]["oid"].ToString() + "</td></tr><tr><td>Order Date: <span>" + ds.Tables[0].Rows[0]["orderdate"].ToString() + "</span></td></tr><tr><td>Total Amount: <span>" + ds.Tables[0].Rows[0]["totalamount"].ToString() + "</span></td></tr></table>";
        //                    oSB += "<hr/>";
        //                }
        //            }

        //            if (ds.Tables[1].Rows.Count > 0)
        //            {
        //                oSB += "<br/>";
        //                oSB += "<table><tr><td><b><u>Order Products Details - </u></b></td></tr></table>";
        //                oSB += "<br/>";
        //                oSB += "<table style='border: 1px solid black'><thead><tr style='border: 1px solid black'><th style='border: 1px solid black'>Product Name</th><th style='border: 1px solid black'>SKU</th><th style='text-align: center;border: 1px solid black'>Product Price</th><th style='text-align: center;border: 1px solid black'>Quantites</th><th style='text-align: center;border: 1px solid black'>GST</th><th style='text-align: center;border: 1px solid black'>Product Basic Price</th><th style='text-align: center;border: 1px solid black'>Product Total Price</th></tr></thead><tbody>";
        //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //                {
        //                    oSB += "<tr style='border: 1px solid black'>";
        //                    oSB += "<td style='border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["productname"].ToString() + "</span></td>";
        //                    oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["sku"].ToString() + "</span></td>";
        //                    oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["productprice"].ToString() + "</span></td>";
        //                    oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["quantites"].ToString() + "</span></td>";
        //                    oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["gst"].ToString() + "</span></td>";
        //                    oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["ProductBasicPrice"].ToString() + "</span></td>";
        //                    oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["producttotalprice"].ToString() + "</span></td>";
        //                    oSB += "</tr>";
        //                }
        //                oSB += "</tbody></table>";
        //                oSB += "<br/>";
        //                oSB += "<b><u>Website Page Link -</u>  <a href=" + OrderLink + ">" + OrderLink + "</a></b>";
        //                oSB += "<br/>";
        //                oSB += "<br/>";
        //                oSB += "<hr/>";
        //                oSB += "<div>Thank you,</div>";
        //                oSB += "<div>Morya App - Support Team.</div>";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return oSB;
        //}

        [HttpGet]
        //[Authorize(Roles = SD.Role_Admin)]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid Password Reset Token");
            }

            return View();
        }
        [HttpPost]
      //  [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> ResetPassword(storeResetPasswordViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var user = await usermanager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await usermanager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }



            return View(model);
        }

        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> storeDetails(string id)
        {
            var users = await usermanager.FindByIdAsync(id);
            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + id + "cannot be found";
                return View("NotFound");
            }
            var model = new StoreShowDetailsViewModel()
            {

                storeid = users.Id,
                storeownerName = users.name,
                mobileno = users.mobileno,
                ownergender = users.gender,
                profilephoto = users.profilephoto,
                Email = users.Email
            };
            //byte[] decodedHashedPassword = Convert.FromBase64String(users.PasswordHash);
            //    string pass = base64Decode(users.PasswordHash);
            if (model.storeid != null)
            {
                var storedetails = _storedetailsServices.GetAll().Where(x => x.storeid == model.storeid).FirstOrDefault();

                if (storedetails != null)
                {
                    model.contactpersonname = storedetails.contactpersonname;
                    model.emailaddress = storedetails.emailaddress;
                    model.contactno = storedetails.contactno;
                    model.gender = storedetails.gender;
                    model.fooddelivery = storedetails.fooddelivery;
                    model.storename = storedetails.storename;
                    model.radiusid = _RadiusMasterServices.GetById(Convert.ToInt32(storedetails.radiusid)).name;
                    model.deliverytimeid = _DeliveryTimeMasterServices.GetById(Convert.ToInt32(storedetails.deliverytimeid)).name;
                    model.orderMinAmount = storedetails.orderMinAmount;
                    model.packagingCharges = storedetails.packagingCharges;
                    model.storeBannerPhoto = storedetails.storeBannerPhoto;
                    model.address = storedetails.address;
                    model.description = storedetails.description;
                    model.storetime = storedetails.storetime;
                    model.licPhoto = storedetails.licPhoto;
                    model.latitude = storedetails.latitude;
                    model.longitude = storedetails.longitude;
                    if (storedetails.radiusid != null)
                    {
                        int cityidd = Convert.ToInt32(storedetails.radiusid);
                        int stateid = _cityRegistrationservices.GetById(cityidd).stateid;
                        int countryid = _StateRegistrationService.GetById(stateid).countryid;

                        model.country = _CountryRegistrationservices.GetById(countryid).countryname;
                        model.state = _StateRegistrationService.GetById(countryid).StateName;
                        model.cityid = _cityRegistrationservices.GetById(cityidd).cityName;

                    }


                }
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> ProductList(string id)
        {
            var listt = _productservices.GetAll().Where(x => x.storeid == id).Select(x => new productIndexViewModel
            {
                id = x.id
                  ,
                storeid = x.storeid
                  ,
                productcuisineid = x.productcuisineid
                  ,
                productcuisinemaster = _productcuisinemasterservices.GetById(x.productcuisineid)
                  ,
                name = x.name
                  ,
                img = x.img
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

       
        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Lockunlock(string id)
        {


            var users =   _storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault() ;
           
            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + id + "cannot be found";
                return View("NotFound");
            }
            else
            {
                if (users.status == "unavailable")
                {
                    users.status = "available";
                }
                else if (users.status == "available")
                {
                    users.status = "unavailable";
                }
                await _storedetailsServices.UpdateAsync(users);
                ViewBag.ErrorMessgae = "Status Update Successfully";

            }
            return RedirectToAction("StoreListDetails");
        }
    }
}

