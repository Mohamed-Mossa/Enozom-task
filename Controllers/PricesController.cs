using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enozom_task.Models;
using Enozom_task.Services;

namespace Enozom_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PricesController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetPrices()
        {
            // Retrieve all prices
            var prices = await _priceService.GetAllPrices();
            return Ok(prices);
        }

        [HttpGet("SearchByPriceRange")]
        public async Task<ActionResult<IEnumerable<object>>> GetRoomsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            // Retrieve rooms within a specific price range
            var rooms = await _priceService.GetRoomsByPriceRange(minPrice, maxPrice);

            if (!rooms.Any())
            {
                return NotFound("No rooms found within the specified price range.");
            }

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetPrice(int id)
        {
            // Retrieve a price by its ID
            var price = await _priceService.GetPriceById(id);
            if (price == null)
            {
                return NotFound();
            }

            return Ok(price);
        }

        [HttpPost]
        public async Task<ActionResult<Price>> PostPrice(Price price)
        {
            // Create a new price
            await _priceService.CreatePrice(price);
            return CreatedAtAction(nameof(GetPrice), new { id = price.Id }, price);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrice(int id, Price price)
        {
            // Update an existing price
            if (id != price.Id)
            {
                return BadRequest();
            }

            await _priceService.UpdatePrice(id, price);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrice(int id)
        {
            // Delete a price by its ID
            await _priceService.DeletePrice(id);
            return NoContent();
        }
    }
}
