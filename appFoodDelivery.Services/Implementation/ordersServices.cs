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
  public  class ordersServices: IordersServices
    {
        private readonly ApplicationDbContext _context;
        public ordersServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(orders  obj)
        {
            await _context.orders.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.orders.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<orders> GetAll() => _context.orders.Where(x => x.isdeleted == false).ToList();
        public orders getbyid(int id) =>
            _context.orders.Where(x => x.id == id).FirstOrDefault();

        public orders GetById(int id) =>
            _context.orders.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(orders obj)
        {
            _context.orders.Update(obj);
            await _context.SaveChangesAsync();
        }

        
    }
}
