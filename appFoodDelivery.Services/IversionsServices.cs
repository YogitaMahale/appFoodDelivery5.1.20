using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
 public    interface IversionsServices
    {
        versions GetById(int id);
        Task UpdateAsync(versions obj);

    }
}
