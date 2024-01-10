using System.Collections.Generic;
using System.Threading.Tasks;
using Enozom_task.Models;
using Enozom_task.Repositories;

namespace Enozom_task.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> _hotelRepository;

        public HotelService(IRepository<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetAll();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _hotelRepository.GetById(id);
        }

        public async Task CreateHotel(Hotel hotel)
        {
            await _hotelRepository.Create(hotel);
        }

        public async Task UpdateHotel(int id, Hotel hotel)
        {
            await _hotelRepository.Update(id, hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _hotelRepository.Delete(id);
        }
    }
}
