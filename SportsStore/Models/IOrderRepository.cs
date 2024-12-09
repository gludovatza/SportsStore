using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Models
{
    public interface IOrderRepository 
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
