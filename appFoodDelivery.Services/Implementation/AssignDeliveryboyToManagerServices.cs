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
    public class AssignDeliveryboyToManagerServices : IAssignDeliveryboyToManagerServices
    {
        private readonly ApplicationDbContext _context;
        public AssignDeliveryboyToManagerServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(AssignDeliveryboyToManager obj)
        {
            await _context.AssignDeliveryboyToManager.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = _context.AssignDeliveryboyToManager.Where(x => x.Id == id).FirstOrDefault();


            _context.AssignDeliveryboyToManager.Remove(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<AssignDeliveryboyToManager> GetAll() =>_context.AssignDeliveryboyToManager.ToList();
       

        public AssignDeliveryboyToManager GetById(int id)=>      
            _context.AssignDeliveryboyToManager.Where(x => x.Id == id).FirstOrDefault();
        

        public async Task UpdateAsync(AssignDeliveryboyToManager obj)
        {
            _context.AssignDeliveryboyToManager.Update(obj);
            await _context.SaveChangesAsync();
        }
        
    }
}
