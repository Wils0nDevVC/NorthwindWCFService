using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Persistense
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NorthwindContext _context;

        public CustomerRepository()
        {
        }

        public CustomerRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersByCountryAsync(string country)
        {
            return await _context.Customers
                                 .Where(c => c.Country == country)
                                 .ToListAsync();
        }
    }
}
