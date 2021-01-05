using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
  public   interface ICountryRegistrationservices
    {
        Task CreateAsync(CountryRegistration obj);
        CountryRegistration GetById(int affilateid);
        Task UpdateAsync(CountryRegistration obj);
        Task Delete(int countryid);

        IEnumerable<CountryRegistration> GetAll();
        IEnumerable<SelectListItem> GetAllCountry();
    }
}
