using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class GetCustomersByCountryUseCase
    {
     

        private readonly ICustomerRepository _repository;

        public GetCustomersByCountryUseCase()
        {
        }

        public GetCustomersByCountryUseCase(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> ExecuteAsync(string country)
        {
            try {
                var customers = await _repository.GetCustomersByCountryAsync(country);
                return customers.OrderBy(c => c.ContactName).ToList();

            }
            catch (Exception ex) {
            
               Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

}
