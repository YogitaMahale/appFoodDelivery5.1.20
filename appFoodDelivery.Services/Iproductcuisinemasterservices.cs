using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;

namespace appFoodDelivery.Services
{
   public  interface Iproductcuisinemasterservices
    {
        Task CreateAsync(productcuisinemaster obj);

        productcuisinemaster GetById(int id);
        Task UpdateAsync(productcuisinemaster obj);
        void Updatestatus(productcuisinemaster obj);
        Task Delete(int id);

        IEnumerable<productcuisinemaster> GetAll();
        
    }
}
