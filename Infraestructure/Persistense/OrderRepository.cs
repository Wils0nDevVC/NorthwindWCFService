using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistense
{
    public class OrderRepository : IOrderRepository
    {


        private readonly NorthwindContext _context;

        public OrderRepository() { }
        public OrderRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(string customerId)
        {
            return await _context.Orders
                                 .Where(o => o.CustomerId == customerId)
                                 .OrderBy(o => o.ShippedDate)
                                 .ToListAsync();
        }
    }
}
