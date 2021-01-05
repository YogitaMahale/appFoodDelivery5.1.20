using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Services;

namespace plathora.Services.Implementation
{
    public class CityRegistrationservices : ICityRegistrationservices
    {
        private readonly ApplicationDbContext _context;
        public CityRegistrationservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CityRegistration  obj)
        {
            await _context.CityRegistration .AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.CityRegistration.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<CityRegistration> GetAll() =>_context.CityRegistration.Where(x=>x.isdeleted== false).ToList();
        public CityRegistration  getbyid(int id) =>
            _context.CityRegistration.Where(x => x.id == id).FirstOrDefault();

        public CityRegistration GetById(int id)=>      
            _context.CityRegistration.Where(x => x.id == id).FirstOrDefault();
        

        public async Task UpdateAsync(CityRegistration  obj)
        {
            _context.CityRegistration.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<SelectListItem> GetAllCity(int stateid)
        {
            return GetAll().Where(x => x.stateid == stateid).Select(emp => new SelectListItem()
            {
                Text = emp.cityName,
                Value = emp.id.ToString()
            });
        }
    }
}
