using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;
using AxaColpatria.NotAxApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AxaColpatria.NotAxApp.Infraestructure.Repositories
{
    internal class TableroRepository : ITableroRepository
    {
        private readonly AppDbContext _context;

        public TableroRepository(AppDbContext context)
        {

            _context = context;

        }

        public async Task<IEnumerable<Tablero>> GetAllTablerosAsync()
            => await _context.Tableros.Include(b => b.Notas).ToListAsync();

        public async Task<Tablero?> GetTableroByIdAsync(int id)
            => await _context.Tableros.Include(b => b.Notas).FirstOrDefaultAsync(b => b.Id == id);

        public async Task<Tablero> AddTableroAsync(Tablero board)
        {
            _context.Tableros.Add(board);
            await _context.SaveChangesAsync();
            return board;
        }

        public async Task<bool> UpdateTableroAsync(Tablero board)
        {
            _context.Tableros.Update(board);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTableroAsync(int id)
        {
            var board = await _context.Tableros.FindAsync(id);
            if (board == null) return false;

            _context.Tableros.Remove(board);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
