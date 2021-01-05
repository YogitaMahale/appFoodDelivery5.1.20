using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
   public  class promocodeServices:IpromocodeServices
    {
        private readonly ApplicationDbContext _context;
        public promocodeServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(promocodemaster obj)
        {
            await _context.promocodemaster.AddAsync(obj);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var customer = GetById(id);
            customer.isdeleted = true;
            _context.promocodemaster.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<promocodemaster> GetAll() => _context.promocodemaster.Where(x => x.isdeleted == false).ToList();


        public async Task UpdateAsync(promocodemaster obj)
        {
            _context.promocodemaster.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------



        public promocodemaster GetById(int id) =>
            _context.promocodemaster.Where(x => x.id == id).FirstOrDefault();
    }
}
