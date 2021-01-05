using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
   public  interface IdeliveryboyPendingAmtServices
    {
        Task CreateAsync(deliveryboyPendingAmt obj);
        deliveryboyPendingAmt GetById(int affilateid);
        Task UpdateAsync(deliveryboyPendingAmt obj);
        
        IEnumerable<deliveryboyPendingAmt> GetAll();
    }
}
