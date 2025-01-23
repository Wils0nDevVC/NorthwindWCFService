using Application.Dtos;
using Application.Interfaces;
using Application.UseCases;
using Infraestructure;
using Infraestructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindWCFService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CustomerService : ICustomerService
    {
        private readonly GetCustomersByCountryUseCase _getCustomersByCountryUseCase;
        private readonly GetCustomerOrdersUseCase _getCustomerOrdersUseCase;
        private readonly TrackWebActionUseCase _trackWebActionUseCase;

        // Constructor predeterminado (sin parámetros)
        public CustomerService()
        {
            // Inicializar las dependencias manualmente o desde algún contenedor de servicios
            var customerRepository = new CustomerRepository(new NorthwindContext());
            var orderRepository = new OrderRepository(new NorthwindContext());
            var webTrackerRepository = new WebTrackerRepository(new NorthwindContext());

            _getCustomersByCountryUseCase = new GetCustomersByCountryUseCase(customerRepository);
            _getCustomerOrdersUseCase = new GetCustomerOrdersUseCase(orderRepository);
            _trackWebActionUseCase = new TrackWebActionUseCase(webTrackerRepository);
        }

        public CustomerService(ICustomerRepository customerRepository, IOrderRepository orderRepository, IWebTrackerRepository webTrackerRepository) : this(
           new GetCustomersByCountryUseCase(customerRepository),
           new GetCustomerOrdersUseCase(orderRepository),
           new TrackWebActionUseCase(webTrackerRepository))
            {
        }

        public CustomerService(GetCustomersByCountryUseCase getCustomersByCountryUseCase,
                               GetCustomerOrdersUseCase getCustomerOrdersUseCase,
                               TrackWebActionUseCase trackWebActionUseCase)
        {
            _getCustomersByCountryUseCase = getCustomersByCountryUseCase;
            _getCustomerOrdersUseCase = getCustomerOrdersUseCase;
            _trackWebActionUseCase = trackWebActionUseCase;
        }



        public async Task<List<CustomerDto>> GetCustomersByCountry(string country)
        {
            var customers = await _getCustomersByCountryUseCase.ExecuteAsync(country);
            return customers.Select(c => new CustomerDto
            {
                CustomerId = c.CustomerId,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                Phone = c.Phone,
                Fax = c.Fax
            }).ToList();
        }

        public async Task<List<OrderDto>> GetCustomerOrders(string customerId)
        {
            var orders = await _getCustomerOrdersUseCase.ExecuteAsync(customerId);
            return orders.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                ShippedDate = o.ShippedDate,
                CustomerId = o.CustomerId
            }).ToList();
        }

        public async Task TrackAction(string urlRequest, string sourceIp)
        {
            await _trackWebActionUseCase.ExecuteAsync(urlRequest, sourceIp);
        }
    }
}
