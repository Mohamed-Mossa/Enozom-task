using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Enozom_task.Data;
using Enozom_task.Models;
using Enozom_task.Repositories;

public class PriceRepository : IRepository<Price>
{
    private readonly DatabaseContext _context;

    public PriceRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Price>> GetAll()
    {
        return await _context.Prices
            .Include(p => p.Hotel)
            .OrderBy(p => p.Id)
            .ToListAsync();
    }

    public async Task<Price> GetById(int id)
    {
        return await _context.Prices
            .Include(p => p.Hotel)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Create(Price entity)
    {
        _context.Prices.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Price entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var price = await _context.Prices.FindAsync(id);
        if (price == null) return;

        _context.Prices.Remove(price);
        await _context.SaveChangesAsync();
    }
}
