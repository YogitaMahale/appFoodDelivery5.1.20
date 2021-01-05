using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
  public  class sliderServices:IsliderServices
    {
        private readonly ApplicationDbContext _context;
        public sliderServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(slider obj)
        {
            await _context.slider.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.slider.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<slider> GetAll() => _context.slider.Where(x => x.isdeleted == false).ToList();
        public slider getbyid(int id) =>
            _context.slider.Where(x => x.id == id).FirstOrDefault();

        public slider GetById(int id) =>
            _context.slider.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(slider obj)
        {
            _context.slider.Update(obj);
            await _context.SaveChangesAsync();
        }
        
    }
}
