using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Models.dtos;
using appFoodDelivery.Notification;
using appFoodDelivery.Services;
using appFoodDelivery.Utility;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.API
{
    [Route("deliveryboy")]
    public class deliveryboyController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public readonly IdriverRegistrationServices _driverRegistrationServices;
        public readonly IordersServices _ordersServices;
        public readonly IorderhistoryServices _orderhistoryServices;
        public readonly ISP_Call _ISP_Call;
        public readonly IDeliveryboytoCustomerfeedbackSerivces _DeliveryboytoCustomerfeedbackSerivces;
        public readonly ICustomerRegistrationservices _CustomerRegistrationservices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IdistanceServices _distanceServices;
        private readonly IdenyOrdersServices _denyOrdersServices;
        public deliveryboyController(IdriverRegistrationServices driverRegistrationServices, IWebHostEnvironment hostingEnvironment, IordersServices ordersServices, ISP_Call ISP_Call, IorderhistoryServices orderhistoryServices, IDeliveryboytoCustomerfeedbackSerivces DeliveryboytoCustomerfeedbackSerivces, ICustomerRegistrationservices CustomerRegistrationservices, UserManager<ApplicationUser> usermanager, IstoredetailsServices storedetailsServices, IdistanceServices distanceServices, IdenyOrdersServices denyOrdersServices)
        {
            _driverRegistrationServices = driverRegistrationServices;
            _hostingEnvironment = hostingEnvironment;
            _ordersServices = ordersServices;
            _ISP_Call = ISP_Call;
            _orderhistoryServices = orderhistoryServices;
            _DeliveryboytoCustomerfeedbackSerivces = DeliveryboytoCustomerfeedbackSerivces;
            _CustomerRegistrationservices = CustomerRegistrationservices;
            _usermanager = usermanager;
            _storedetailsServices = storedetailsServices;
            _distanceServices = distanceServices;
            _denyOrdersServices = denyOrdersServices;
        }
        [HttpGet]
        [Route("deliveryboyLogin")]
        public async Task<IActionResult> deliveryboyLogin(string mobileno, string password)
        {
            try
            {
                driverRegistration c = _driverRegistrationServices.GetAll().Where(x => x.mobileno == mobileno && x.password == password && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {
                    string myJson = "{'message': " + "Record Not Found" + "}";
                    return Ok(myJson);
                    // return NotFound();
                }

                return Ok(c);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("deliveryboyInsert")]
        public async Task<IActionResult> deliveryboyInsert(string name, string gender, string email, string mobileno, string password)
        {
            try
            {
                driverRegistration c = _driverRegistrationServices.GetAll().Where(x => x.mobileno == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {

                    driverRegistration obj = new driverRegistration();

                    obj.name = name;
                    obj.mobileno = mobileno;
                    obj.emailid = email;
                    obj.password = password;
                    obj.isdeleted = false;
                    obj.isactive = false;
                    obj.gender = gender;
                    obj.createddate = DateTime.UtcNow;

                    int id = await _driverRegistrationServices.CreateAsync(obj);
                    driverRegistration obj1 = new driverRegistration();
                    obj1 = _driverRegistrationServices.GetById(id);
                    return Ok(obj1);
                }
                else
                {
                    string myJson = "{'message': " + "duplicate Mobile No" + "}";
                    return Ok(myJson);
                    // return BadRequest("duplicate Mobile No");
                }

            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("getOTPNo")]
        public async Task<IActionResult> getOTPNo(string mobileno)
        {
            try
            {
                //driverRegistration obj = _driverRegistrationServices.GetAll().Where(x => x.mobileno == mobileno && x.isdeleted == false).FirstOrDefault();
                ////  var categories = await _context.CustomerRegistration.ToListAsync(); 
                //if (obj == null)
                //{
                String no = null;
                Random random = new Random();
                for (int i = 0; i < 1; i++)
                {
                    int n = random.Next(0, 999);
                    no += n.ToString("D4") + "";
                }
                string Msg = "OTP :" + no + ".  Please Use this OTP.This is usable once and expire in 10 minutes";
                SendSMS objsendSMS = new SendSMS();
                bool res = objsendSMS.smsSent(mobileno, Msg);
                //#region "sms"
                //try
                //{

                    

                //    string OPTINS = "STRLIT";

                //    string type = "3";
                //    //  string Password = "9359848251";
                //    string Password = "959595";
                //    string strUrl = "http://bulksms.co/sendmessage.php?user=Aveebroiler&password=" + Password + "&message=" + Msg + "&sender=" + OPTINS + "&mobile=" + mobileno + "&type=" + 3;
                //    //  string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ezacus&password=" + "ezacus@2020" + "&message=" + Msg.ToString() + "&sender=" + OPTINS + "&mobile=" + mobileno + "&type=" + 3;

                //    ServicePointManager.Expect100Continue = true;
                //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //    Stream s = (Stream)response.GetResponseStream();
                //    StreamReader readStream = new StreamReader(s);
                //    string dataString = readStream.ReadToEnd();
                //    response.Close();
                //    s.Close();
                //    readStream.Close();
                //    //    Response.Write("Sent");
                //}

                //catch
                //{ }
                //#endregion
                string myJson = "{'otpno': " + no + "}";
                return Ok(myJson);
                //}
                //else
                //{
                //    return BadRequest("Duplicate Mobile No");
                //}


            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }


        [HttpPut]
        [Route("updateVehicleDocument")]
        public async Task<IActionResult> updateVehicleDocument(string biketype, string manufacturename, int id, string modelname, string modelyear, string vehicleplateno, string drivinglicphoto, string vehicleinsurancephoto)
        {
            try
            {


                var deliveryboy = _driverRegistrationServices.GetById(id);
                if (deliveryboy == null)
                {
                    string myJson = "{'message': " + "Not Found" + "}";
                    return NotFound(myJson);
                    // return NotFound();
                }
                else
                {
                    deliveryboy.biketype = biketype;
                    deliveryboy.manufacturename = manufacturename;
                    deliveryboy.modelname = biketype;
                    deliveryboy.modelyear = manufacturename;
                    deliveryboy.vehicleplateno = vehicleplateno;
                    if (drivinglicphoto != null || drivinglicphoto != string.Empty)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\driver\drivingLicence";
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(drivinglicphoto));
                        deliveryboy.drivinglicphoto = "/uploads/driver/drivingLicence/" + fileName;

                    }
                    if (vehicleinsurancephoto != null || vehicleinsurancephoto != string.Empty)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\driver\vehicleinsurancephoto";
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(vehicleinsurancephoto));
                        deliveryboy.vehicleinsurancephoto = "/uploads/driver/vehicleinsurancephoto/" + fileName;

                    }
                    await _driverRegistrationServices.UpdateAsync(deliveryboy);

                    return Ok(deliveryboy);
                }
                //return BadRequest();
            }
            catch (Exception obj)
            {
                return Ok(obj.Message);
            }
        }

        [HttpPut]
        [Route("DeliveryboyEditProfile")]
        public async Task<IActionResult> DeliveryboyEditProfile(int id, string name, string gender, string email)
        {
            driverRegistration user = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (user == null)
            {
                string myJson = "{'message': " + "Not Found" + "}";
                return Ok(myJson);
                // return NotFound("Not Found");
            }
            else
            {
                user.name = name;
                user.gender = gender;
                //  user.mobileno = mobileno;
                user.emailid = email;
                await _driverRegistrationServices.UpdateAsync(user);
                return Ok(user);
            }

        }
        [HttpPut]
        [Route("changepassword")]
        public async Task<IActionResult> changepassword(int id, string newpassword)
        {
            driverRegistration user = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (user == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
            }
            else
            {
                user.password = newpassword;
                await _driverRegistrationServices.UpdateAsync(user);
                string myJson = "{'message': " + "Password Updated Successfully" + "}";
                return Ok(myJson);
            }

        }

        [HttpPut]
        [Route("acceptOrder")]
        public async Task<IActionResult> acceptOrder(int orderid, int deliveryboyid)
        {
            orders obj = _ordersServices.GetById(orderid);// await _usermanager.GetUserAsync(User); 

            if (obj == null)
            {
                string myJson = "{\"message\": " + "\"Record Not Found\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                if (obj.deliveryboyid.ToString().Trim() == "".ToString().Trim())
                {


                    obj.deliveryboyid = deliveryboyid;
                    obj.acceptedby = "Deliveryboy";
                    //  obj.orderstatus = "acceptbydelivery";
                    await _ordersServices.UpdateAsync(obj);

                    var driverdetails = _driverRegistrationServices.GetById(deliveryboyid);
                    orderhistory objorderhistory = new orderhistory();
                    objorderhistory.oid = orderid;
                    objorderhistory.placedate = DateTime.UtcNow;
                    objorderhistory.orderstatus = driverdetails.name + " accept order. OrderID  :" + orderid;
                    await _orderhistoryServices.CreateAsync(objorderhistory);

                    #region "Notification customer and store"
                    int customerid = obj.customerid;
                    string customerDeviceId = _CustomerRegistrationservices.GetById(customerid).deviceid;

                    var storeDeviceId = _usermanager.Users.Where(x => x.Id == obj.storeid).FirstOrDefault().deviceid;
                    if (customerDeviceId.Trim() == "" || customerDeviceId == null)
                    {

                    }
                    else
                    {


                        try
                        {
                            string sResponseFromServer = string.Empty, finalResult = string.Empty;
                            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                            tRequest.Method = "post";
                            //serverKey - Key from Firebase cloud messaging server   customer
                            //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                            //store
                            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAA4lmKnwA:APA91bHnS9ND3VSqid8vKdUTQukqJrBJytbmQKZJADNrEbxs9ZDNxoI_Cq0rhuvqkw9954fvUSuC9McpOfTAc7K3OgTvovghBkazWnIgQ0qn0TPjz1nTCZAgbrbNCYWLRei-5vzlBlYj"));
                            //Sender Id - From firebase project setting  
                            tRequest.Headers.Add(string.Format("Sender: id={0}", "972164865792"));
                            tRequest.ContentType = "application/json";
                            var payload = new
                            {
                                to = customerDeviceId,
                                priority = "high",
                                content_available = true,
                                notification = new
                                {
                                    //body = "Your Order No. - " + orderid + " Accept by " + driverdetails.name + " delivery person",
                                    //title = "Accept Order by Deliveryboy",
                                    body = driverdetails.name + " will be Delivering Your order",
                                    title = "Delivering Your order",
                                    badge = 1
                                },
                                data = new
                                {
                                    key1 = "AAAA4lmKnwA:APA91bHnS9ND3VSqid8vKdUTQukqJrBJytbmQKZJADNrEbxs9ZDNxoI_Cq0rhuvqkw9954fvUSuC9McpOfTAc7K3OgTvovghBkazWnIgQ0qn0TPjz1nTCZAgbrbNCYWLRei-5vzlBlYj",
                                    key2 = "972164865792"
                                }

                            };

                            //string postbody = JsonConvert.SerializeObject(payload).ToString();

                            var serializer = new JavaScriptSerializer();
                            var postbody = serializer.Serialize(payload);
                            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                            tRequest.ContentLength = byteArray.Length;
                            using (Stream dataStream = tRequest.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                                using (WebResponse tResponse = tRequest.GetResponse())
                                {
                                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                    {
                                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                            {
                                                sResponseFromServer = tReader.ReadToEnd();
                                                //result.Response = sResponseFromServer;
                                            }
                                    }
                                }
                            }

                        }

                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    try
                    {


                        if (storeDeviceId.Trim() != "" || storeDeviceId != null)
                        {




                            try
                            {
                                string sResponseFromServer = string.Empty, finalResult = string.Empty;
                                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest.Method = "post";
                                //serverKey - Key from Firebase cloud messaging server   customer
                                //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                                //store
                                //cahnge 9.9.20
                                //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAr0cwgUE:APA91bEs5PB48LpheJuGQOJi8jENylDdtBgGA5tcHFY2Kbz4-FwNLocAN8z7X7c4ADuP6vA7MSE3M6hx5OHp12iFt0yb7zfHO16c7mlgnppsEOFY8J4WRfpOUI-RkbXBLBwMqYwwDyYX"));
                                ////Sender Id - From firebase project setting  
                                //tRequest.Headers.Add(string.Format("Sender: id={0}", "752813637953"));

                                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAA-grvO4U:APA91bG1TeBl5uVNLOHGyjSYSJ_-PZiOFKeSUkjhx4do27iECafs1dVdAyhE6-QvMDON6xrz-YOa10tMgFdmy_w1amPXVHsXLWrAggDh8oU0c1F8CvdBW6aGc1wrqP8OlQ86ZzxzkTuS"));
                                //Sender Id - From firebase project setting  
                                tRequest.Headers.Add(string.Format("Sender: id={0}", "1073925274501"));

                                tRequest.ContentType = "application/json";
                                var payload = new
                                {
                                    to = storeDeviceId,
                                    priority = "high",
                                    content_available = true,
                                    notification = new
                                    {
                                        //body = "Order No. - " + orderid + " Accept by " + driverdetails.name + " delivery person",
                                        //title = "Accept Order by Deliveryboy",

                                        body = driverdetails.name + " Has Accepted Order",
                                        title = "Accept Order by Deliveryboy",
                                        badge = 1


                                    },
                                    data = new
                                    {
                                        key1 = "AAAA-grvO4U:APA91bG1TeBl5uVNLOHGyjSYSJ_-PZiOFKeSUkjhx4do27iECafs1dVdAyhE6-QvMDON6xrz-YOa10tMgFdmy_w1amPXVHsXLWrAggDh8oU0c1F8CvdBW6aGc1wrqP8OlQ86ZzxzkTuS",
                                        key2 = "1073925274501"
                                    }

                                };

                                //string postbody = JsonConvert.SerializeObject(payload).ToString();

                                var serializer = new JavaScriptSerializer();
                                var postbody = serializer.Serialize(payload);
                                Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                                tRequest.ContentLength = byteArray.Length;
                                using (Stream dataStream = tRequest.GetRequestStream())
                                {
                                    dataStream.Write(byteArray, 0, byteArray.Length);
                                    using (WebResponse tResponse = tRequest.GetResponse())
                                    {
                                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                        {
                                            if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                                {
                                                    sResponseFromServer = tReader.ReadToEnd();
                                                    //result.Response = sResponseFromServer;
                                                }
                                        }
                                    }
                                }

                            }

                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    catch (Exception obj1)
                    {
                    }
                    #endregion


                    string myJson = "{\"message\": " + "\"Order Accept Successfully\"" + "}";
                    return Ok(obj);
                }
                else
                {
                    string myJson = "{\"message\": " + "\"Order Accept by other delivery boy\"" + "}";
                    return BadRequest(myJson);
                }
            }

        }
        [HttpGet]
        [Route("selectallPendingOrder")]
        public async Task<IActionResult> selectallPendingOrder()
        {
            //var paramter = new DynamicParameters();
            //paramter.Add("@storeid", storedid);
            //paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllPending", null);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Not Found" + "}";
                return NotFound(myJson);
                // return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("deliveryboyorderCount")]
        public async Task<IActionResult> deliveryboyorderCount(int deliveryboyid)
        {
            DynamicParameters paramter = new DynamicParameters();
            paramter.Add("@deliveryboyid", deliveryboyid);
            //  paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<storeCountModel>("SP_deliveryboyorderCount", paramter);
            //  orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }

        [HttpGet]
        [Route("deliveryboyMonthlyorderCount")]
        public async Task<IActionResult> deliveryboyMonthlyorderCount(int deliveryboyid, int month)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@deliveryboyid", deliveryboyid);
            paramter.Add("@month", month);
            //  paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<storeCountModel>("SP_deliveryboyMonthlyorderCount", paramter);
            //  orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("getProductdetailsbyOrderid")]
        public async Task<IActionResult> getProductdetailsbyOrderid(int orderid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@oid", orderid);
            //  paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<orderselectallDetailsViewModel>("orderinvoice_getProductList", paramter);
            //  orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }

        [HttpPut]
        [Route("deliveryboyReachtoHotel")]
        public async Task<IActionResult> deliveryboyReachtoHotel(int orderid, int deliveryboyid)
        {
            // orders obj = _ordersServices.GetById(orderid);// await _usermanager.GetUserAsync(User); 
            //if (obj == null)
            //{
            //    string myJson = "{'message': " + "Record Not Found" + "}";
            //    return NotFound(myJson);
            //}
            //else
            //{
            if (orderid.ToString() == "" || deliveryboyid.ToString() == "")
            {
                string myJson = "{\"message\": " + "\"Please sent inputparameter values\"" + "}";
                return NotFound(myJson);

            }
            else
            {
                var driverdetails = _driverRegistrationServices.GetById(deliveryboyid);

                orderhistory objorderhistory = new orderhistory();
                objorderhistory.oid = orderid;
                objorderhistory.placedate = DateTime.UtcNow;
                objorderhistory.orderstatus = driverdetails.name + " reach to Hotel for accepting  order id :" + orderid;
                await _orderhistoryServices.CreateAsync(objorderhistory);
                string myJson = "{\"message\": " + "\"Status updated Successfully\"" + "}";

                return Ok(myJson);

            }



            //}

        }

        public void customerNotification(string deviceid, string message, string img, string title)
        {

            if (deviceid.Trim() == "")
            {

            }
            else
            {


                try
                {
                    string sResponseFromServer = string.Empty, finalResult = string.Empty;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    //serverKey - Key from Firebase cloud messaging server   customer
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                    //store
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                    //Sender Id - From firebase project setting  
                    tRequest.Headers.Add(string.Format("Sender: id={0}", "844325225983"));
                    tRequest.ContentType = "application/json";
                    var payload = new
                    {
                        to = deviceid,
                        priority = "high",
                        content_available = true,
                        notification = new
                        {
                            body = message,
                            title = title,
                            badge = 1
                        },
                        data = new
                        {
                            key1 = "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4",
                            key2 = "844325225983"
                        }

                    };

                    //string postbody = JsonConvert.SerializeObject(payload).ToString();

                    var serializer = new JavaScriptSerializer();
                    var postbody = serializer.Serialize(payload);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                    tRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        sResponseFromServer = tReader.ReadToEnd();
                                        //result.Response = sResponseFromServer;
                                    }
                            }
                        }
                    }

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpPut]
        [Route("changeorderStatus")]
        public async Task<IActionResult> changeorderStatus(int orderid, string status, string reason)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@id", orderid);
            paramter.Add("@orderstatus", status);
            _ISP_Call.Execute("orderStatus_Update", paramter);

            fcmNotification objfcmNotification = new fcmNotification();
            //---------------

            orderhistory objorderhistory = new orderhistory();
            objorderhistory.oid = orderid;
            objorderhistory.placedate = DateTime.UtcNow;
            objorderhistory.reason = reason;
            objorderhistory.orderstatus = "Order No :" + orderid + "," + status + " status updated Successfully";
            await _orderhistoryServices.CreateAsync(objorderhistory);
            //---

            var orderss = _ordersServices.GetById(orderid);
            int customerid = orderss.customerid;
            string customerDeviceId = _CustomerRegistrationservices.GetById(customerid).deviceid;

            string storeid = orderss.storeid;
            var store = _storedetailsServices.GetAll().Where(x => x.storeid == storeid).FirstOrDefault();
            string storeLatitude = store.latitude;
            string storelongitude = store.longitude;
            string storeName = store.storename;

            string deliveryboyname = "";

            if (orderss.deliveryboyid == null || orderss.deliveryboyid.ToString().Trim() == "")
            {

            }
            else
            {
                int deliveryboyidd = Convert.ToInt32(orderss.deliveryboyid.ToString());
                deliveryboyname = _driverRegistrationServices.GetById(deliveryboyidd).name;
            }


            #region "Notification"
            if (status.ToString().ToLower().Trim() == "processorders".ToString().ToLower().Trim())
            {
                //customer


                //string message = "Your Order No. - " + orderid + " in  process";
                //string title = "Assign Deliveryboy";
                string message = storeName + " is Processing Your order";
                string title = "Processing Your order";
                // customerNotification(customerDeviceId, message,"", title);
                objfcmNotification.customerNotification(customerDeviceId, message, "", title);


            }
            else if (status.ToString().ToLower().Trim() == "ongoingorders".ToString().ToLower().Trim())
            {
                //string message = "Your Order No. - " + orderid + " in Shipped";
                //string title = "Shipped Orders";
                string message = deliveryboyname + " is On The Way";
                string title = deliveryboyname + " is On The Way";


                // customerNotification(customerDeviceId, message, "", title);
                objfcmNotification.customerNotification(customerDeviceId, message, "", title);



            }
            else if (status.ToString().ToLower().Trim() == "completedorders".ToString().ToLower().Trim())
            {
                string message = "Your Order Has Been Deliverd";
                string title = "Order Deliverd";
                //customerNotification(customerDeviceId, message, "", title);
                objfcmNotification.customerNotification(customerDeviceId, message, "", title);


            }
            else if (status.ToString().ToLower().Trim() == "cancelledorders".ToString().ToLower().Trim())
            {
                string message = "Your Order has been cancelled";
                string title = "Cancel Orders";
                // customerNotification(customerDeviceId, message, "", title);
                objfcmNotification.customerNotification(customerDeviceId, message, "", title);

            }
            else if (status.ToString().ToLower().Trim() == "approved".ToString().ToLower().Trim())
            {
                string message = storeName + " Has Accepted Your Order";
                string title = "Accept Order";
                // customerNotification(customerDeviceId, message, "", title);
                objfcmNotification.customerNotification(customerDeviceId, message, "", title);
                #region "Deliveryboy"

                try
                {
                    var distancedt = _distanceServices.GetById(1);
                    var distance = distancedt.range;

                    var paramter1 = new DynamicParameters();
                    paramter1.Add("@Latitude", storeLatitude);
                    paramter1.Add("@Longitude", storelongitude);
                    paramter1.Add("@distance", distance);
                    var dt = _ISP_Call.List<getNeareDeliveryboybyLocation>("getNeareDeliveryboybyLocationNew", paramter1);

                    foreach (var item in dt)
                    {
                        string deviceid = item.deviceid;
                        //string message1 = "New Order No. - " + id + " Approved by Admin";
                        //string title1 = "Order Approved";
                        string message1 = "New Order Received";
                        string title1 = "New Order Received";

                        objfcmNotification.deliveryboyNotification(deviceid, message1, "", title1);


                    }



                }

                catch (Exception ex)
                {

                    string ss = ex.Message;
                    throw ex;
                }


                // return Ok(sResponseFromServer);

                #endregion
            }

            #endregion





            string myJson = "{\"Message\": " + "\"Order Status Updated Successfully\"" + "}";
            return Ok(myJson);


        }

        [HttpPut]
        [Route("deliveryboyupdatedeviceid")]
        public async Task<IActionResult> deliveryboyupdatedeviceid(int id, string deviceid)
        {
            string myJson = "";
            driverRegistration user = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (user == null)
            {
                myJson = "{'message': " + "Not Found" + "}";
                return NotFound(myJson);
                // return NotFound("Not Found");
            }
            else
            {
                user.deviceid = deviceid;

                await _driverRegistrationServices.UpdateAsync(user);
                return Ok(user);
            }

        }

        [HttpPost]
        [Route("insertCustomerFeedback")]
        public async Task<IActionResult> insertCustomerFeedback(int deliveryboyid, int customerid, string comment, string rating)
        {

            DeliveryboytoCustomerfeedback obj = new DeliveryboytoCustomerfeedback();
            obj.id = 0;
            obj.deliveryboyid = deliveryboyid;
            obj.customerid = customerid;

            obj.comment = comment;
            obj.rating = rating;
            obj.isdeleted = false;
            obj.isactive = false;
            int id = await _DeliveryboytoCustomerfeedbackSerivces.CreateAsync(obj);
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


        [HttpPut]
        [Route("insertbankdetails")]
        public async Task<IActionResult> insertbankdetails(int id, string accountno, string banklocation, string bankname, string ifsccode)
        {
            driverRegistration obj = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (obj == null)
            {
                string myJson = "{'message': " + "Not Found" + "}";
                return Ok(myJson);
                // return NotFound("Not Found");
            }
            else
            {
                obj.accountno = accountno;
                obj.banklocation = banklocation;
                obj.bankname = bankname;
                obj.ifsccode = ifsccode;

                //  user.mobileno = mobileno;

                await _driverRegistrationServices.UpdateAsync(obj);
                return Ok(obj);
            }

        }
        [HttpPut]
        [Route("updateLocation")]
        public async Task<IActionResult> updateLocation(int id, string latitude, string longitude)
        {
            driverRegistration obj = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (obj == null)
            {
                string myJson = "{'message': " + "Not Found" + "}";
                return Ok(myJson);
                // return NotFound("Not Found");
            }
            else
            {
                obj.latitude = latitude;
                obj.longitude = longitude;

                //  user.mobileno = mobileno;

                await _driverRegistrationServices.UpdateAsync(obj);
                return Ok(obj);
            }

        }

        //var paramter = new DynamicParameters();
        //paramter.Add("@Latitude", Latitude);
        //    paramter.Add("@Longitude", Longitude);
        //    paramter.Add("@distance", 5);
        //    //storedetailsListViewmodel
        //    var storeList = _ISP_Call.List<storedetailsListViewmodel>("getNearestStoredbyLocationNew", paramter);
        [HttpGet]
        [Route("getdeliveryboynearestorder")]
        public async Task<IActionResult> getdeliveryboynearestorder(int deliveryboyid)
        {
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllPending", null);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));


            var paramter = new DynamicParameters();
            paramter.Add("@deliveryboyid", deliveryboyid);
            var orderlist = _ISP_Call.List<orderselectallViewModel>("getdeliveryboynearestorder", paramter);
            if (orderlist == null)
            {
                string myJson = "{\"message\": " + "\"Record Not Found\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                return Ok(orderlist);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("getdeliveryboyTopOrder")]
        public async Task<IActionResult> getdeliveryboyTopOrder(int deliveryboyid)
        {


            var paramter = new DynamicParameters();
            paramter.Add("@deliveryboyid", deliveryboyid);
            var orderlist = _ISP_Call.List<orderselectallViewModel>("getdeliveryboynearestToporder", paramter);
            if (orderlist == null)
            {
                string myJson = "{\"message\": " + "\"Record Not Found\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                return Ok(orderlist);
            }
            //return BadRequest();
        }
        [HttpPut]
        [Route("updateDeliveryboyOrderLocationbyOrderID")]
        public async Task<IActionResult> updateDeliveryboyOrderLocationbyOrderID(int orderid, string deliveryboylatitude, string deliveryboylongitude)
        {
            string myJson = "";
            orders obj = _ordersServices.GetById(orderid);// await _usermanager.GetUserAsync(User); 
            if (obj == null)
            {
                myJson = "{'message': " + "Not Found" + "}";
                return NotFound(myJson);
                // return NotFound("Not Found");
            }
            else
            {
                obj.deliveryboylatitude = deliveryboylatitude;
                obj.deliveryboylongitude = deliveryboylongitude;

                await _ordersServices.UpdateAsync(obj);
                return Ok(obj);
            }

        }

        [HttpPut]
        [Route("UpdateDeliveryboyCheckStatus")]
        public async Task<IActionResult> UpdateDeliveryboyCheckStatus(int orderid, string status, string paymentstatus)
        {
            orders obj = _ordersServices.GetById(orderid);// await _usermanager.GetUserAsync(User); 
            if (obj == null)
            {
                string myJson = "{\"message\": " + "\"Record Not Found\"" + "}";
                return NotFound(myJson);
            }
            else
            {

                //string status1 = "";
                //if(paymentstatus.ToUpper().Trim()== "Cash on Delivery".ToString().ToUpper().Trim())
                //{
                //    status1 = "Paid";
                //}
                //else if (paymentstatus.ToUpper().Trim() == "Paid".ToString().ToUpper().Trim())
                //{
                //    status1 = "Paid";

                //}
                obj.deliveryboyCheckStaus = status;
                obj.paymentstatus = paymentstatus;
                await _ordersServices.UpdateAsync(obj);


                string myJson = "{\"message\": " + "\"Record Updated Successfully\"" + "}";
                return Ok(obj);
            }

        }
        [HttpPut]
        [Route("UpdateStoreCheckStatus")]
        public async Task<IActionResult> UpdateStoreCheckStatus(int orderid, string status)
        {
            orders obj = _ordersServices.GetById(orderid);// await _usermanager.GetUserAsync(User); 
            if (obj == null)
            {
                string myJson = "{\"message\": " + "\"Record Not Found\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                obj.storeCheckStaus = status;
                await _ordersServices.UpdateAsync(obj);


                string myJson = "{\"message\": " + "\"Record Updated Successfully\"" + "}";
                return Ok(obj);
            }

        }

        [HttpGet]
        [Route("deliveryboyDeliveryCharges")]
        public async Task<IActionResult> deliveryboyDeliveryCharges(int orderid)
        {
            try
            {

                //var obj = _ordersServices.GetById(orderid);

                var parameter = new DynamicParameters();
                parameter.Add("@orderid", orderid);

                var obj = _ISP_Call.List<customerdeliverycharges>("deliveryboyDeliveryCharges", parameter);
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

        [HttpPost]
        [Route("denyOrders")]
        public async Task<IActionResult> denyOrders(int orderid, int deliveryboyid)
        {
            try
            {
                var c = _denyOrdersServices.GetAll().Where(x => x.deliveryboyid == deliveryboyid && x.orderid == orderid && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {
                    denyOrders obj = new denyOrders();

                    obj.deliveryboyid = deliveryboyid;
                    obj.orderid = orderid;

                    obj.isdeleted = false;


                    int id = await _denyOrdersServices.CreateAsync(obj);
                    var obj1 = _denyOrdersServices.GetById(id);
                    return Ok(obj1);



                }
                else
                {
                    string myJson = "{'message': " + "This Order already Deny" + "}";
                    return Ok(myJson);


                }

            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("GetAssignOrderbyAdmin")]
        public async Task<IActionResult> GetAssignOrderbyAdmin(Int64 deliveryboyId)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@deliveryboyid", deliveryboyId);
            //paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("GetAssignOrderbyAdmin", paramter);
            

            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Not Found" + "}";
                return NotFound(myJson);
                // return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }


        [HttpGet]
        [Route("deliveryboyList")]
        public async Task<IActionResult> deliveryboyList()
        {
            //var paramter = new DynamicParameters();
            //paramter.Add("@deliveryboyid", deliveryboyId);
            //paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<deliveryboyListViewModel>("deliveryboyList", null);


            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
                // return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
    }
}
