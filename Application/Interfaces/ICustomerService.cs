using Application.Dtos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        Task<List<CustomerDto>> GetCustomersByCountry(string country);

        [OperationContract]
        Task<List<OrderDto>> GetCustomerOrders(string customerId);

        [OperationContract]
        Task TrackAction(string urlRequest, string sourceIp);
    }
}
