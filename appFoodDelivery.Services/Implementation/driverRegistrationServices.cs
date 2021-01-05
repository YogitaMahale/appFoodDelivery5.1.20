using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using appFoodDelivery.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace appFoodDelivery.Services.Implementation
{
   public  class driverRegistrationServices:IdriverRegistrationServices
    {
        private readonly ApplicationDbContext _context;
        public driverRegistrationServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(driverRegistration obj)
        {
            await _context.driverRegistration.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }

        public async Task Delete(int id)
        {
            var customer = GetById(id);
            customer.isdeleted = true;
            _context.driverRegistration.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<driverRegistration> GetAll() => _context.driverRegistration.AsNoTracking().Where(x => x.isdeleted == false).ToList();

        public driverRegistration GetById(int customerid) =>
            _context.driverRegistration.Where(x => x.id == customerid).FirstOrDefault();

        public async Task UpdateAsync(driverRegistration obj)
        {
            _context.driverRegistration.Update(obj);
            await _context.SaveChangesAsync();
        }
        //------
        public void Updatestatus(driverRegistration obj)
        {
            _context.driverRegistration.Update(obj);
            _context.SaveChanges();

        }
        public IEnumerable<SelectListItem> GetAlldriver()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.name,
                Value = emp.id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllstatus()
        {
            return _context.status.ToList().Select(emp => new SelectListItem()
            {
                Text = emp.name2,
                Value = emp.name1.ToString()
            });
        }
    }
}
