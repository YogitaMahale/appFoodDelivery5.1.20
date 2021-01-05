using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using appFoodDelivery.Entity;
using appFoodDelivery.Services;
 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.API
{
    [Route("food")]
    public class plathoraAPI : Controller
    {
        private readonly Istoreownerservices _storeownerservices;
        
        public plathoraAPI(Istoreownerservices storeownerservices)
        {
            _storeownerservices = storeownerservices;
        }

        [HttpGet]
        [Route("storeownerSelectAll")]
        public async Task<IActionResult> storeownerSelectAll()
        {
            try
            {
                IEnumerable<storeowner> obj = _storeownerservices.GetAll();
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
        }
 
    }
}
