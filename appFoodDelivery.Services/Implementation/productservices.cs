using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
  public   class productservices:Iproductservices
    {
        private readonly ApplicationDbContext _context;
        public productservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(product obj)
        {
            await _context.product.AddAsync(obj);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var customer = GetById(id);
            customer.isdeleted = true;
            _context.product.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<product> GetAll() => _context.product.Where(x => x.isdeleted == false).ToList();

         
        public async Task UpdateAsync(product obj)
        {
            _context.product.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------
       


        public product GetById(int id) =>
            _context.product.Where(x => x.id == id).FirstOrDefault();
    }
}
