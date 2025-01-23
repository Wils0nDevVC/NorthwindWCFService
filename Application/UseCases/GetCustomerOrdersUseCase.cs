using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class GetCustomerOrdersUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetCustomerOrdersUseCase()
        {
        }

        public GetCustomerOrdersUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> ExecuteAsync(string customerId)
        {
            return await _orderRepository.GetOrdersByCustomerIdAsync(customerId);
        }
    }
}
