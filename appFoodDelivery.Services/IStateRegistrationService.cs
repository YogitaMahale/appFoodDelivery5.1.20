using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Services
{
   public  interface IStateRegistrationService
    {
        Task CreateAsync(StateRegistration obj);
        StateRegistration GetById(int affilateid);
        Task UpdateAsync(StateRegistration obj);
        Task Delete(int countryid);
        IEnumerable<SelectListItem> GetAllState(int countryid);
        IEnumerable<StateRegistration> GetAll();
    }
}
