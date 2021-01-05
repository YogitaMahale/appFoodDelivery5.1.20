using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Services;
namespace appFoodDelivery.Services.Implementation
{
   public  class orderproductServices: IorderproductServices
    {
        private readonly ApplicationDbContext _context;
        public orderproductServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(orderproducts obj)
        {
            await _context.orderproducts.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public Task CreateAsync(orders obj)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.orderproducts.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<orderproducts> GetAll() => _context.orderproducts.Where(x => x.isdeleted == false).ToList();
        public orderproducts getbyid(int id) =>
            _context.orderproducts.Where(x => x.id == id).FirstOrDefault();

        public orderproducts GetById(int id) =>
            _context.orderproducts.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(orderproducts obj)
        {
            _context.orderproducts.Update(obj);
            await _context.SaveChangesAsync();
        }
 
    }
}
 