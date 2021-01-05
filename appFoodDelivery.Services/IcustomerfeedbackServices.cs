using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Services
{
  public   interface IcustomerfeedbackServices
    {
        Task<int> CreateAsync(customerfeedback obj);

        customerfeedback GetById(int id);
        Task UpdateAsync(customerfeedback obj);

        Task Delete(int id);

        IEnumerable<customerfeedback> GetAll();
    }
}
