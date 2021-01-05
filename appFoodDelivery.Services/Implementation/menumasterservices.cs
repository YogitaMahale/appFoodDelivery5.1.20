using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using appFoodDelivery.Entity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace appFoodDelivery.Services.Implementation
{
  public  class menumasterservices : Imenumasterservices
    {
        private readonly ApplicationDbContext _context;
        public menumasterservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(menumaster obj)
        {
            await _context.menumasters.AddAsync(obj);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var customer = GetById(id);
            customer.isdeleted = true;
            _context.menumasters.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<menumaster> GetAll() => _context.menumasters.Where(x => x.isdeleted == false).ToList();

        //public radiusmaster GetById(int id) =>
        //    _context.radiusmaster.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(menumaster obj)
        {
            _context.menumasters.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------
        public void Updatestatus(menumaster obj)
        {
            _context.menumasters.Update(obj);
            _context.SaveChanges();

        }


        public menumaster GetById(int id) =>
            _context.menumasters.Where(x => x.id == id).FirstOrDefault();


        public IEnumerable<SelectListItem> GetAllMenuList(int cusineid)
        {
            return GetAll().Where(x => x.productcuisineid == cusineid).Select(emp => new SelectListItem()
            {
                Text = emp.name,
                Value = emp.id.ToString()
            });
        }

    }
}
