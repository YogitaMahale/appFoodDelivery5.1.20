using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Services
{
 
    public interface IorderproductServices
    {
        Task CreateAsync(orderproducts obj);

        orderproducts GetById(int id);
        Task UpdateAsync(orderproducts obj);

        Task Delete(int id);

        IEnumerable<orderproducts> GetAll();
    }
}
