using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using appFoodDelivery.Entity;
 
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
   public  class RadiusMasterServices: IRadiusMasterServices
    {
        private readonly ApplicationDbContext _context;
        public RadiusMasterServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(radiusmaster obj)
        {
            await _context.radiusmaster.AddAsync(obj);
            await _context.SaveChangesAsync();
           
        }

        public async Task Delete(int id)
        {
            var customer = GetById(id);
            customer.isdeleted = true;
            _context.radiusmaster.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<radiusmaster> GetAll() => _context.radiusmaster.Where(x => x.isdeleted == false).ToList();

        //public radiusmaster GetById(int id) =>
        //    _context.radiusmaster.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(radiusmaster obj)
        {
            _context.radiusmaster.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------
        public void Updatestatus(radiusmaster obj)
        {
            _context.radiusmaster.Update(obj);
            _context.SaveChanges();

        }

      
        public radiusmaster GetById(int id) =>
            _context.radiusmaster.Where(x => x.id == id).FirstOrDefault();
    }
}
