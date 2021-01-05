using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Services
{
  public   interface IchargesServices
    {

     
        charges GetById(int id);
       Task UpdateAsync(charges obj);
      
    
    }
}
