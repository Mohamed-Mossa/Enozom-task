using System.Collections.Generic;
using System.Threading.Tasks;
using Enozom_task.Models;

namespace Enozom_task.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        Task CreateHotel(Hotel hotel);
        Task UpdateHotel(int id, Hotel hotel);
        Task DeleteHotel(int id);
    }
}
