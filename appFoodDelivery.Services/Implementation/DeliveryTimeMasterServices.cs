using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
 public    class DeliveryTimeMasterServices:IDeliveryTimeMasterServices
    {
        private readonly ApplicationDbContext _context;
        public DeliveryTimeMasterServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(deliverytimemaster  obj)
        {
            await _context.deliverytimemaster.AddAsync(obj);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var customer = GetById(id);
            customer.isdeleted = true;
            _context.deliverytimemaster.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<deliverytimemaster> GetAll() => _context.deliverytimemaster.Where(x => x.isdeleted == false).ToList();

        //public radiusmaster GetById(int id) =>
        //    _context.radiusmaster.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(deliverytimemaster obj)
        {
            _context.deliverytimemaster.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------
        public void Updatestatus(deliverytimemaster obj)
        {
            _context.deliverytimemaster.Update(obj);
            _context.SaveChanges();

        }


        public deliverytimemaster GetById(int id) =>
            _context.deliverytimemaster.Where(x => x.id == id).FirstOrDefault();
    }
}
