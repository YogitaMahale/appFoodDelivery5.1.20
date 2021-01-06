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
    public class AdminCollectionservices : IAdminCollectionservices
    {
        private readonly ApplicationDbContext _context;
        public AdminCollectionservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(AdminCollection  obj)
        {
            await _context.AdminCollection.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = GetById(id);
            state.isdeleted = true;
            _context.AdminCollection.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<AdminCollection> GetAll() =>_context.AdminCollection.Where(x=>x.isdeleted== false).ToList();
        
        public AdminCollection GetById(int id)=>      
            _context.AdminCollection.Where(x => x.id == id).FirstOrDefault();
        

        public async Task UpdateAsync(AdminCollection obj)
        {
            _context.AdminCollection.Update(obj);
            await _context.SaveChangesAsync();
        }
        
    }
}
