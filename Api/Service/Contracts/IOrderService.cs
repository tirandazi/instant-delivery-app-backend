using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Service.Contracts
{
    public interface IOrderService
    {
        Task <Orders?> GetOrderAsync(Guid id);
        Task<Orders> CreateOrderAsync(Orders orders);
        Task<Orders?> GetOrderByCartAsync(Guid id);

    }
}