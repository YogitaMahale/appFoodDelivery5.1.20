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
  public  class orderhistoryServices:IorderhistoryServices
    {
        private readonly ApplicationDbContext _context;
        public orderhistoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(orderhistory obj)
        {
            await _context.orderhistory.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        //public async Task Delete(int id)
        //{
        //    var state = getbyid(id);
        //    state.isdeleted = true;
        //    _context.orderhistory.Update(state);
        //    await _context.SaveChangesAsync();
        //}
        public IEnumerable<orderhistory> GetAll() => _context.orderhistory.ToList();
        public orderhistory getbyid(int id) =>
            _context.orderhistory.Where(x => x.id == id).FirstOrDefault();

        public orderhistory GetById(int id) =>
            _context.orderhistory.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(orderhistory obj)
        {
            _context.orderhistory.Update(obj);
            await _context.SaveChangesAsync();
        }


    }
}
