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
    public class CustomerRegistrationservices : ICustomerRegistrationservices
    {


        private readonly ApplicationDbContext _context;
        public CustomerRegistrationservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(CustomerRegistration obj)
        {
            await _context.CustomerRegistration.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }
        //public async Task  CreateAsync(CustomerRegistration obj)
        //{
        //    await _context.CustomerRegistration.AddAsync(obj);
        //    await _context.SaveChangesAsync();

        //}
        public async Task Delete(int customerid)
        {
            var customer = GetById(customerid);
            customer.isdeleted = true;
            _context.CustomerRegistration.Update(customer);
            // _context.Remove(affilate);
            await _context.SaveChangesAsync();

        }

        public    IEnumerable<CustomerRegistration> GetAll() =>    _context.CustomerRegistration.AsNoTracking().Where(x => x.isdeleted == false).ToList();
       
        public CustomerRegistration  GetById(int customerid) =>
            _context.CustomerRegistration .Where(x => x.id == customerid).FirstOrDefault();

        public async Task UpdateAsync(CustomerRegistration obj)
        {
            _context.CustomerRegistration .Update(obj);
            await _context.SaveChangesAsync();
        }
        //------

        
 
    }
}
