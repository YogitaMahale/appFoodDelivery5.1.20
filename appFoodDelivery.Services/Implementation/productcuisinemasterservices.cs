using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using appFoodDelivery.Entity;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
  public  class productcuisinemasterservices:Iproductcuisinemasterservices
    {
        private readonly ApplicationDbContext _context;
        public productcuisinemasterservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(productcuisinemaster  obj)
        {
            await _context.productcuisinemaster.AddAsync(obj);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var customer = GetById(id);
            customer.isdeleted = true;
            _context.productcuisinemaster.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<productcuisinemaster> GetAll() => _context.productcuisinemaster.Where(x => x.isdeleted == false).ToList();

        //public radiusmaster GetById(int id) =>
        //    _context.radiusmaster.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(productcuisinemaster obj)
        {
            _context.productcuisinemaster.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------
        public void Updatestatus(productcuisinemaster obj)
        {
            _context.productcuisinemaster.Update(obj);
            _context.SaveChanges();

        }


        public productcuisinemaster GetById(int id) =>
            _context.productcuisinemaster.Where(x => x.id == id).FirstOrDefault();
    }
}
