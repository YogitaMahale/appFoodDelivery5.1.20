using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
   public  class storeownerservices:Istoreownerservices
    {

        private readonly ApplicationDbContext _context;
        public storeownerservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(storeowner obj)
        {
            await _context.storeowner.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }
       
        public async Task Delete(int customerid)
        {
            var customer = GetById(customerid);
            customer.isdeleted = true;
            _context.storeowner.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<storeowner> GetAll() => _context.storeowner.AsNoTracking().Where(x => x.isdeleted == false).ToList();

        public storeowner GetById(int customerid) =>
            _context.storeowner.Where(x => x.id == customerid).FirstOrDefault();

        public async Task UpdateAsync(storeowner obj)
        {
            _context.storeowner.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------
        public void Updatestatus(storeowner obj)
        {
            _context.storeowner.Update(obj);
            _context.SaveChanges();

        }


    }
}
