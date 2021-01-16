using appFoodDelivery.Entity;
using appFoodDelivery.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using appFoodDelivery.Models.dtos;
using appFoodDelivery.Notification;
using appFoodDelivery.Persistence;
//using appFoodDelivery.Models.Dtos;
using appFoodDelivery.Services;
using Dapper;
//using System.Web.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace appFoodDelivery.API
{
    [Route("hotel")]
    public class hotelController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly Iproductservices _productservices;
        private readonly Iproductcuisinemasterservices _productcuisinemasterservices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IordersServices _ordersServices;
        private readonly IorderproductServices _orderproductServices;
        private readonly IorderhistoryServices _orderhistoryServices;
        private readonly ApplicationDbContext _db;
        private readonly ISP_Call _ISP_Call;
        private readonly UserManager<ApplicationUser> _usermanager;
        public hotelController(ICustomerRegistrationservices _CustomerRegistrationservices, IstoredetailsServices storedetailsServices, IWebHostEnvironment hostingEnvironment, Iproductcuisinemasterservices productcuisinemasterservices, Iproductservices productservices, IordersServices ordersServices, IorderproductServices orderproductServices, IorderhistoryServices orderhistoryServices, ApplicationDbContext db, ISP_Call ISP_Call, UserManager<ApplicationUser> usermanager)
        {
            _storedetailsServices = storedetailsServices;
            _hostingEnvironment = hostingEnvironment;
            _productcuisinemasterservices = productcuisinemasterservices;
            _productservices = productservices;
            _ordersServices = ordersServices;
            _orderproductServices = orderproductServices;
            _orderhistoryServices = orderhistoryServices;
            _db = db;
            _ISP_Call = ISP_Call;
            _usermanager = usermanager;
        }
        [HttpGet]
        [Route("hotelselectall")]
        public async Task<IActionResult> hotelselectall()
        {


            var customer = _storedetailsServices.GetAll();
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
        [Route("hotelselectallbyLocation")]
        public async Task<IActionResult> hotelselectallbyLocation(decimal Latitude, decimal Longitude)
        {

            var paramter = new DynamicParameters();
            paramter.Add("@Latitude", Latitude);
            paramter.Add("@Longitude", Longitude);
            paramter.Add("@distance", 5);
            //storedetailsListViewmodel
            var storeList = _ISP_Call.List<storedetailsListViewmodel>("getNearestStoredbyLocationNew", paramter);
            if (storeList != null)
            {
                return Ok(storeList);

            }
            else
            {
                return NotFound();
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("getCuisineSelectall")]
        public async Task<IActionResult> getCuisineSelectall()
        {
            var customer = _productcuisinemasterservices.GetAll().Where(x => x.isdeleted == false);
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
        [Route("getProductbyHotelIdandCuisineId")]
        public async Task<IActionResult> getProductbyHotelIdandCuisineId(string hotelid, int Cuisineid)
        {
            //var customer = _productservices.GetAll().Where(x => x.storeid == hotelid && x.productcuisineid == Cuisineid && x.isdeleted == false &&x.status== "available");
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(customer);
            //}
            var paramter = new DynamicParameters();
            paramter.Add("@hotelid", hotelid);
            paramter.Add("@Cuisineid", Cuisineid);

            var orderlist = _ISP_Call.List<productModel>("getProductbyHotelIdandCuisineId", paramter);
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
        [Route("getProductbyHotelIdandCuisineIdwithoutfilter")]
        public async Task<IActionResult> getProductbyHotelIdandCuisineIdwithoutfilter(string hotelid, int Cuisineid)
        {
            //var customer = _productservices.GetAll().Where(x => x.storeid == hotelid && x.productcuisineid == Cuisineid && x.isdeleted == false);
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(customer);
            //}
            var paramter = new DynamicParameters();
            paramter.Add("@hotelid", hotelid);
            paramter.Add("@Cuisineid", Cuisineid);

            var orderlist = _ISP_Call.List<productModel>("getProductbyHotelIdandCuisineIdwithoutfilter", paramter);
            if (orderlist == null)
            {
                string myJson = "{\"message\": " + "\"Record Not Found\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                return Ok(orderlist);
            }


        }

        [HttpGet]
        [Route("getHotelCuisineId")]
        public async Task<IActionResult> getHotelCuisineId(int Cuisineid)
        {
            //var CanadaCustomers = from c in db.Customers.Where(cust => cust.region == "Canada")
            //                      select new { c.custId, c.name };

            // SqlParameter category = new SqlParameter("@CategoryName", "Test");

            //List<storedetails> obj = await _db.Database.ExecuteSqlCommandAsync("NewCategory @CategoryName", category);
            //var parameter = 1;
            //var query = db.Database.SqlQuery<TestProcedure>("TestProcedure @parameter1",
            //               new SqlParameter("@parameter1", parameter)).ToList();
            //return Json(query, JsonRequestBehavior.AllowGet);

            //  var res = from a in _db.product where a.productcuisineid==2 select a;
            var storeidd = _productservices.GetAll().Where(x => x.productcuisineid == Cuisineid).Select(x => x.storeid).Distinct().ToList();
            var hotels = _storedetailsServices.GetAll().Where(hotels => storeidd.Contains(hotels.storeid)).ToList();

            //var customer = _productservices.GetAll().Where(x => x.productcuisineid == Cuisineid && x.productcuisineid == Cuisineid && x.isdeleted == false).Distinct();
            if (hotels == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(hotels);
            }

            //return BadRequest();
        }

        [HttpPost]
        [Route("OrderInsertandOrderProduct")]
        public async Task<IActionResult> OrderInsertandOrderProduct(int customerid, decimal totalamount, string OrderProducts_JSONString, string promocode, string storedid, string discount, string orderstatus, string paymenttype, string paymentstatus, string deliveryaddress, string transactionid, string instruction, string customerdeliverylatitude, string customerdeliverylongitude)
        {


            var paramter = new DynamicParameters();
            paramter.Add("@customerid", customerid);
            var orderlist = _ISP_Call.List<orderselectallViewModel>("checkCustomerOrderComplete", paramter);

            bool flg = true;

            foreach (var item in orderlist)
            {
                if (item.orderstatus == "completedorders" || item.orderstatus == "cancelledorders")
                {

                }
                else
                {
                    flg = false;
                }
            }
            if (flg == false)
            {
                string myJson = "{'message': 'First Complete your Previous Orders'}";
                return Ok(myJson);
            }
            else
            {



                //var customer = CustomerRegistrationservices.GetById(id);
                if (customerid == 0)
                {
                    return NotFound();
                }
                else
                {
                    orders objorders = new orders();
                    objorders.customerid = customerid;
                    objorders.amount = totalamount;
                    //objorders.placedate = DateTime.UtcNow;
                    objorders.placedate = DateTime.Now;
                    objorders.paymentstatus = paymentstatus;
                    objorders.orderstatus = orderstatus;

                    objorders.discount = Convert.ToDecimal(discount);
                    objorders.storeid = storedid;
                    objorders.deliveryaddress = deliveryaddress;
                    objorders.paymenttype = paymenttype;
                    objorders.promocode = promocode;
                    objorders.transactionid = transactionid;
                    objorders.instructions = instruction;
                    // objorders.propmocode = promocode;

                    objorders.customerdeliverylatitude = customerdeliverylatitude;
                    objorders.customerdeliverylongitude = customerdeliverylongitude;
                    //                , deliveryboyid, paymentstatus, orderstatus, isdeleted, discount, storeid, 
                    //deliveryaddress, paymenttype, promocode

                    objorders.storeid = storedid;
                    //if (promocode == ""|| storedid=="")
                    //{
                    //    objorders.discount = 0;
                    //}
                    //else
                    //{
                    //    objorders.discount = _storedetailsServices.GetAll().Where(x => x.storeid == storedid&&x.promocode==promocode).FirstOrDefault().discount;
                    //}
                    int OrderProductAdd = 0;
                    int OrderId = 0;
                    var dtOrderProducts = JsonConvert.DeserializeObject<DataTable>(OrderProducts_JSONString);
                    if (dtOrderProducts != null)
                    {
                        if (dtOrderProducts.Rows.Count > 0)
                        {
                            OrderId = await _ordersServices.CreateAsync(objorders);
                            if (OrderId > 0)
                            {
                                for (int i = 0; i < dtOrderProducts.Rows.Count; i++)
                                {
                                    orderproducts objorderproduct = new orderproducts();
                                    objorderproduct.oid = OrderId;
                                    objorderproduct.pid = Convert.ToInt32(dtOrderProducts.Rows[i]["productid"]);
                                    objorderproduct.qty = Convert.ToInt64(dtOrderProducts.Rows[i]["quantites"]);
                                    objorderproduct.price = Convert.ToInt64(dtOrderProducts.Rows[i]["productprice"]);
                                    objorderproduct.isdeleted = false;
                                    await _orderproductServices.CreateAsync(objorderproduct);



                                    //id, oid, placedate, orderstatus
                                    //   id, oid, pid, qty, price, isdeleted
                                    //[{"productid":"1","productprice":"500","quantites":10},{"productid":"2","productprice":"500","quantites":10}]

                                }
                            }


                            orderhistory objorderhistory = new orderhistory();
                            objorderhistory.oid = OrderId;
                            objorderhistory.placedate = DateTime.UtcNow;
                            objorderhistory.orderstatus = "place Order";
                            await _orderhistoryServices.CreateAsync(objorderhistory);

                            var users = await _usermanager.FindByIdAsync(storedid);
                            string storeDeviceId = users.deviceid;
                            if (storeDeviceId == null || storeDeviceId.ToString().Trim() == "")
                            {

                            }
                            else
                            {


                                string sResponseFromServer = string.Empty, finalResult = string.Empty;
                                try
                                {

                                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                    tRequest.Method = "post";
                                    //serverKey - Key from Firebase cloud messaging server   customer
                                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                                    //store change 9.9.20
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
                                            //body = "New Order No. - " + OrderId + " insert",
                                            body = "New Order Received",
                                            title = "New Order",
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
                                    string s = ex.Message;
                                    // throw ex;
                                }
                                // return Ok(sResponseFromServer);


                            }
                            //---sent notification to admin----------------
                            var users1 = await _usermanager.FindByIdAsync("6852cc0f-f62e-42a4-8dc7-5fd0478ba197");
                            string deviceid1 = users1.deviceid;
                            fcmNotification obj = new fcmNotification();
                            obj.adminNotification(deviceid1, "New Order Insert", "", "New Order");
                        }
                    }
                    if (OrderId == 0)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        var orders = _ordersServices.GetById(OrderId);
                        return Ok(orders);

                    }
                    // customerid, amount, placedate, deliveryboyid, paymentstatus, orderstatus, isdeleted, isactive
                    //customer.deviceid = deviceId;
                    //await CustomerRegistrationservices.UpdateAsync(customer);

                    //if (id < 0)
                    //{
                    //    return BadRequest();
                    //}
                    //else
                    //{

                    //    return Ok(customer);
                    //}
                }
                return BadRequest();
            }
        }

        //[HttpPost]
        //[Route("OrderInsertandOrderProduct")]
        //public async Task<IActionResult> OrderInsertandOrderProduct(int customerid, decimal totalamount, string OrderProducts_JSONString,string promocode,string storedid,string discount,string orderstatus,string paymenttype,string paymentstatus,string deliveryaddress,string transactionid, string instruction,string customerdeliverylatitude,string customerdeliverylongitude)
        //{


        //    //var mostUsedTags = db.Tags.OrderByDescending(t => t.Videos.Count).Take(10);
        //    //var customer = CustomerRegistrationservices.GetById(id);
        //    if (customerid == 0)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        orders objorders = new orders();
        //        objorders.customerid = customerid;
        //        objorders.amount = totalamount;
        //        //objorders.placedate = DateTime.UtcNow;
        //        objorders.placedate = DateTime.Now;
        //        objorders.paymentstatus = paymentstatus;
        //        objorders.orderstatus = orderstatus;

        //        objorders.discount = Convert.ToDecimal(discount);
        //        objorders.storeid  = storedid;
        //        objorders.deliveryaddress = deliveryaddress;
        //        objorders.paymenttype = paymenttype;
        //        objorders.promocode = promocode;
        //        objorders.transactionid = transactionid;
        //        objorders.instructions  = instruction;
        //        // objorders.propmocode = promocode;

        //        objorders.customerdeliverylatitude = customerdeliverylatitude;
        //        objorders.customerdeliverylongitude = customerdeliverylongitude;
        //        //                , deliveryboyid, paymentstatus, orderstatus, isdeleted, discount, storeid, 
        //        //deliveryaddress, paymenttype, promocode

        //        objorders.storeid = storedid;
        //        //if (promocode == ""|| storedid=="")
        //        //{
        //        //    objorders.discount = 0;
        //        //}
        //        //else
        //        //{
        //        //    objorders.discount = _storedetailsServices.GetAll().Where(x => x.storeid == storedid&&x.promocode==promocode).FirstOrDefault().discount;
        //        //}
        //        int OrderProductAdd = 0;
        //        int OrderId = 0;
        //        var dtOrderProducts = JsonConvert.DeserializeObject<DataTable>(OrderProducts_JSONString);
        //        if (dtOrderProducts != null)
        //        {
        //            if (dtOrderProducts.Rows.Count > 0)
        //            {
        //                OrderId = await _ordersServices.CreateAsync(objorders);
        //                if (OrderId > 0)
        //                {
        //                    for (int i = 0; i < dtOrderProducts.Rows.Count; i++)
        //                    {
        //                        orderproducts objorderproduct = new orderproducts();
        //                        objorderproduct.oid = OrderId;
        //                        objorderproduct.pid = Convert.ToInt32(dtOrderProducts.Rows[i]["productid"]);
        //                        objorderproduct.qty = Convert.ToInt64(dtOrderProducts.Rows[i]["quantites"]);
        //                        objorderproduct.price = Convert.ToInt64(dtOrderProducts.Rows[i]["productprice"]);
        //                        objorderproduct.isdeleted = false;
        //                        await _orderproductServices.CreateAsync(objorderproduct);



        //                        //id, oid, placedate, orderstatus
        //                        //   id, oid, pid, qty, price, isdeleted
        //                        //[{"productid":"1","productprice":"500","quantites":10},{"productid":"2","productprice":"500","quantites":10}]

        //                    }
        //                }


        //                orderhistory objorderhistory = new orderhistory();
        //                objorderhistory.oid = OrderId;
        //                objorderhistory.placedate = DateTime.UtcNow;
        //                objorderhistory.orderstatus = "place Order";
        //                await _orderhistoryServices.CreateAsync(objorderhistory);

        //                var users = await _usermanager.FindByIdAsync(storedid);
        //                string storeDeviceId = users.deviceid;
        //                if (storeDeviceId == null || storeDeviceId.ToString().Trim() == "")
        //                {

        //                }
        //                else
        //                {


        //                    string sResponseFromServer = string.Empty, finalResult = string.Empty;
        //                    try
        //                    {

        //                        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        //                        tRequest.Method = "post";
        //                        //serverKey - Key from Firebase cloud messaging server   customer
        //                        //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
        //                        //store change 9.9.20
        //                        //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAr0cwgUE:APA91bEs5PB48LpheJuGQOJi8jENylDdtBgGA5tcHFY2Kbz4-FwNLocAN8z7X7c4ADuP6vA7MSE3M6hx5OHp12iFt0yb7zfHO16c7mlgnppsEOFY8J4WRfpOUI-RkbXBLBwMqYwwDyYX"));
        //                        ////Sender Id - From firebase project setting  
        //                        //tRequest.Headers.Add(string.Format("Sender: id={0}", "752813637953"));

        //                        tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAA-grvO4U:APA91bG1TeBl5uVNLOHGyjSYSJ_-PZiOFKeSUkjhx4do27iECafs1dVdAyhE6-QvMDON6xrz-YOa10tMgFdmy_w1amPXVHsXLWrAggDh8oU0c1F8CvdBW6aGc1wrqP8OlQ86ZzxzkTuS"));
        //                        //Sender Id - From firebase project setting  
        //                        tRequest.Headers.Add(string.Format("Sender: id={0}", "1073925274501"));
        //                        tRequest.ContentType = "application/json";
        //                        var payload = new
        //                        {
        //                            to = storeDeviceId,
        //                            priority = "high",
        //                            content_available = true,
        //                            notification = new
        //                            {
        //                                //body = "New Order No. - " + OrderId + " insert",
        //                                body= "New Order Received",
        //                                title = "New Order",
        //                                badge = 1
        //                            },
        //                            data = new
        //                            {
        //                                key1 = "value1",
        //                                key2 = "value2"
        //                            }

        //                        };

        //                        //string postbody = JsonConvert.SerializeObject(payload).ToString();

        //                        var serializer = new JavaScriptSerializer();
        //                        var postbody = serializer.Serialize(payload);
        //                        Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
        //                        tRequest.ContentLength = byteArray.Length;
        //                        using (Stream dataStream = tRequest.GetRequestStream())
        //                        {
        //                            dataStream.Write(byteArray, 0, byteArray.Length);
        //                            using (WebResponse tResponse = tRequest.GetResponse())
        //                            {
        //                                using (Stream dataStreamResponse = tResponse.GetResponseStream())
        //                                {
        //                                    if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
        //                                        {
        //                                            sResponseFromServer = tReader.ReadToEnd();
        //                                            //result.Response = sResponseFromServer;
        //                                        }
        //                                }
        //                            }
        //                        }

        //                    }

        //                    catch (Exception ex)
        //                    {
        //                        string s = ex.Message;
        //                        // throw ex;
        //                    }
        //                    // return Ok(sResponseFromServer);


        //                }




        //            }
        //        }
        //        if(OrderId==0)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            var orders = _ordersServices.GetById(OrderId);
        //            return Ok(orders);

        //        }
        //        // customerid, amount, placedate, deliveryboyid, paymentstatus, orderstatus, isdeleted, isactive
        //        //customer.deviceid = deviceId;
        //        //await CustomerRegistrationservices.UpdateAsync(customer);

        //        //if (id < 0)
        //        //{
        //        //    return BadRequest();
        //        //}
        //        //else
        //        //{

        //        //    return Ok(customer);
        //        //}
        //    }
        //    return BadRequest();
        //}

        [HttpGet]
        [Route("getCuisinebyHotelId")]
        public async Task<IActionResult> getCuisinebyHotelId(string hotelid)
        {
            //var storeidd = _productservices.GetAll().Where(x => x.productcuisineid == Cuisineid).Select(x => x.storeid).Distinct().ToList();
            //var hotels = _storedetailsServices.GetAll().Where(hotels => storeidd.Contains(hotels.storeid)).ToList();

            var cusineid = _productservices.GetAll().Where(x => x.storeid == hotelid).Select(x => x.productcuisineid).Distinct().ToList();
            var cusineList = _productcuisinemasterservices.GetAll().Where(hotels => cusineid.Contains(hotels.id)).ToList();
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (cusineList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cusineList);
            }
            //return BadRequest();
        }


        [HttpGet]
        [Route("getNearestHotelbyCusineidandlocation")]
        public async Task<IActionResult> getNearestHotelbyCusineidandlocation(int cusineid, decimal Latitude, decimal Longitude)
        {


            var paramter = new DynamicParameters();
            paramter.Add("@cusineid", cusineid);
            paramter.Add("@Latitude", Latitude);
            paramter.Add("@Longitude", Longitude);
            var orderlist = _ISP_Call.List<storeDetailsViewModel>("getNearestHotelbyCusineidandlocation", paramter);
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
        [Route("getNearestHotelbyProductNameandlocation")]
        public async Task<IActionResult> getNearestHotelbyProductNameandlocation(string productname, decimal Latitude, decimal Longitude)
        {
            //var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllPending", null);
            //orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));


            var paramter = new DynamicParameters();
            paramter.Add("@productname", productname);
            paramter.Add("@Latitude", Latitude);
            paramter.Add("@Longitude", Longitude);
            var orderlist = _ISP_Call.List<orderselectallViewModel>("getNearestHotelbyProductNameandlocation", paramter);
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
        [Route("hotelselectallbyLocationPaging")]
        public async Task<IActionResult> hotelselectallbyLocationPaging(decimal Latitude, decimal Longitude, string page)
        {
            //Int64 rowCount = 10;
            //Int64 startIndex = 0;
            //startIndex = (rowCount * Convert.ToInt64(page));

            var paramter = new DynamicParameters();
            paramter.Add("@Latitude", Latitude);
            paramter.Add("@Longitude", Longitude);
            //paramter.Add("@distance", 5);
            paramter.Add("@pagingStart", Convert.ToInt64(page));
            //paramter.Add("@NoofRecord", rowCount);
           

            //storedetailsListViewmodel
            var storeList = _ISP_Call.List<storedetailsListViewmodelPaging>("getNearestStoredbyLocationNewPaging", paramter);
            if (storeList != null)
            {
                return Ok(storeList);

            }
            else
            {
                return NotFound();
            }
            //return BadRequest();
        }
    }

}
