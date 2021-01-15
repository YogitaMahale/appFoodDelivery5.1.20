using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.pagination;
using appFoodDelivery.Services;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

namespace appFoodDelivery.API
{
    [Route("stores")]
    public class StoresController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinmanager;
        private readonly ISP_Call _ISP_Call;
        private readonly Iproductservices _productservices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IversionsServices _versionsServices;
        public StoresController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanager, ISP_Call ISP_Call, Iproductservices productservices, IstoredetailsServices storedetailsServices, IversionsServices versionsServices)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
            _ISP_Call = ISP_Call;
            _productservices = productservices;
            _storedetailsServices = storedetailsServices;
            _versionsServices = versionsServices;
        }
        [HttpPost]
        [Route("storeInsert")]
        public async Task<IActionResult> storeInsert(string name, string email, string mobileno, string password, string gender)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    name = name,
                    mobileno = mobileno,
                    gender = gender
                };
                var result = await _usermanager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    _usermanager.AddToRoleAsync(user, "Store").Wait();

                    return Ok(user);
                }
                else
                {
                    return BadRequest("duplicate Email Id");
                }


            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("storeslogin")]
        public async Task<IActionResult> storeslogin(string email, string password)
        {
            try
            {
                var result = await _signinmanager.PasswordSignInAsync(email, password, true, false);
                //   return RedirectToAction("Index", "Home");
                if (result.Succeeded)
                {
                    var users = _usermanager.Users.Where(x => x.UserName == email).FirstOrDefault();
                    return Ok(users);

                }
                return NotFound();
                //CustomerRegistration c = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.password == password && x.isdeleted == false).FirstOrDefault();
                ////  var categories = await _context.CustomerRegistration.ToListAsync(); 
                //if (c == null)
                //{
                //    return NotFound();
                //}

                //return Ok(c);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("forgetpassword")]
        public async Task<IActionResult> forgetpassword(string emailid)
        {
            try
            {
                var user = await _usermanager.FindByEmailAsync(emailid);
                if (user != null)
                {
                    var token = await _usermanager.GeneratePasswordResetTokenAsync(user);
                    var passwordresetLink = Url.Action("ResetPassword", "Account",
                        new { email = emailid, token = token }, Request.Scheme);
                    bool send = SendConfirmationMail(emailid, passwordresetLink, token);
                    string myJson = "{'message': 'Password sent Your Register Email Id'}";
                    return Ok(myJson);
                }
                else
                {
                    return NotFound();
                }




            }
            catch (Exception obj)
            {
                return BadRequest();
            }

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

            mail.Subject = "Registration Done Successfully";
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


        [HttpGet]
        [Route("storeNewOrder")]
        public async Task<IActionResult> storeNewOrder(string storedid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@storeid", storedid);
            paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("storeAcceptedOrder")]
        public async Task<IActionResult> storeAcceptedOrder(string storedid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@storeid", storedid);
            paramter.Add("@status", "approved");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("storeProcessingOrder")]
        public async Task<IActionResult> storeProcessingOrder(string storedid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@storeid", storedid);
            paramter.Add("@status", "processorders");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }

        [HttpGet]
        [Route("storeShippedOrders")]
        public async Task<IActionResult> storeShippedOrders(string storedid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@storeid", storedid);
            paramter.Add("@status", "ongoingorders");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("storeCompleteOrders")]
        public async Task<IActionResult> storeCompleteOrders(string storedid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@storeid", storedid);
            paramter.Add("@status", "completedorders");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("storeCancelOrders")]
        public async Task<IActionResult> storeCancelOrders(string storedid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@storeid", storedid);
            paramter.Add("@status", "cancelledorders");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }


        [HttpGet]
        [Route("storeCountOrders")]
        public async Task<IActionResult> storeCountOrders(string storedid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@storedId", storedid);

            var orderheaderList1 = _ISP_Call.OneRecord<storeCountModel>("SP_storeCount", paramter);
            // orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpPut]
        [Route("changepassword")]
        public async Task<IActionResult> changepassword(string storedid, string currentpasswod, string newpassword)
        {
            var user = _usermanager.Users.Where(x => x.Id == storedid).FirstOrDefault();// await _usermanager.GetUserAsync(User); 
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _usermanager.ChangePasswordAsync(user, currentpasswod, newpassword);
                if (!result.Succeeded)
                {
                    string myJson1 = "{\"Message\": " + "\"Password Not Change\"" + "}";
                    return BadRequest(myJson1);


                }
                string myJson = "{'message': " + "Password Updated Successfully" + "}";
                return Ok(myJson);
            }

        }
        [HttpPut]
        [Route("storedEditProfile")]
        public async Task<IActionResult> storedEditProfile(string storedid, string name, string gender, string mobileno, string email)
        {
            var user = _usermanager.Users.Where(x => x.Id == storedid).FirstOrDefault();// await _usermanager.GetUserAsync(User); 
            if (user == null)
            {
                return NotFound("Not Found");
            }
            else
            {

                user.name = name;
                user.gender = gender;
                user.mobileno = mobileno;
                user.Email = email;

                var res = await _usermanager.UpdateAsync(user);
                if (res.Succeeded)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest();

                }


            }

        }

        [HttpPut]
        [Route("updateStoreDeviceId")]
        public async Task<IActionResult> updateStoreDeviceId(string deviceId, string storeid,bool flg)
        {
            if (flg)
            {


                try
                {
                    string myJson = "";
                    var users = await _usermanager.FindByIdAsync(storeid);
                    if (users == null)
                    {
                        myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                        return NotFound(myJson);



                    }
                    else
                    {
                        users.deviceid = deviceId;

                        var res = await _usermanager.UpdateAsync(users);
                        if (res.Succeeded)
                        {
                            myJson = "{\"message\": " + "\"Device Id Updated Successfully\"" + "}";

                            return Ok(myJson);

                        }
                        else
                        {
                            myJson = "{\"Message\": " + "\"Bad Request\"" + "}";

                            return BadRequest(myJson);

                        }
                    }
                    myJson = "{\"Message\": " + "\"Bad Request\"" + "}";


                    return BadRequest(myJson);


                }
                catch (Exception obj)
                {
                    return Ok(obj.Message);
                }
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut]
        [Route("updateProductAvailableStatus")]
        public async Task<IActionResult> updateProductAvailableStatus(int id, string status)
        {
            try
            {


                var product = _productservices.GetById(id);
                if (product == null)
                {
                    string myJson = "{'message': " + "Not Found" + "}";
                    return NotFound(myJson);
                    // return NotFound();
                }
                else
                {
                    product.status = status;
                    await _productservices.UpdateAsync(product);

                    return Ok(product);
                }
                //return BadRequest();
            }
            catch (Exception obj)
            {
                return Ok(obj.Message);
            }
        }
        [HttpPut]
        [Route("updateStoreStatus")]
        public async Task<IActionResult> updateStoreStatus(string storeId, string status)
        {
            try
            {

                try
                {
                    var store = _storedetailsServices.GetAll().Where(x => x.storeid == storeId).FirstOrDefault();
                    if (store == null)
                    {
                        var details = new storedetails
                        {
                            storeid = storeId,
                            status = status

                        };

                        int id = await _storedetailsServices.CreateAsync(details);
                        var store1 = _storedetailsServices.GetById(id);
                        return Ok(store1);
                    }
                    else
                    {
                        //var store1 = _storedetailsServices.GetAll().Where(x => x.storeid == storeId).FirstOrDefault();
                        if (store == null)
                        { }
                        else
                        {
                            store.status = status;

                            await _storedetailsServices.UpdateAsync(store);
                            return Ok(store);
                        }



                    }
                }
                catch (Exception obj)
                {
                    //var details = new storedetails
                    //{
                    //    storeid = storeId,
                    //    storename = "",
                    //    contactpersonname = "",
                    //    // id = model.id,
                    //    radiusid = 0,
                    //    deliverytimeid = 0,
                    //    orderMinAmount =0,
                    //    packagingCharges =0,
                    //    isdeleted = false,
                    //    address ="",
                    //    description = "",
                    //    //storetime = model.storetime,
                    //    storetime = "",
                    //    latitude = "",
                    //    longitude = "",
                    //    cityid = 0,
                    //    promocode = "",
                    //    discount =0,

                    //    accountno = "",
                    //    banklocation = "",
                    //    bankname = "",
                    //    ifsccode = "",
                    //    status = status,
                    //    adminCommissionPer =0,
                    //    taxstatus = "",
                    //    taxstatusPer = 0



                    //};

                    //await _storedetailsServices.CreateAsync(details);
                    //var store = _storedetailsServices.GetAll().Where(x => x.storeid == storeId).FirstOrDefault();
                    //return Ok(store);
                }
                finally
                {

                }


                //  IEnumerable<storedetails> store = _storedetailsServices.GetAll().Where(x => x.storeid == storeId);

                return BadRequest();
                //if (store == null)
                //{

                //    var details = new storedetails
                //    {
                //        storeid = storesId,
                //        status=status 
                //        //storename = "",
                //        //contactpersonname = "",

                //        //radiusid = model.radiusid,
                //        //deliverytimeid = model.deliverytimeid,
                //        //orderMinAmount = model.orderMinAmount,
                //        //packagingCharges = model.packagingCharges,
                //        //isdeleted = false,
                //        //address = model.address,
                //        //description = model.description,
                //        ////storetime = model.storetime,
                //        //storetime = model.FromTime + " - " + model.ToTime,
                //        //latitude = model.latitude,
                //        //longitude = model.longitude,
                //        //cityid = model.cityid,
                //        //promocode = model.promocode,
                //        //discount = model.discount,

                //        //accountno = model.longitude,
                //        //banklocation = model.banklocation,
                //        //bankname = model.bankname,
                //        //ifsccode = model.ifsccode,
                //        //status = model.status,
                //        //adminCommissionPer = model.adminCommissionPer,
                //        //taxstatus = model.taxstatus,
                //        //taxstatusPer = model.taxstatusPer

                //    };

                //    await _storedetailsServices.CreateAsync(details);
                //    return Ok(store);
                //}
                //else
                //{


                //    store.status = status;

                //    await _storedetailsServices.UpdateAsync(store);
                //    return Ok(store);
                //}



            }
            catch (Exception obj)
            {
                return Ok(obj.Message);
            }
        }
        [HttpGet]
        [Route("getversion")]
        public async Task<IActionResult> getversion()
        {


            var customer = _versionsServices.GetById(1);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
            //return BadRequest();
        }

        [HttpGet]
        [Route("selectallTodayOrders")]
        public async Task<IActionResult> selectallTodayOrders(bool flg=false)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@flg", flg);
            //paramter.Add("@status", "approved");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("selectallOrderstoday", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
    }

}

//getversion