using appFoodDelivery.Entity;
using appFoodDelivery.Models;
//using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
//using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
//using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
//using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
//using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using appFoodDelivery.Notification;
//using appFoodDelivery.Models.Dtos;
using appFoodDelivery.Services;
using Dapper;
//using System.Web.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace appFoodDelivery.API
{
    [Route("customer")]
    public class customerController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICustomerRegistrationservices CustomerRegistrationservices;
        private readonly IsliderServices _sliderServices;
        private readonly ISP_Call _ISP_Call;
        private readonly IordersServices _ordersServices;
        private readonly IcustomerfeedbackServices _customerfeedbackServices;
        public customerController(ICustomerRegistrationservices _CustomerRegistrationservices, IWebHostEnvironment hostingEnvironment, IsliderServices sliderServices, ISP_Call ISP_Call, IordersServices ordersServices, IcustomerfeedbackServices customerfeedbackServices)
        {
            CustomerRegistrationservices = _CustomerRegistrationservices;
            _sliderServices = sliderServices;
            _hostingEnvironment = hostingEnvironment;
            _ISP_Call = ISP_Call;
            _ordersServices = ordersServices;
            _customerfeedbackServices = customerfeedbackServices;
        }
        [HttpGet]
        [Route("getOTPNo")]
        public async Task<IActionResult> getOTPNo(string mobileno)
        {
            try
            {

                String no = null;
                Random random = new Random();
                for (int i = 0; i < 1; i++)
                {
                    int n = random.Next(0, 999);
                    no += n.ToString("D4") + "";
                }
                #region "sms"
                try
                {

                    string Msg = "OTP :" + no + ".  Please Use this OTP.This is usable once and expire in 10 minutes";

                    string OPTINS = "STRLIT";
                    //  string Password = "9359848251";
                    string Password = "959595";

                    string type = "3";
                    // string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ezacus&password=" + "ezacus@2020" + "&message=" + Msg.ToString() + "&sender=" + OPTINS + "&mobile=" + mobileno + "&type=" + 3;
                    //string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ezacus&password=" + "ezacus@2020" + "&message=" + Msg.ToString() + "&sender=" + OPTINS + "&mobile=" + mobileno + "&type=" + 3;


                    string strUrl = "http://bulksms.co/sendmessage.php?user=Aveebroiler&password=" + Password + "&message=" + Msg + "&sender=" + OPTINS + "&mobile=" + mobileno + "&type=" + 3;
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();
                    //    Response.Write("Sent");
                }

                catch
                { }
                #endregion

                CustomerRegistrationOTPViewModel objCustomerRegistrationOTPViewModel = new CustomerRegistrationOTPViewModel();
                CustomerRegistration obj = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    //string myJson = "{'otpno': "+ no + "}";
                    //return Ok(myJson);
                    //    objCustomerRegistrationOTPViewModel.id = obj.id;
                    //objCustomerRegistrationOTPViewModel.name = "";
                    //objCustomerRegistrationOTPViewModel.profilephoto = ""; 
                    //objCustomerRegistrationOTPViewModel.address = ""; 
                    //objCustomerRegistrationOTPViewModel.mobileno1 = "";
                    //objCustomerRegistrationOTPViewModel.mobileno2 = "";
                    //objCustomerRegistrationOTPViewModel.emailid1 = "";
                    //objCustomerRegistrationOTPViewModel.latitude = "";
                    //objCustomerRegistrationOTPViewModel.longitude = "";
                    //objCustomerRegistrationOTPViewModel.password = "";
                    //objCustomerRegistrationOTPViewModel.mobileno2 = "";
                    //objCustomerRegistrationOTPViewModel.gender = "";
                    //   objCustomerRegistrationOTPViewModel.DOB = obj.DOB;
                    //  objCustomerRegistrationOTPViewModel.createddate = obj.createddate;


                    // objCustomerRegistrationOTPViewModel.isdeleted = obj.isdeleted;
                    //  objCustomerRegistrationOTPViewModel.isactive = obj.isactive;
                    objCustomerRegistrationOTPViewModel.otpno = no;
                    return Ok(objCustomerRegistrationOTPViewModel);
                }
                else
                {

                    objCustomerRegistrationOTPViewModel.id = obj.id;
                    objCustomerRegistrationOTPViewModel.name = obj.name;
                    objCustomerRegistrationOTPViewModel.profilephoto = obj.profilephoto;
                    objCustomerRegistrationOTPViewModel.address = obj.address;
                    objCustomerRegistrationOTPViewModel.mobileno1 = obj.mobileno1;
                    objCustomerRegistrationOTPViewModel.mobileno2 = obj.mobileno2;
                    objCustomerRegistrationOTPViewModel.emailid1 = obj.emailid1;
                    objCustomerRegistrationOTPViewModel.latitude = obj.latitude;
                    objCustomerRegistrationOTPViewModel.longitude = obj.longitude;
                    objCustomerRegistrationOTPViewModel.password = obj.password;
                    objCustomerRegistrationOTPViewModel.mobileno2 = obj.mobileno2;
                    objCustomerRegistrationOTPViewModel.gender = obj.gender;
                    objCustomerRegistrationOTPViewModel.DOB = obj.DOB;
                    objCustomerRegistrationOTPViewModel.createddate = obj.createddate;


                    objCustomerRegistrationOTPViewModel.isdeleted = obj.isdeleted;
                    objCustomerRegistrationOTPViewModel.isactive = obj.isactive;
                    objCustomerRegistrationOTPViewModel.otpno = no;




                    return Ok(objCustomerRegistrationOTPViewModel);
                }


            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("CustomerLogin")]
        public async Task<IActionResult> CustomerLogin(string mobileno, string password)
        {
            try
            {
                CustomerRegistration c = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.password == password && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {
                    return NotFound();
                }

                return Ok(c);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("CustomerInsert")]
        public async Task<IActionResult> CustomerInsert(string name, string email, string mobileno, string password)
        {
            try
            {
                CustomerRegistration c = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {

                    //                 id, name, profilephoto, address, mobileno1, mobileno2, emailid1, latitude, longitude, password, gender, DOB,
                    //createddate, isdeleted, isactive, deviceid
                    CustomerRegistration obj = new CustomerRegistration();

                    //obj.name = name;
                    //obj.profilephoto = "";
                    //obj.address = "";
                    //obj.mobileno1 = mobileno;
                    //obj.mobileno2 = "";
                    //obj.emailid1 = email;
                    //obj.latitude = "";
                    //obj.longitude = "";
                    //obj.password = password;
                    //obj.gender = "";
                    //obj.DOB = DateTime.UtcNow;
                    //obj.createddate = DateTime.UtcNow;
                    //obj.isdeleted = false;
                    //obj.isactive = false;
                    //obj.deviceid = "";
                    obj.name = name;
                    obj.mobileno1 = mobileno;
                    obj.emailid1 = email;
                    obj.password = password;
                    obj.isdeleted = false;
                    obj.isactive = false;
                    obj.gender = "select";
                    obj.createddate = DateTime.UtcNow;

                    int id = await CustomerRegistrationservices.CreateAsync(obj);
                    CustomerRegistration obj1 = new CustomerRegistration();
                    obj1 = CustomerRegistrationservices.GetById(id);
                    return Ok(obj1);
                }
                else
                {
                    return BadRequest("duplicate Mobile No");
                }

            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpPut]
        [Route("updateCustomerDeviceId")]
        public async Task<IActionResult> updateCustomerDeviceId(string deviceId, int id)
        {
            try
            {


                var customer = CustomerRegistrationservices.GetById(id);
                if (customer == null)
                {
                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);

                }
                else
                {
                    customer.deviceid = deviceId;
                    await CustomerRegistrationservices.UpdateAsync(customer);

                    return Ok(customer);
                }
                //return BadRequest();
            }
            catch (Exception obj)
            {
                return Ok(obj.Message);
            }
        }

        [HttpPut]
        [Route("updateDeviceId")]
        public async Task<IActionResult> updateDeviceId(string deviceId, int id)
        {
            try
            {
                var customer = CustomerRegistrationservices.GetById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    customer.deviceid = deviceId;
                    await CustomerRegistrationservices.UpdateAsync(customer);

                    if (id < 0)
                    {
                        return BadRequest();
                    }
                    else
                    {

                        return Ok(customer);
                    }
                }
            }
            catch (Exception obj)
            {
                return Ok(obj.Message);
            }
            finally
            {

            }

            //return BadRequest();
        }

        [HttpPut]
        [Route("updateCustomerProfile")]
        public async Task<IActionResult> updateCustomerProfile(string name, string email, int id)
        {
            try
            {


                var customer = CustomerRegistrationservices.GetById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    customer.name = name;
                    customer.emailid1 = email;
                    await CustomerRegistrationservices.UpdateAsync(customer);

                    return Ok(customer);
                }
                //return BadRequest();
            }
            catch (Exception obj)
            {
                return Ok(obj.Message);
            }
        }

        [HttpPut]
        [Route("updateLocation")]
        public async Task<IActionResult> updateLocation(string address, string latitude, string longitude, int id)
        {
            try
            {


                var customer = CustomerRegistrationservices.GetById(id);
                if (customer == null)
                {
                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {
                    customer.address = address;
                    customer.longitude = longitude;
                    customer.latitude = latitude;
                    await CustomerRegistrationservices.UpdateAsync(customer);

                    return Ok(customer);
                }
                //return BadRequest();
            }
            catch (Exception obj)
            {
                return Ok(obj.Message);
            }
        }
        [HttpGet]
        [Route("sliderselectall")]
        public async Task<IActionResult> sliderselectall()
        {
            try
            {
                var sliderlist = _sliderServices.GetAll().Where(x => x.isdeleted == false).ToList();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (sliderlist == null)
                {
                    return NotFound();
                }

                return Ok(sliderlist);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("forgetpassword")]
        public async Task<IActionResult> forgetpassword(string mobileno)
        {
            try
            {

                CustomerRegistration obj = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    return NotFound();
                }
                else
                {
                    bool flg = SendConfirmationMail(obj.emailid1, obj.password, mobileno);
                    return Ok("Password sent Your Register Email Id");
                }


            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        private bool SendConfirmationMail(string email, string password, string mobileno)
        {
            //----  msg--
            string oSB = string.Empty;
            //oSB += "<br/>";
            //oSB += "<div>Forgot Password </div>";
            oSB += "<br/>";
            oSB += "<div>Dear Member,  </div>";
            oSB += "<br/>";
            //  oSB += "<div>As per your request, we have sent you the password reset link. Click on the following link to reset your password: </div>";
            // oSB += "<br/>";
            oSB += "<table><tr><td>Mobile No : </td><td>'" + mobileno + "'</td> </tr> <tr><td>Password : </td><td>'" + password + "'</td> </tr> </table>";

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




            // mail.To.Add(new MailAddress("mahaleyogita233@gmail.com"));
            //  mail.From = new MailAddress("accounts@all-stationery.com", "Stationery Order");
            mail.From = new MailAddress("support@picindia.in", "Food Delivery");

            mail.Subject = "Password Sent Successfully";
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
        [HttpPost]
        [Route("insertfeedbacktodeliveryboy")]
        public async Task<IActionResult> insertfeedbacktodeliveryboy(int deliveryboyid, int customerid, string comment, string rating)
        {
            //var paramter = new DynamicParameters();
            //paramter.Add("@customerid", customerid);
            //paramter.Add("@deliveryboyid", deliveryboyid);
            //paramter.Add("@comment", comment);
            //paramter.Add("@rating", rating );

            // _ISP_Call.Execute("insertfeedback", paramter);
            customerfeedback obj = new customerfeedback();
            obj.id = 0;
            obj.fromcustomerid = customerid;
            obj.toDeliveryboyid = deliveryboyid;
            obj.toStoredid = null;
            obj.comment = comment;
            obj.rating = rating;
            obj.isdeleted = false;
            obj.isactive = false;
            int id = await _customerfeedbackServices.CreateAsync(obj);
            if (id == null)
            {
                string myJson = "{\"Message\": " + "\"NotFound\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                string myJson = "{\"Message\": " + "\"Feedback Insert Successfully\"" + "}";
                return Ok(myJson);

            }
            //return BadRequest();
        }


        [HttpPost]
        [Route("insertfeedbacktoStore")]
        public async Task<IActionResult> insertfeedbacktoStore(string storeid, int customerid, string comment, string rating)
        {
            //var paramter = new DynamicParameters();
            //paramter.Add("@customerid", customerid);
            //paramter.Add("@deliveryboyid", deliveryboyid);
            //paramter.Add("@comment", comment);
            //paramter.Add("@rating", rating );

            // _ISP_Call.Execute("insertfeedback", paramter);
            customerfeedback obj = new customerfeedback();
            obj.id = 0;
            obj.fromcustomerid = customerid;
            obj.toDeliveryboyid = null;
            obj.toStoredid = storeid;
            obj.comment = comment;
            obj.rating = rating;
            obj.isdeleted = false;
            obj.isactive = false;
            int id = await _customerfeedbackServices.CreateAsync(obj);
            if (id == null)
            {
                string myJson = "{\"Message\": " + "\"NotFound\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                string myJson = "{\"Message\": " + "\"Feedback Insert Successfully\"" + "}";
                return Ok(myJson);

            }
            //return BadRequest();
        }

        [HttpGet]
        [Route("storeSendTestNotification")]
        public async Task<IActionResult> storeSendTestNotification(string DeviceId, string Message)
        {
            fcmNotification objfcmNotification = new fcmNotification();
            objfcmNotification.storeNotification(DeviceId, Message, "", "test");
            string myJson = "{\"Message\": " + "\"Notification Sent Successfully\"" + "}";
            return Ok(myJson);

        }
        [HttpGet]
        [Route("customerSendTestNotification")]
        public async Task<IActionResult> customerSendTestNotification(string DeviceId, string Message)
        {
            fcmNotification objfcmNotification = new fcmNotification();
            objfcmNotification.customerNotification(DeviceId, Message, "", "test");
            string myJson = "{\"Message\": " + "\"Notification Sent Successfully\"" + "}";
            return Ok(myJson);

        }
        [HttpGet]
        [Route("deliveryboySendTestNotification1")]
        public async Task<IActionResult> deliveryboySendTestNotification1(string DeviceId, string Message)
        {
            fcmNotification objfcmNotification = new fcmNotification();
            objfcmNotification.deliveryboyNotification(DeviceId, Message, "", "test");
            string myJson = "{\"Message\": " + "\"Notification Sent Successfully\"" + "}";
            return Ok(myJson);

        }
        [HttpGet]
        [Route("deliveryboySendTestNotificationnew")]
        public async Task<IActionResult> deliveryboySendTestNotificationnew(string DeviceId, string Message)
        {
            fcmNotification objfcmNotification = new fcmNotification();
            objfcmNotification.testdeliveryboyNotification(DeviceId, Message, "", "test");
            string myJson = "{\"Message\": " + "\"Notification Sent Successfully\"" + "}";
            return Ok(myJson);

        }

        [HttpGet]
        [Route("getOrderStatus")]
        public async Task<IActionResult> getOrderStatus(int orderid)
        {
            try
            {

                //var obj = _ordersServices.GetById(orderid);

                var parameter = new DynamicParameters();
                parameter.Add("@oid", orderid);
                var obj = _ISP_Call.List<getOrderStatusInfo>("getOrderStatusInfo", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }



        [HttpGet]
        [Route("customerdeliveryCharges")]
        public async Task<IActionResult> customerdeliveryCharges(string storedid, decimal latitude, decimal lognitude)
        {
            try
            {

                //var obj = _ordersServices.GetById(orderid);

                var parameter = new DynamicParameters();
                parameter.Add("@storedid", storedid);
                parameter.Add("@customerLatitude", latitude);
                parameter.Add("@customerLongitude", lognitude);
                var obj = _ISP_Call.List<customerdeliverycharges>("customerOrderDeliveryCharges", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }


        [HttpGet]
        [Route("orderhistorybyCustomerId")]
        public async Task<IActionResult> orderhistorybyCustomerId(int customerid)
        {
            try
            {

                //var obj = _ordersServices.GetById(orderid);

                var parameter = new DynamicParameters();
                parameter.Add("@customerid", customerid);

                var obj = _ISP_Call.List<orderselectallViewModel>("orderhistorybyCustomerId", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }
    }
}