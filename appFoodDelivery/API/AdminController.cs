using appFoodDelivery.Entity;
using appFoodDelivery.Notification;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.API
{
    [Route("Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        public readonly IordersServices _ordersServices;
        public readonly IdriverRegistrationServices _driverRegistrationServices;
        public readonly ISP_Call _ISP_Call;
        public readonly IorderhistoryServices _orderhistoryServices;
        public readonly ICustomerRegistrationservices _CustomerRegistrationservices;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> signinmanager;
        public AdminController(IordersServices ordersServices, ISP_Call ISP_Call, IdriverRegistrationServices driverRegistrationServices, IorderhistoryServices orderhistoryServices, ICustomerRegistrationservices CustomerRegistrationservices, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> _signinmanager)
        {
            _ordersServices = ordersServices;
            _ISP_Call = ISP_Call;
            _driverRegistrationServices = driverRegistrationServices;
            _orderhistoryServices = orderhistoryServices;
            _CustomerRegistrationservices = CustomerRegistrationservices;
            _usermanager = usermanager;
            signinmanager = _signinmanager;
        }

        [HttpPut]
        [Route("AdminAssignDeliveryboytoOrderId")]
        public async Task<IActionResult> AdminAssignDeliveryboytoOrderId(int orderid, int deliveryboyid)
        {
            orders obj = _ordersServices.GetById(orderid);// await _usermanager.GetUserAsync(User); 

            if (obj == null)
            {
                string myJson = "{\"message\": " + "\"Record Not Found\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                if (string.IsNullOrEmpty(Convert.ToString(obj.deliveryboyid)))
                {


                    obj.deliveryboyid = deliveryboyid;
                    obj.acceptedby = "Admin";
                    await _ordersServices.UpdateAsync(obj);

                    var driverdetails = _driverRegistrationServices.GetById(deliveryboyid);
                    orderhistory objorderhistory = new orderhistory();
                    objorderhistory.oid = orderid;
                    objorderhistory.placedate = DateTime.UtcNow;
                    objorderhistory.orderstatus = "Admin assign Order to this Delivery boy." + driverdetails.name + "  . OrderID  :" + orderid;
                    await _orderhistoryServices.CreateAsync(objorderhistory);

                    #region "Notification customer and store"
                    int customerid = obj.customerid;
                    string customerDeviceId = _CustomerRegistrationservices.GetById(customerid).deviceid;
                    string customerMsg = driverdetails.name + " will be Delivering Your order";
                    string customerTitle = "Delivering Your order";
                    fcmNotification objfcmNotification = new fcmNotification();
                    objfcmNotification.customerNotification(customerDeviceId, customerMsg, "", customerTitle);

                    var storeDeviceId = _usermanager.Users.Where(x => x.Id == obj.storeid).FirstOrDefault().deviceid;
                    string storeMsg = "Admin Assign delivery boy " + driverdetails.name + " to this Order Id : " + orderid;
                    string storeTitle = "Assign Deliveryboy";
                    objfcmNotification.storeNotification(storeDeviceId, storeMsg, "", storeTitle);

                    #endregion


                    string myJson = "{\"message\": " + "\"Order Assign To Delivery boy Successfully\"" + "}";
                    return Ok(obj);
                }
                else
                {
                    string myJson = "{\"message\": " + "\"This Order Id Already assign delivery boy\"" + "}";
                    return BadRequest(myJson);
                }
            }

        }

        [HttpGet]
        [Route("CustomerLogin")]
        public async Task<IActionResult> AdminLogin(string email, string password)
        {
            try
            {
                var result = await signinmanager.PasswordSignInAsync(email, password, false, false);
                //   return RedirectToAction("Index", "Home");
                if (result.Succeeded)
                {
                    var users = await _usermanager.FindByEmailAsync(email);

                    //var user = await _usermanager.FindByIdAsync(usr.Id);
                    var role = await _usermanager.GetRolesAsync(users);
                    string roles = role[0].ToString();

                    if (roles.ToString().ToUpper().Trim() == "Admin".ToString().ToUpper().Trim() || roles.ToString().ToUpper().Trim() == "Manager".ToString().ToUpper().Trim())
                    {
                        if (users != null)
                        {
                            return Ok(users);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    else
                    {

                        string myJson = "{'Message': " + "Unauthorised Access" + "}";
                        return NotFound(myJson);
                    }





                }
                return NotFound();
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

        [HttpPut]
        [Route("updateDeviceId")]
        public async Task<IActionResult> updateDeviceId(string deviceId, string id)
        {
            try
            {
                var users = await _usermanager.FindByIdAsync(id);
                if (users != null)
                {
                    users.deviceid = deviceId;
                    var res = await _usermanager.UpdateAsync(users);
                    if (res.Succeeded)
                    {
                        //string myJson = "{'Message': " + "Unauthorised Access" + "}";
                        return Ok("Record Updated Successfully");
                    }
                    else
                    {
                        return NotFound("Record Not Updated");
                    }
                }
                else
                {
                    return NotFound("Record Not Found");
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

    }
}
