using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace appFoodDelivery.Services.Implementation
{
  public   class DeliveryboytoCustomerfeedbackSerivces: IDeliveryboytoCustomerfeedbackSerivces
    {
        private readonly ApplicationDbContext _context;
        public DeliveryboytoCustomerfeedbackSerivces(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(DeliveryboytoCustomerfeedback obj)
        {
            await _context.DeliveryboytoCustomerfeedback.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }

       
        public IEnumerable<DeliveryboytoCustomerfeedback> GetAll() => _context.DeliveryboytoCustomerfeedback.Where(x => x.isdeleted == false).ToList();

        
    }
}
