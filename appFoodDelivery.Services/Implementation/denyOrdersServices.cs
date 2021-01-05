using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace appFoodDelivery.Services.Implementation
{
    public class denyOrdersServices:IdenyOrdersServices
    {
        private readonly ApplicationDbContext _context;
        public denyOrdersServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(denyOrders obj)
        {
            await _context.denyOrders.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }

        public async Task Delete(int id)
        {
            var customer = GetById(id);
            customer.isdeleted = true;
            _context.denyOrders.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<denyOrders> GetAll() => _context.denyOrders.Where(x => x.isdeleted == false).ToList();


        public async Task UpdateAsync(denyOrders obj)
        {
            _context.denyOrders.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------



        public denyOrders GetById(int id) =>
            _context.denyOrders.Where(x => x.id == id).FirstOrDefault();
    }
}
