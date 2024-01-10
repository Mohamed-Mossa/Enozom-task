using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enozom_task.Models;
using Enozom_task.Repositories;

namespace Enozom_task.Services
{
    public class PriceService : IPriceService
    {
        private readonly IRepository<Price> _priceRepository;

        public PriceService(IRepository<Price> priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<IEnumerable<Price>> GetAllPrices()
        {
            return await _priceRepository.GetAll();
        }

        public async Task<IEnumerable<object>> GetRoomsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var pricesInRange = await _priceRepository.GetAll();

            var rooms = pricesInRange
                .Where(p => p.Cost >= minPrice && p.Cost <= maxPrice)
                .Select(p => new
                {
                    HotelId = p.HotelID,
                    HotelName = p.Hotel?.name ?? "Unknown"
                    // Check if p.Hotel or p.Hotel.name is null
                    // Add other properties related to the room as needed
                })
                .Distinct()
                .ToList();

            return rooms;
        }


        public async Task<Price> GetPriceById(int id)
        {
            return await _priceRepository.GetById(id);
        }

        public async Task CreatePrice(Price price)
        {
            await _priceRepository.Create(price);
        }

        public async Task UpdatePrice(int id, Price price)
        {
            await _priceRepository.Update(id, price);
        }

        public async Task DeletePrice(int id)
        {
            await _priceRepository.Delete(id);
        }
    }
}
