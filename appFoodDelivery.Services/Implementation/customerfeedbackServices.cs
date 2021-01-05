using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
  public   class customerfeedbackServices:IcustomerfeedbackServices
    {
        private readonly ApplicationDbContext _context;
        public customerfeedbackServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(customerfeedback obj)
        {
            await _context.customerfeedback.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.customerfeedback.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<customerfeedback> GetAll() => _context.customerfeedback.Where(x => x.isdeleted == false).ToList();
        public customerfeedback getbyid(int id) =>
            _context.customerfeedback.Where(x => x.id == id).FirstOrDefault();

        public customerfeedback GetById(int id) =>
            _context.customerfeedback.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(customerfeedback obj)
        {
            _context.customerfeedback.Update(obj);
            await _context.SaveChangesAsync();
        }


    }
}
