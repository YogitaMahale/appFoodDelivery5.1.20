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
   public  class deliveryboyPendingAmtServices:IdeliveryboyPendingAmtServices
    {
        private readonly ApplicationDbContext _context;
        public deliveryboyPendingAmtServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(deliveryboyPendingAmt obj)
        {
            await _context.deliveryboyPendingAmt.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

      
        public IEnumerable<deliveryboyPendingAmt> GetAll() => _context.deliveryboyPendingAmt.ToList();
        public deliveryboyPendingAmt getbyid(int id) =>
            _context.deliveryboyPendingAmt.Where(x => x.id == id).FirstOrDefault();

        public deliveryboyPendingAmt GetById(int id) =>
            _context.deliveryboyPendingAmt.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(deliveryboyPendingAmt obj)
        {
            _context.deliveryboyPendingAmt.Update(obj);
            await _context.SaveChangesAsync();
        }
         
    }
}
