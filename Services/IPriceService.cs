using System.Collections.Generic;
using System.Threading.Tasks;
using Enozom_task.Models;

namespace Enozom_task.Services
{
    public interface IPriceService
    {
        Task<IEnumerable<Price>> GetAllPrices();
        Task<IEnumerable<object>> GetRoomsByPriceRange(decimal minPrice, decimal maxPrice);
        Task<Price> GetPriceById(int id);
        Task CreatePrice(Price price);
        Task UpdatePrice(int id, Price price);
        Task DeletePrice(int id);
    }
}
