using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;
using AxaColpatria.NotAxApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AxaColpatria.NotAxApp.Infrastructure.Repositories
{
    public class TableroRepository : ITableroRepository
    {
        private readonly AppDbContext _context;

        public TableroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tablero>> GetAllAsync()
        {
            return await _context.Tableros.ToListAsync();
        }

        public async Task<Tablero?> GetByIdAsync(int id)
        {
            return await _context.Tableros.FindAsync(id);
        }

        public async Task<Tablero> AddAsync(Tablero tablero)
        {
            _context.Tableros.Add(tablero);
            await _context.SaveChangesAsync();
            return tablero;
        }

        public async Task<bool> UpdateAsync(Tablero tablero)
        {
            _context.Tableros.Update(tablero);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Tableros.FindAsync(id);
            if (entity == null) return false;

            _context.Tableros.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}