using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace appFoodDelivery.Services.Implementation
{
  public   class storedetailsServices:IstoredetailsServices
    {
        private readonly ApplicationDbContext _context;
        public storedetailsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(storedetails obj)
        {
            await _context.storedetails.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }


        public storedetails GetById(int id) =>
            _context.storedetails.Where(x => x.id == id).FirstOrDefault();
        public IEnumerable<storedetails> GetAll() => _context.storedetails.Where(x => x.isdeleted == false).ToList();

        public async Task UpdateAsync(storedetails obj)
        {
            _context.storedetails.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------

        public IEnumerable<SelectListItem> GetAllStore()
        {
            var obj = _context.storedetails.Where(x => x.isdeleted == false).ToList();
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.storename,
                Value = emp.storeid
            });
        }

    }
}
