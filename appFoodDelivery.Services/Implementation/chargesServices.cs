using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
   public  class chargesServices:IchargesServices
    {
        private readonly ApplicationDbContext _context;
        public chargesServices(ApplicationDbContext context)
        {
            _context = context;
        }
         
       
       
        public charges GetById(int affilateid) =>
            _context.charges.Where(x => x.id == affilateid).FirstOrDefault();

        public async Task UpdateAsync(charges obj)
        {
            _context.charges.Update(obj);
            await _context.SaveChangesAsync();
        }
 
    }
}
