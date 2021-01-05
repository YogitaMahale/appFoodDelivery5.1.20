using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
    public  class versionsServices: IversionsServices
    {
        private readonly ApplicationDbContext _context;
        public versionsServices(ApplicationDbContext context)
        {
            _context = context;
        }



        public versions GetById(int affilateid) =>
            _context.versions.Where(x => x.id == affilateid).FirstOrDefault();

        public async Task UpdateAsync(versions obj)
        {
            _context.versions.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
