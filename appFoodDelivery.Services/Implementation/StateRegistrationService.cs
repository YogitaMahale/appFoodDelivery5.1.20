using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace appFoodDelivery.Services.Implementation
{
   public  class StateRegistrationService:IStateRegistrationService
    {
        private readonly ApplicationDbContext _context;
        public StateRegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(StateRegistration obj)
        {
            await _context.StateRegistration.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int stateid)
        {
            var state = GetById(stateid);
            state.isdeleted = true;
            _context.StateRegistration.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<StateRegistration> GetAll() => _context.StateRegistration.Where(x => x.isdeleted == false).ToList();

        public StateRegistration GetById(int affilateid) =>
            _context.StateRegistration.Where(x => x.id == affilateid).FirstOrDefault();

        public async Task UpdateAsync(StateRegistration obj)
        {
            _context.StateRegistration.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<SelectListItem> GetAllState(int countryid)
        {
            return GetAll().Where(x=>x.countryid==countryid).Select(emp => new SelectListItem()
            {
                Text = emp.StateName,
                Value = emp.id.ToString()
            });
        }

    }
}
